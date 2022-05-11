using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : Listener
{
    public enum QTEType { shrinkingCircle }
    public enum QTEResult { Critical, Hit, Miss }
    public enum QTEDisplayResult { Perfect, Good, Poor }

    //Shrinking Circles QTE
    static private float shrinkingCircleBaseTime = 3.0f; //5.0f
    static private float shrinkingCircleDifficultyStep = 0.6f;
    static private float shrinkingCircleMaxCritical = 0.657f;
    static private float shrinkingCircleMaxHit = 0.8f;
    static private float shrinkingCircleMin = 0.57f;
    private static float shrinkingCircleMaxTime;

    public GameObject qtePrefab;
    public static float ShrinkingCircleMaxTime
    {
        get => shrinkingCircleMaxTime;
    }
    private static float shrinkingCircleTimer;
    public static float ShrinkingCircleTimer
    {
        get => shrinkingCircleTimer;
    }

    static bool shrinkingCircleActive;

    // Start is called before the first frame update
    void Start()
    {
        shrinkingCircleMaxTime = shrinkingCircleBaseTime * shrinkingCircleDifficultyStep;
    }

    // Update is called once per frame
    void Update()
    {
        if (shrinkingCircleActive) 
        {
            if (shrinkingCircleTimer < 0) MenuEvents.QTETriggered();
            shrinkingCircleTimer -= Time.deltaTime;
        }
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onQTEStart += StartQTE;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEStart -= StartQTE;
    }

    private void StartQTE(QTEType qteType, int difficultyModifier)
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
            case QTEType.shrinkingCircle:
                {
                    StartShrinkingCircle(finalDifficultyModifier);
                    break;
                }
        }
    }

    private void StartShrinkingCircle(int difficultyModifier)
    {
        shrinkingCircleActive = true;
        shrinkingCircleMaxTime = shrinkingCircleBaseTime + (difficultyModifier * shrinkingCircleDifficultyStep);
        shrinkingCircleTimer = shrinkingCircleMaxTime;
        MenuEvents.onQTETriggered += ResolveShrinkingCircle;
        Instantiate(qtePrefab, new Vector2(0f, 0f), Quaternion.identity);
    }

    private void ResolveShrinkingCircle()
    {
        QTEResult finalResult;

        float finalPercentage = ShrinkingCircleTimer / ShrinkingCircleMaxTime;

        if (finalPercentage <= shrinkingCircleMin || finalPercentage >= shrinkingCircleMaxHit)
        {
            finalResult = QTEResult.Miss;
            UIEvents.DisplayQTEResults(QTEDisplayResult.Poor);
            //Debug.Log(finalPercentage + "Poor");
        }
        else if (finalPercentage <= shrinkingCircleMaxCritical)
        {
            finalResult = QTEResult.Critical;
            UIEvents.DisplayQTEResults(QTEDisplayResult.Perfect);
            //Debug.Log(finalPercentage + "Perfect");

        }
        else
        {
            finalResult = QTEResult.Hit;
            UIEvents.DisplayQTEResults(QTEDisplayResult.Good);
            //Debug.Log(finalPercentage + "Good");
        }
        
        //Inverting result if is enemy turn
        finalResult = InvertResultIfNotPlayer(finalResult);
        GameEvents.QTEResolved(finalResult);

        MenuEvents.onQTETriggered -= ResolveShrinkingCircle;

    }

    private QTEResult InvertResultIfNotPlayer(QTEResult baseResult)
    {

        if (RoundController.main != null)
        {
            if (!RoundController.main.IsCurrentRoundPlayer())
            {
                //Debug.Log("Not player, inverting");
                switch (baseResult)
                {
                    case QTEResult.Critical:
                        {
                            return QTEResult.Miss;
                        }
                    case QTEResult.Miss:
                        {
                            return QTEResult.Critical;
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
