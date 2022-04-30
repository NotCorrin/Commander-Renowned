using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : Listener
{
    public enum QTEType { shrinkingCircle }
    public enum QTEResult { Critical, Hit, Miss }
    public enum QTEDisplayResult { Perfect, Good, Poor }

    //Shrinking Circles QTE
    static private float shrinkingCircleBaseTime = 0.5f; //5.0f
    static private float shrinkingCircleDifficultyStep = 0.5f;
    static private float shrinkingCircleMinCritical = 0.4f;
    static private float shrinkingCircleMaxCritical = 0.6f;
    static private float shrinkingCircleMinHit = 0.2f;
    private float shrinkingCircleMaxTime;
    public float ShrinkingCircleMaxTime
    {
        get => shrinkingCircleMaxTime;
    }
    private float shrinkingCircleTimer;
    public float ShrinkingCircleTimer
    {
        get => shrinkingCircleTimer;
    }

    bool shrinkingCircleActive;

    // Start is called before the first frame update
    void Start()
    {
        
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
        switch (qteType)
        {
            case QTEType.shrinkingCircle:
                {
                    StartShrinkingCircle(difficultyModifier);
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
                            Debug.Log("AAAAAAAAA0");
    }

    private void ResolveShrinkingCircle()
    {
                            Debug.Log("AAAAAAAAA1");
        //Placeholder default hit value
        UIEvents.DisplayQTEResults(QTEDisplayResult.Good);
        GameEvents.QTEResolved(QTEResult.Hit);
        MenuEvents.onQTETriggered -= ResolveShrinkingCircle;
        return;

        //Possibly working code for shrinking circle backend. Not implemented currently.

        QTEResult finalResult;
        if (shrinkingCircleTimer > shrinkingCircleMaxTime * shrinkingCircleMinCritical && shrinkingCircleTimer < shrinkingCircleTimer * shrinkingCircleMaxCritical)
        {
            finalResult = QTEResult.Critical;
            UIEvents.onDisplayQTEResults(QTEDisplayResult.Perfect);
        }
        else if (shrinkingCircleTimer < shrinkingCircleMaxTime * shrinkingCircleMinHit || shrinkingCircleTimer > shrinkingCircleMaxTime * shrinkingCircleMaxCritical)
        {
            finalResult = QTEResult.Miss;
            UIEvents.onDisplayQTEResults(QTEDisplayResult.Poor);
        }
        else
        {
            finalResult = QTEResult.Hit;
            UIEvents.onDisplayQTEResults(QTEDisplayResult.Good);
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

        return QTEResult.Hit;
    }

}
