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
    private VisualElement abilityOneActive;
    private VisualElement abilityOneHover;

    private VisualElement abilityOneDisabled;

    private TextElement abilityOneActiveName;
    private TextElement abilityOneActiveCost;
    private TextElement abilityOneActiveDesc;
    private TextElement abilityOneHoverName;
    private TextElement abilityOneHoverCost;
    private TextElement abilityOneHoverDesc;
    private TextElement abilityOneDisabledName;
    private TextElement abilityOneDisabledCost;
    private TextElement abilityOneDisabledDesc;
    private VisualElement abilityTwo;
    private VisualElement abilityTwoActive;
    private VisualElement abilityTwoHover;

    private VisualElement abilityTwoDisabled;

    private TextElement abilityTwoActiveName;
    private TextElement abilityTwoActiveCost;
    private TextElement abilityTwoActiveDesc;
    private TextElement abilityTwoHoverName;
    private TextElement abilityTwoHoverCost;
    private TextElement abilityTwoHoverDesc;
    private TextElement abilityTwoDisabledName;
    private TextElement abilityTwoDisabledCost;
    private TextElement abilityTwoDisabledDesc;
    private VisualElement abilityThree;
    private VisualElement abilityThreeActive;
    private VisualElement abilityThreeHover;
    private VisualElement abilityThreeDisabled;
    private TextElement abilityThreeActiveName;
    private TextElement abilityThreeActiveCost;
    private TextElement abilityThreeActiveDesc;
    private TextElement abilityThreeHoverName;
    private TextElement abilityThreeHoverCost;
    private TextElement abilityThreeHoverDesc;
    private TextElement abilityThreeDisabledName;
    private TextElement abilityThreeDisabledCost;
    private TextElement abilityThreeDisabledDesc;
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

        abilityTwo.RegisterCallback<MouseEnterEvent>(AbilityTwo_Hover);
        abilityTwo.RegisterCallback<MouseLeaveEvent>(AbilityTwo_Unhover);
        abilityTwo.RegisterCallback<ClickEvent>(AbilityTwo_Clicked);

        abilityThree.RegisterCallback<MouseEnterEvent>(AbilityThree_Hover);
        abilityThree.RegisterCallback<MouseLeaveEvent>(AbilityThree_Unhover);
        abilityThree.RegisterCallback<ClickEvent>(AbilityThree_Clicked);

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

        abilityTwo.UnregisterCallback<MouseEnterEvent>(AbilityTwo_Hover);
        abilityTwo.UnregisterCallback<MouseLeaveEvent>(AbilityTwo_Unhover);
        abilityTwo.UnregisterCallback<ClickEvent>(AbilityTwo_Clicked);

        abilityThree.UnregisterCallback<MouseEnterEvent>(AbilityThree_Hover);
        abilityThree.UnregisterCallback<MouseLeaveEvent>(AbilityThree_Unhover);
        abilityThree.UnregisterCallback<ClickEvent>(AbilityThree_Clicked);

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
        if (abilityActive[0])
        {
            abilityOneHover.style.height = new Length(100, LengthUnit.Percent);
            abilityOneActive.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    void AbilityOne_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[0])
        {
            abilityOneHover.style.height = new Length(0, LengthUnit.Percent);
            abilityOneActive.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    void AbilityOne_Clicked(ClickEvent evt)
    {
        UseAbility(1);
        abilityOneHover.style.height = new Length(0, LengthUnit.Percent);
        abilityOneActive.style.height = new Length(100, LengthUnit.Percent);
        Debug.Log("Ability One Button Clicked");
    }

    void AbilityTwo_Hover(MouseEnterEvent evt)
    {
        if (abilityActive[1])
        {
            abilityTwoHover.style.height = new Length(100, LengthUnit.Percent);
            abilityTwoActive.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    void AbilityTwo_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[1])
        {
            abilityTwoHover.style.height = new Length(0, LengthUnit.Percent);
            abilityTwoActive.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    void AbilityTwo_Clicked(ClickEvent evt)
    {
        UseAbility(2);
        abilityTwoHover.style.height = new Length(0, LengthUnit.Percent);
        abilityTwoActive.style.height = new Length(100, LengthUnit.Percent);
        Debug.Log("Ability Two Button Clicked");
    }

    void AbilityThree_Hover(MouseEnterEvent evt)
    {

    }

    void AbilityThree_Unhover(MouseLeaveEvent evt)
    {

    }

    void AbilityThree_Clicked(ClickEvent evt)
    {
        UseAbility(3);
        Debug.Log("Ability Three Button Clicked");
    }
    void UseAbility(int _selectedAbility)
    {
        if(RoundController.phase == RoundController.Phase.PlayerVanguard)
        {
            if (!abilityActive[_selectedAbility - 1]) return;
            if (FieldController.main.IsUnitActive(selectedUnit)) 
            GameEvents.UseAbility(  selectedUnit, 
                                    FieldController.main.GetUnit(FieldController.Position.Vanguard, !FieldController.main.IsUnitPlayer(selectedUnit)),
                                    _selectedAbility);
            AbilityUI(selectedUnit, true);
            return;
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
        if(!unit) 
        {
            abilityOneActive.style.display = DisplayStyle.None;
            abilityOneHover.style.display = DisplayStyle.None;
            abilityOneDisabled.style.display = DisplayStyle.None;

            abilityTwoActive.style.display = DisplayStyle.None;
            abilityTwoHover.style.display = DisplayStyle.None;
            abilityTwoDisabled.style.display = DisplayStyle.None;

            abilityThreeActive.style.display = DisplayStyle.None;
            abilityThreeHover.style.display = DisplayStyle.None;
            abilityThreeDisabled.style.display = DisplayStyle.None;
            return;
        }
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

        if (abilityActive[0])
        {
            abilityOneActive.style.display = DisplayStyle.Flex;
            abilityOneHover.style.display = DisplayStyle.Flex;
            abilityOneDisabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityOneActive.style.display = DisplayStyle.None;
            abilityOneHover.style.display = DisplayStyle.None;
            abilityOneDisabled.style.display = DisplayStyle.Flex;
        }

        if (abilityActive[1])
        {
            abilityTwoActive.style.display = DisplayStyle.Flex;
            abilityTwoHover.style.display = DisplayStyle.Flex;
            abilityTwoDisabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityTwoActive.style.display = DisplayStyle.None;
            abilityTwoHover.style.display = DisplayStyle.None;
            abilityTwoDisabled.style.display = DisplayStyle.Flex;
        }

        if (abilityActive[2])
        {
            abilityThreeActive.style.display = DisplayStyle.Flex;
            abilityThreeHover.style.display = DisplayStyle.Flex;
            abilityThreeDisabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityThreeActive.style.display = DisplayStyle.None;
            abilityThreeHover.style.display = DisplayStyle.None;
            abilityThreeDisabled.style.display = DisplayStyle.Flex;
        }

        if(_abilities[0])
        {
            abilityOneActiveName.text = _abilities[0].AbilityName;
            abilityOneActiveCost.text = _abilities[0].Cost + "";
            abilityOneActiveDesc.text = _abilities[0].AbilityDescription;

            abilityOneHoverName.text = _abilities[0].AbilityName;
            abilityOneHoverCost.text = _abilities[0].Cost + "";
            abilityOneHoverDesc.text = _abilities[0].AbilityDescription;

            abilityOneDisabledName.text = _abilities[0].AbilityName;
            abilityOneDisabledCost.text = _abilities[0].Cost + "";
            abilityOneDisabledDesc.text = _abilities[0].AbilityDescription;
        }
        else
        {
            abilityOneActiveName.text = "";
            abilityOneActiveCost.text = "";
            abilityOneActiveDesc.text = "";

            abilityOneHoverName.text = "";
            abilityOneHoverCost.text = "";
            abilityOneHoverDesc.text = "";

            abilityOneDisabledName.text = "";
            abilityOneDisabledCost.text = "";
            abilityOneDisabledDesc.text = "";
        }
        if(_abilities[1])
        {
            abilityTwoActiveName.text = _abilities[1].AbilityName;
            abilityTwoActiveCost.text = _abilities[1].Cost + "";
            abilityTwoActiveDesc.text = _abilities[1].AbilityDescription;

            abilityTwoHoverName.text = _abilities[1].AbilityName;
            abilityTwoHoverCost.text = _abilities[1].Cost + "";
            abilityTwoHoverDesc.text = _abilities[1].AbilityDescription;

            abilityTwoDisabledName.text = _abilities[1].AbilityName;
            abilityTwoDisabledCost.text = _abilities[1].Cost + "";
            abilityTwoDisabledDesc.text = _abilities[1].AbilityDescription;
        }
        else
        {
            abilityTwoActiveName.text = "";
            abilityTwoActiveCost.text = "";
            abilityTwoActiveDesc.text = "";

            abilityTwoHoverName.text = "";
            abilityTwoHoverCost.text = "";
            abilityTwoHoverDesc.text = "";

            abilityTwoDisabledName.text = "";
            abilityTwoDisabledCost.text = "";
            abilityTwoDisabledDesc.text = "";
        }
        if(_abilities[2])
        {
            abilityThreeActiveName.text = _abilities[2].AbilityName;
            abilityThreeActiveCost.text = _abilities[2].Cost + "";
            abilityThreeActiveDesc.text = _abilities[2].AbilityDescription;

            abilityThreeHoverName.text = _abilities[2].AbilityName;
            abilityThreeHoverCost.text = _abilities[2].Cost + "";
            abilityThreeHoverDesc.text = _abilities[2].AbilityDescription;

            abilityThreeDisabledName.text = _abilities[2].AbilityName;
            abilityThreeDisabledCost.text = _abilities[2].Cost + "";
            abilityThreeDisabledDesc.text = _abilities[2].AbilityDescription;
        }
        else
        {
            abilityThreeActiveName.text = "";
            abilityThreeActiveCost.text = "";
            abilityThreeActiveDesc.text = "";

            abilityThreeHoverName.text = "";
            abilityThreeHoverCost.text = "";
            abilityThreeHoverDesc.text = "";

            abilityThreeDisabledName.text = "";
            abilityThreeDisabledCost.text = "";
            abilityThreeDisabledDesc.text = "";
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
            abilityOneActive = abilityOne.Query<VisualElement>("active");
            abilityOneHover = abilityOne.Query<VisualElement>("hover");
            abilityOneDisabled = abilityOne.Query<VisualElement>("disabled");
            abilityOneActiveName = abilityOneActive.Q<TextElement>("name");
            abilityOneActiveCost = abilityOneActive.Q<TextElement>("cost");
            abilityOneActiveDesc = abilityOneActive.Q<TextElement>("description");
            abilityOneHoverName = abilityOneHover.Q<TextElement>("name");
            abilityOneHoverCost = abilityOneHover.Q<TextElement>("cost");
            abilityOneHoverDesc = abilityOneHover.Q<TextElement>("description");
            abilityOneDisabledName = abilityOneDisabled.Q<TextElement>("name");
            abilityOneDisabledCost = abilityOneDisabled.Q<TextElement>("cost");
            abilityOneDisabledDesc = abilityOneDisabled.Q<TextElement>("description");

            abilityTwo = supportBarContainer.Query<VisualElement>("ability-two");
            abilityTwoActive = abilityTwo.Query<VisualElement>("active");
            abilityTwoHover = abilityTwo.Query<VisualElement>("hover");
            abilityTwoDisabled = abilityTwo.Query<VisualElement>("disabled");
            abilityTwoActiveName = abilityTwoActive.Q<TextElement>("name");
            abilityTwoActiveCost = abilityTwoActive.Q<TextElement>("cost");
            abilityTwoActiveDesc = abilityTwoActive.Q<TextElement>("description");
            abilityTwoHoverName = abilityTwoHover.Q<TextElement>("name");
            abilityTwoHoverCost = abilityTwoHover.Q<TextElement>("cost");
            abilityTwoHoverDesc = abilityTwoHover.Q<TextElement>("description");
            abilityTwoDisabledName = abilityTwoDisabled.Q<TextElement>("name");
            abilityTwoDisabledCost = abilityTwoDisabled.Q<TextElement>("cost");
            abilityTwoDisabledDesc = abilityTwoDisabled.Q<TextElement>("description");

            abilityThree = supportBarContainer.Query<VisualElement>("ability-three");
            abilityThreeActive = abilityThree.Query<VisualElement>("active");
            abilityThreeHover = abilityThree.Query<VisualElement>("hover");
            abilityThreeDisabled = abilityThree.Query<VisualElement>("disabled");
            abilityThreeActiveName = abilityThreeActive.Q<TextElement>("name");
            abilityThreeActiveCost = abilityThreeActive.Q<TextElement>("cost");
            abilityThreeActiveDesc = abilityThreeActive.Q<TextElement>("description");
            abilityThreeHoverName = abilityThreeHover.Q<TextElement>("name");
            abilityThreeHoverCost = abilityThreeHover.Q<TextElement>("cost");
            abilityThreeHoverDesc = abilityThreeHover.Q<TextElement>("description");
            abilityThreeDisabledName = abilityThreeDisabled.Q<TextElement>("name");
            abilityThreeDisabledCost = abilityThreeDisabled.Q<TextElement>("cost");
            abilityThreeDisabledDesc = abilityThreeDisabled.Q<TextElement>("description");

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
