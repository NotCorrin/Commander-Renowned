using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Text;

public class PhasePanelUI : Listener
{
    [SerializeField] private UIDocument uIDocument;
    [SerializeField] private VectorImage vectorImage;
    private VisualElement phaseContainer;
    private TextElement phaseText;

    protected override void SubscribeListeners()
    {
        GameEvents.onChangePhase += setPhaseLabel;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onChangePhase -= setPhaseLabel;
    }
    void Start()
    {
        if (uIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : PhasePanelUI - has no uiDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            uIDocument = GetComponent<UIDocument>();
        }

        try
        {
            phaseContainer = uIDocument.rootVisualElement.Q<VisualElement>("container");
            phaseText = phaseContainer.Q<TextElement>("phase");
        }
        catch
        {
            Debug.LogError($"{gameObject.name} : PhasePanelUI - Element Query Failed.");
        }
    }

    string AddSpacesToPhase(string phase)
    {
        if (string.IsNullOrWhiteSpace(phase))
        {
            return "";
        }

        StringBuilder newPhase = new StringBuilder(phase.Length * 2);
        newPhase.Append(phase[0]);
        for (int i = 1; i < phase.Length; i++)
        {
            if (char.IsUpper(phase[i]) && phase[i - 1] != ' ')
            {
                newPhase.Append(' ');
            }

            newPhase.Append(phase[i]);
        }

        return newPhase.ToString();
    }

    void setPhaseLabel(RoundController.Phase phase)
    {
        phaseText.text = AddSpacesToPhase(phase.ToString()) + " Phase";
    }

    // void setPhaseContainerTint(RoundController.Phase phase)
    // {
    //     if (phase == RoundController.Phase.PlayerSupport || phase == RoundController.Phase.PlayerSwap || phase == RoundController.Phase.PlayerVanguard)
    //     {
    //     }

    //     else if (phase == RoundController.Phase.EnemySupport || phase == RoundController.Phase.EnemySwap || phase == RoundController.Phase.EnemyVangaurd)
    //     {
    //     }
    // }
}
