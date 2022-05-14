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
    private VisualElement abilityOne;
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
    private int selectedAbility;
    private string prompt = "";

    private bool[] abilityActive = new bool[3];
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
        abilityOne.RegisterCallback<MouseEnterEvent>(AbilityOne_Hover);
        abilityOne.RegisterCallback<MouseLeaveEvent>(AbilityOne_Unhover);
        abilityOne.RegisterCallback<ClickEvent>(AbilityOne_Clicked);
        abilityTwoBtn.clickable.clicked += AbilityTwoBtn_Clicked;
        abilityThreeBtn.clickable.clicked += AbilityThreeBtn_Clicked;
        endSupportTurnBtn.clickable.clicked += EndSupportTurnBtn_Clicked;
        switchBtn.clickable.clicked += SwitchBtn_Clicked;
        endSwitchTurnBtn.clickable.clicked += EndSwitchTurnBtn_Clicked;
        UIEvents.onUnitSelected += OnUnitSelected;
        GameEvents.onPhaseChanged += PhaseSwitchUI;
        GameEvents.onAbilityResolved += AbilityUsed;
        //GameEvents.onKill += SwitchPrompt;
    }

    protected override void UnsubscribeListeners()
    {
        promptCancelBtn.clickable.clicked -= OnPromptCancelClicked;
        abilityOne.UnregisterCallback<MouseEnterEvent>(AbilityOne_Hover);
        abilityOne.UnregisterCallback<MouseLeaveEvent>(AbilityOne_Unhover);
        abilityOne.UnregisterCallback<ClickEvent>(AbilityOne_Clicked);
        abilityTwoBtn.clickable.clicked -= AbilityTwoBtn_Clicked;
        abilityThreeBtn.clickable.clicked -= AbilityThreeBtn_Clicked;
        endSupportTurnBtn.clickable.clicked -= EndSupportTurnBtn_Clicked;
        switchBtn.clickable.clicked -= SwitchBtn_Clicked;
        endSwitchTurnBtn.clickable.clicked -= EndSwitchTurnBtn_Clicked;
        UIEvents.onUnitSelected -= OnUnitSelected;
        GameEvents.onPhaseChanged -= PhaseSwitchUI;
        GameEvents.onAbilityResolved -= AbilityUsed;
        //GameEvents.onKill -= SwitchPrompt;
    }

    void OnPromptCancelClicked()
    {
        prompt = "";
        supportBarContainer.style.display = DisplayStyle.Flex;
        promptBarContainer.style.display = DisplayStyle.None;
        Debug.Log("Prompt Cancel Clicked");
    }

    void AbilityOne_Hover(MouseEnterEvent evt)
    {

    }

    void AbilityOne_Unhover(MouseLeaveEvent evt)
    {

    }

    void AbilityOne_Clicked(ClickEvent evt)
    {
        UseAbility(1);
        Debug.Log("Ability One Button Clicked");
    }

    void AbilityTwoBtn_Clicked()
    {
        UseAbility(2);
        Debug.Log("Ability Two Button Clicked");
    }

    void AbilityThreeBtn_Clicked()
    {
        UseAbility(3);
        Debug.Log("Ability Three Button Clicked");
    }
    void UseAbility(int _selectedAbility)
    {
        if(RoundController.phase == RoundController.Phase.PlayerVanguard)
        {
            if(FieldController.main.IsUnitActive(selectedUnit)) 
            GameEvents.UseAbility(  selectedUnit, 
                                    FieldController.main.GetUnit(FieldController.Position.Vanguard, !FieldController.main.IsUnitPlayer(selectedUnit)),
                                    _selectedAbility);
        }
        else if(RoundController.phase == RoundController.Phase.PlayerSupport)
        {
            if(!abilityActive[_selectedAbility-1]) return;
            if(selectedUnit.SupportAbilities[_selectedAbility-1].IsAbilityValid(selectedUnit, selectedUnit))
            {
                GameEvents.UseAbility(selectedUnit, selectedUnit, _selectedAbility);
            }
            else
            {
                supportBarContainer.style.display = DisplayStyle.None;
                promptBarContainer.style.display = DisplayStyle.Flex;
                prompt = "Ability";
                promptBarValue.text = "Select target for " + selectedUnit.SupportAbilities[_selectedAbility-1].AbilityName;
                selectedAbility = _selectedAbility;
            }
        }
        OnUnitSelected(selectedUnit);
        //else GameEvents.UseAbility(selectedUnit, SceneController.main.selectedUnit, 3);
    }

    void EndSupportTurnBtn_Clicked()
    {
        Debug.Log("End Support Turn Button Clicked");
        if(RoundController.phase == RoundController.Phase.PlayerVanguard || RoundController.phase == RoundController.Phase.PlayerSupport) GameEvents.EndPhase();
        else Debug.Log("Player does not have priority right now!");
    }

    void SwitchBtn_Clicked()
    {
        Debug.Log("Switch Button Clicked");
        if (RoundController.phase == RoundController.Phase.PlayerSwap)
        {
            if (SceneController.main.selectedUnit)
            {
                if (FieldController.main.IsUnitPlayer(SceneController.main.selectedUnit)) FieldController.main.SwapPlayerUnit();
                return;
            }
        }

        Debug.Log("Player cannot swap right now!");
    }

    void EndSwitchTurnBtn_Clicked()
    {
        Debug.Log("End Switch Turn Button Clicked");
        if (RoundController.phase == RoundController.Phase.PlayerSwap) GameEvents.EndPhase();
        else Debug.Log("Player does not have priority right now!");
    }
    void AbilityUsed(Unit unit)
    {
        FieldController.main.SupportUsed(unit);
        OnUnitSelected(unit);
    }
    void OnUnitSelected(Unit unit)
    {
        if(!unit) return;
        //Debug.Log(unit.UnitName + " was selected");
        if(selectedUnit && unit)
        {
            if(prompt == "Ability")
            {
                if(RoundController.phase != RoundController.Phase.PlayerSupport) prompt = "";
                else if(selectedUnit.SupportAbilities[selectedAbility - 1].IsAbilityValid(selectedUnit, unit))
                {
                    Debug.Log("Caster = " + selectedUnit + "\n" + "Target = " + unit);
                    supportBarContainer.style.display = DisplayStyle.Flex;
                    promptBarContainer.style.display = DisplayStyle.None;
                    prompt = "";
                    GameEvents.UseAbility(selectedUnit, unit, selectedAbility);
                }
                return;
            }
            else if (prompt == "Death")
            {
                if(FieldController.main.IsUnitPlayer(unit) && !FieldController.main.GetIsVanguard(unit))
                {
                    supportBarContainer.style.display = DisplayStyle.Flex;
                    promptBarContainer.style.display = DisplayStyle.None;
                    prompt = "";
                    FieldController.main.SwapPlayerUnit(unit);
                }
                return;
            }
        }

        selectedUnit = unit;
        AbilityUI(unit);
    }
    void AbilityUI(Unit unit, bool setAllFalse = false)
    {
        //Debug.Log("Rendering abilities... ");
        Ability[] _abilities = FieldController.main.GetIsVanguard(unit)?unit.VanguardAbilities:unit.SupportAbilities;

        for (int i = 0; i < _abilities.Length; i++)
        {
            if(setAllFalse)
            {
                abilityActive[i] = false;
                continue;
            }
            if(!FieldController.main.IsUnitActive(unit)
            || _abilities[i] == null)
            {
                abilityActive[i] = false;
                continue;
            }
            if(!_abilities[i].IsCasterValid(unit))
            {
                abilityActive[i] = false;
                continue;
            }
            abilityActive[i] = true;
        }
        // if(abilityActive[0]) abilityOneBtn.style.backgroundColor = new StyleColor(new Color(1, 1, 1, 0.69f));
        // else abilityOneBtn.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 0.69f));

        if(abilityActive[1]) abilityTwoBtn.style.backgroundColor = new StyleColor(new Color(1, 1, 1, 0.69f));
        else abilityTwoBtn.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 0.69f));

        if(abilityActive[2]) abilityThreeBtn.style.backgroundColor = new StyleColor(new Color(1, 1, 1, 0.69f));
        else abilityThreeBtn.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 0.69f));

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
        supportBarContainer.style.display = DisplayStyle.None;
        switchBarContainer.style.display = DisplayStyle.None;
        promptBarContainer.style.display = DisplayStyle.None;

        if (!FieldController.main.GetUnit(FieldController.Position.Vanguard, true))
        {
            endSwitchTurnBtn.style.display = DisplayStyle.None;
            switchBarContainer.style.display = DisplayStyle.Flex;
            OnUnitSelected(selectedUnit);
            return;
        }
        else endSwitchTurnBtn.style.display = DisplayStyle.Flex;

        switch (phase)
        {
            case RoundController.Phase.PlayerVanguard:
                supportBarContainer.style.display = DisplayStyle.Flex;
                break;
            case RoundController.Phase.EnemyVangaurd:
                supportBarContainer.style.display = DisplayStyle.Flex;
                break;
            case RoundController.Phase.PlayerSwap:
                switchBarContainer.style.display = DisplayStyle.Flex;                    
                break;
            case RoundController.Phase.EnemySwap:
                switchBarContainer.style.display = DisplayStyle.Flex;
                break;
            case RoundController.Phase.PlayerSupport:
                supportBarContainer.style.display = DisplayStyle.Flex;
                break;
            case RoundController.Phase.EnemySupport:
                supportBarContainer.style.display = DisplayStyle.Flex;
                break;
            default:
                break;
        }
        OnUnitSelected(selectedUnit);
        // endSupportTurnBtn.text = phase.ToString() + "\nEnd Phase";
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
            abilityOne = supportBarContainer.Query<VisualElement>("ability-one");
            abilityOneName = abilityOne.Query<TextElement>("name");
            abilityOneCost = abilityOne.Query<TextElement>("cost");
            abilityOneDesc = abilityOne.Query<TextElement>("description");

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
