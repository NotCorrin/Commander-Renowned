using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : Listener
{
    //Shrinking Circles QTE
    static private float timingBarDifficultyStep = 0.4f;
    static private float timingBarMaxCritical = 0.3f;
    static private float timingBarMaxHit = 0.5f;

    public GameObject qtePrefab;

    private void Awake()
    {
        Application.targetFrameRate = 165;
    }
    // Start is called before the first frame update
    void Start()
    {
        //shrinkingCircleMaxTime = shrinkingCircleBaseTime * shrinkingCircleDifficultyStep;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void SubscribeListeners()
    {
        GameEvents.onQTEStart += StartQTE;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEStart -= StartQTE;
    }

    private void StartQTE(GameManager.QTEType qteType, int difficultyModifier)
    {
        int finalDifficultyModifier = difficultyModifier;

        //Inverts difficulty modifier if not player turn
        if (RoundController.main != null)
        {
            if (!RoundController.main.IsCurrentRoundPlayer())
            {
                finalDifficultyModifier = -difficultyModifier;
            }
        }

        switch (qteType)
        {
            case GameManager.QTEType.TimingBar:
                {
                    StartShrinkingCircle(finalDifficultyModifier);
                    break;
                }
        }
    }

    private void StartShrinkingCircle(int difficultyModifier)
    {
        MenuEvents.onQTETriggered += ResolveQTE;
        int timingBarHitPercentage = (int)(100 * (timingBarMaxHit + timingBarDifficultyStep*Mathf.Atan2(-difficultyModifier,3)));
        Instantiate(qtePrefab, new Vector2(0f, 0f), Quaternion.identity).GetComponent<MouseQTEUI>().SetQTEValues(timingBarHitPercentage, (int)(timingBarMaxCritical * (float)timingBarHitPercentage));
    }
    
    private void ResolveQTE(GameManager.QTEResult result)
    {
        GameManager.QTEResult finalResult = result;

        //Inverting result if is enemy turn
        finalResult = InvertResultIfNotPlayer(finalResult);
        GameEvents.QTEResolved(finalResult);

        MenuEvents.onQTETriggered -= ResolveQTE;

    }

    private GameManager.QTEResult InvertResultIfNotPlayer(GameManager.QTEResult baseResult)
    {

        if (RoundController.main != null)
        {
            if (!RoundController.main.IsCurrentRoundPlayer())
            {
                //Debug.Log("Not player, inverting");
                switch (baseResult)
                {
                    case GameManager.QTEResult.Critical:
                        {
                            return GameManager.QTEResult.Miss;
                        }
                    case GameManager.QTEResult.Miss:
                        {
                            return GameManager.QTEResult.Critical;
                        }
                }
            }
        }
        else
        {
            Debug.Log("No RoundController Found, Defaulting to Player Turn");
        }

        return baseResult;
    }

}
