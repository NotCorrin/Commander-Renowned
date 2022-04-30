using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ActionbarUI : Listener
{
    #region variables
    [Header("Prompt Bar")]
    [SerializeField] private GameObject promptBar;
    [SerializeField] private UIDocument promptBarUIDocument;
    private VisualElement promptBarContainer;
    private TextElement promptBarValue;
    private Button promptCancelBtn;

    [Header("Support Bar")]
    [SerializeField] private GameObject supportBar;
    [SerializeField] private UIDocument supportBarUIDocument;
    private VisualElement supportBarContainer;
    private Button abilityOneBtn;
    private TextElement abilityOneName;
    private TextElement abilityOneCost;
    private TextElement abilityOneDesc;
    private Button abilityTwoBtn;
    private TextElement abilityTwoName;
    private TextElement abilityTwoCost;
    private TextElement abilityTwoDesc;
    private Button abilityThreeBtn;
    private TextElement abilityThreeName;
    private TextElement abilityThreeCost;
    private TextElement abilityThreeDesc;
    private Button endSupportTurnBtn;

    [Header("Switch Bar")]
    [SerializeField] private GameObject switchBar;
    [SerializeField] private UIDocument switchBarUIDocument;
    private VisualElement switchBarContainer;
    private Button switchBtn;
    private Button endSwitchTurnBtn;

    private Unit selectedUnit;
    #endregion

    void Awake()
    {
        VerifyVariables();
        RunQueries();

        promptBarContainer.style.display = DisplayStyle.None;
        // supportBarContainer.style.display = DisplayStyle.None;
        switchBarContainer.style.display = DisplayStyle.None;
    }

    protected override void SubscribeListeners()
    {
        promptCancelBtn.clickable.clicked += OnPromptCancelClicked;
        abilityOneBtn.clickable.clicked += AbilityOneBtn_Clicked;
        abilityTwoBtn.clickable.clicked += AbilityTwoBtn_Clicked;
        abilityThreeBtn.clickable.clicked += AbilityThreeBtn_Clicked;
        endSupportTurnBtn.clickable.clicked += EndSupportTurnBtn_Clicked;
        switchBtn.clickable.clicked += SwitchBtn_Clicked;
        endSwitchTurnBtn.clickable.clicked += EndSwitchTurnBtn_Clicked;
        UIEvents.onUnitSelected += OnUnitSelected;
        GameEvents.onPhaseChanged += PhaseSwitchUI;
    }

    protected override void UnsubscribeListeners()
    {
        promptCancelBtn.clickable.clicked -= OnPromptCancelClicked;
        abilityOneBtn.clickable.clicked -= AbilityOneBtn_Clicked;
        abilityTwoBtn.clickable.clicked -= AbilityTwoBtn_Clicked;
        abilityThreeBtn.clickable.clicked -= AbilityThreeBtn_Clicked;
        endSupportTurnBtn.clickable.clicked -= EndSupportTurnBtn_Clicked;
        switchBtn.clickable.clicked -= SwitchBtn_Clicked;
        endSwitchTurnBtn.clickable.clicked -= EndSwitchTurnBtn_Clicked;
        UIEvents.onUnitSelected -= OnUnitSelected;
        GameEvents.onPhaseChanged -= PhaseSwitchUI;
    }

    void OnPromptCancelClicked()
    {
        Debug.Log("Prompt Cancel Clicked");
    }

    void AbilityOneBtn_Clicked()
    {
        if(FieldController.main.GetIsVanguard(selectedUnit)) GameEvents.UseAbility( selectedUnit, 
                                                                                    FieldController.main.GetUnit(FieldController.Position.Vanguard, 
                                                                                    !FieldController.main.IsUnitPlayer(selectedUnit)),
                                                                                    1);
        else GameEvents.UseAbility(selectedUnit, SceneController.main.selectedUnit, 1);
        Debug.Log("Ability One Button Clicked");
    }

    void AbilityTwoBtn_Clicked()
    {
        if(FieldController.main.GetIsVanguard(selectedUnit)) GameEvents.UseAbility( selectedUnit, 
                                                                                    FieldController.main.GetUnit(FieldController.Position.Vanguard, 
                                                                                    !FieldController.main.IsUnitPlayer(selectedUnit)),
                                                                                    2);
        else GameEvents.UseAbility(selectedUnit, SceneController.main.selectedUnit, 2);
        Debug.Log("Ability Two Button Clicked");
    }

    void AbilityThreeBtn_Clicked()
    {
        if(FieldController.main.GetIsVanguard(selectedUnit)) GameEvents.UseAbility( selectedUnit, 
                                                                                    FieldController.main.GetUnit(FieldController.Position.Vanguard, 
                                                                                    !FieldController.main.IsUnitPlayer(selectedUnit)),
                                                                                    3);
        else GameEvents.UseAbility(selectedUnit, SceneController.main.selectedUnit, 3);
        Debug.Log("Ability Three Button Clicked");
    }

    void EndSupportTurnBtn_Clicked()
    {
        Debug.Log("End Support Turn Button Clicked");
        GameEvents.SetPhase(RoundController.Phase.NextPhase);
    }

    void SwitchBtn_Clicked()
    {
        Debug.Log("Switch Button Clicked");
        FieldController.main.SwapUnit();
    }

    void EndSwitchTurnBtn_Clicked()
    {
        Debug.Log("End Switch Turn Button Clicked");
        GameEvents.SetPhase(RoundController.Phase.NextPhase);
    }
    void OnUnitSelected(Unit unit)
    {
        selectedUnit = unit;
        Debug.Log(unit.VanguardAbilities[0]);
        Ability[] _abilities = FieldController.main.GetIsVanguard(unit)?unit.VanguardAbilities:unit.SupportAbilities;
        if(_abilities[0])
        {
            abilityOneName.text = _abilities[0].AbilityName;
            abilityOneCost.text = _abilities[0].Cost + "";
            abilityOneDesc.text = _abilities[0].AbilityDescription;
        }
        else
        {
            abilityOneName.text = "";
            abilityOneCost.text = "";
            abilityOneDesc.text = "";
        }
        if(_abilities[1])
        {
            abilityTwoName.text = _abilities[1].AbilityName;
            abilityTwoCost.text = _abilities[1].Cost + "";
            abilityTwoDesc.text = _abilities[1].AbilityDescription;
        }
        else
        {
            abilityTwoName.text = "";
            abilityTwoCost.text = "";
            abilityTwoDesc.text = "";
        }
        if(_abilities[2])
        {
            abilityThreeName.text = _abilities[2].AbilityName;
            abilityThreeCost.text = _abilities[2].Cost + "";
            abilityThreeDesc.text = _abilities[2].AbilityDescription;
        }
        else
        {
            abilityThreeName.text = "";
            abilityThreeCost.text = "";
            abilityThreeDesc.text = "";
        }
    }

    void PhaseSwitchUI(RoundController.Phase phase)
    {
        //promptBar.SetActive(false);
        //supportBar.SetActive(false);
        //switchBar.SetActive(false);
        /*
        switch (phase)
        {
            case RoundController.Phase.PlayerVanguard:
                supportBar.SetActive(true);
                break;
            case RoundController.Phase.EnemyVangaurd:
                supportBar.SetActive(true);
                break;
            case RoundController.Phase.PlayerSwap:
                switchBar.SetActive(true);
                break;
            case RoundController.Phase.EnemySwap:
                switchBar.SetActive(true);
                break;
            case RoundController.Phase.PlayerSupport:
                supportBar.SetActive(true);
                break;
            case RoundController.Phase.EnemySupport:
                supportBar.SetActive(true);
                break;
            default:
                break;
        }*/
        OnUnitSelected(selectedUnit);
        endSupportTurnBtn.text = phase.ToString() + "\nEnd Phase";
    }

    void VerifyVariables()
    {
        if (promptBar == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Prompt Bar Game Object assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBar = transform.Find("Prompt Bar").gameObject;
        }

        if (supportBar == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Support Bar Game Object assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBar = transform.Find("Support Bar").gameObject;
        }

        if (switchBar == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Switch Bar Game Object assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBar = transform.Find("Switch Bar").gameObject;
        }

        if (promptBarUIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Prompt Bar UIDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            promptBarUIDocument = promptBar.GetComponent<UIDocument>();
        }

        if (supportBarUIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Support Bar UIDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            supportBarUIDocument = supportBar.GetComponent<UIDocument>();
        }

        if (switchBarUIDocument == null)
        {
            Debug.LogWarning($"{gameObject.name} : ActionbarUI - has no Switch Bar UIDocument assigned in the inspector. Script might still work, but is not 100% safe.");
            switchBarUIDocument = switchBar.GetComponent<UIDocument>();
        }
    }

    void RunQueries()
    {
        try
        {
            // Prompt Bar
            promptBarContainer = promptBarUIDocument.rootVisualElement.Query<VisualElement>("container");
            promptBarValue = promptBarContainer.Query<TextElement>("prompt");
            promptCancelBtn = promptBarContainer.Query<Button>("cancel-button");

            // Support Bar
            supportBarContainer = supportBarUIDocument.rootVisualElement.Query<VisualElement>("container");
            abilityOneBtn = supportBarContainer.Query<Button>("ability-one");
            abilityOneName = abilityOneBtn.Query<TextElement>("name");
            abilityOneCost = abilityOneBtn.Query<TextElement>("cost");
            abilityOneDesc = abilityOneBtn.Query<TextElement>("description");

            abilityTwoBtn = supportBarContainer.Query<Button>("ability-two");
            abilityTwoName = abilityTwoBtn.Query<TextElement>("name");
            abilityTwoCost = abilityTwoBtn.Query<TextElement>("cost");
            abilityTwoDesc = abilityTwoBtn.Query<TextElement>("description");

            abilityThreeBtn = supportBarContainer.Query<Button>("ability-three");
            abilityThreeName = abilityThreeBtn.Query<TextElement>("name");
            abilityThreeCost = abilityThreeBtn.Query<TextElement>("cost");
            abilityThreeDesc = abilityThreeBtn.Query<TextElement>("description");

            endSupportTurnBtn = supportBarContainer.Query<Button>("end-button");

            // Switch Bar
            switchBarContainer = switchBarUIDocument.rootVisualElement.Query<VisualElement>("container");

            switchBtn = switchBarContainer.Query<Button>("switch-button");
            endSwitchTurnBtn = switchBarContainer.Query<Button>("end-button");

        }
        catch
        {
            Debug.LogError($"{gameObject.name} : ActionbarUI - Element Query Failed.");
        }
    }
}
