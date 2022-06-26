using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A QTE controller.
/// </summary>
public class QTEController : Listener
{
    // Shrinking Circles QTE
    private static float timingBarDifficultyStep = 0.4f;
    private static float timingBarMaxCritical = 0.3f;
    private static float timingBarMaxHit = 0.5f;

    [SerializeField] private GameObject qtePrefab;

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

        // Inverts difficulty modifier if not player turn
        if (RoundController.Main != null)
        {
            if (!RoundController.Main.IsCurrentRoundPlayer())
            {
                finalDifficultyModifier = -difficultyModifier;
            }
        }

        switch (qteType)
        {
            case GameManager.QTEType.shrinkingCircle:
                {
                    StartShrinkingCircle(finalDifficultyModifier);
                    break;
                }
        }
    }

    private void StartShrinkingCircle(int difficultyModifier)
    {
        MenuEvents.onQTETriggered += ResolveQTE;
        int timingBarHitPercentage = (int)(100 * (timingBarMaxHit + (timingBarDifficultyStep * Mathf.Atan2(-difficultyModifier, 3))));
        Instantiate(qtePrefab, new Vector2(0f, 0f), Quaternion.identity).GetComponent<MouseQTEUI>().SetQTEValues(timingBarHitPercentage, (int)(timingBarMaxCritical * (float)timingBarHitPercentage));
    }

    private void ResolveQTE(GameManager.QTEResult result)
    {
        GameManager.QTEResult finalResult = result;

        // Inverting result if is enemy turn
        finalResult = InvertResultIfNotPlayer(finalResult);
        GameEvents.QTEResolved(finalResult);

        MenuEvents.onQTETriggered -= ResolveQTE;
    }

    private GameManager.QTEResult InvertResultIfNotPlayer(GameManager.QTEResult baseResult)
    {
        if (RoundController.Main != null)
        {
            if (!RoundController.Main.IsCurrentRoundPlayer())
            {
                // Debug.Log("Not player, inverting");
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
