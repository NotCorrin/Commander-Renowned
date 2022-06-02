using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

struct AbilityButton
{
    public VisualElement ability, active, hover, disabled;
    public TextElement activeName, activeCost, activeDesc, activeOperation;
    public VisualElement activeManaIcon, activeAmmoIcon;
    public TextElement hoverName, hoverCost, hoverDesc, hoverOperation;
    public VisualElement hoverManaIcon, hoverAmmoIcon;
    public TextElement disabledName, disabledCost, disabledDesc, disabledOperation;
    public VisualElement disabledManaIcon, disabledAmmoIcon;
}

public class ActionbarUI : Listener
{
    #region variables
    [Header("Prompt Bar")]
    [SerializeField] private GameObject promptBar;
    [SerializeField] private UIDocument promptBarUIDocument;
    private VisualElement promptBarContainer;
    private TextElement promptBarValue;
    private VisualElement promptCancel;

    [Header("Support Bar")]
    [SerializeField] private GameObject supportBar;
    [SerializeField] private UIDocument supportBarUIDocument;
    private VisualElement supportBarContainer;
    private AbilityButton abilityOne;
    private AbilityButton abilityTwo;
    private AbilityButton abilityThree;
    private VisualElement endSupportTurnBtn;

    [Header("Switch Bar")]
    [SerializeField] private GameObject switchBar;
    [SerializeField] private UIDocument switchBarUIDocument;
    private VisualElement switchBarContainer;
    private VisualElement switchConfirmPanel;
    private VisualElement switchEndPanelContainer;
    private VisualElement switchEndPanel;

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
        promptCancel.RegisterCallback<MouseEnterEvent>(OnPromptCancel_Hover);
        promptCancel.RegisterCallback<MouseLeaveEvent>(OnPromptCancel_Unhover);
        promptCancel.RegisterCallback<ClickEvent>(OnPromptCancel_Clicked);


        abilityOne.ability.RegisterCallback<MouseEnterEvent>(AbilityOne_Hover);
        abilityOne.ability.RegisterCallback<MouseLeaveEvent>(AbilityOne_Unhover);
        abilityOne.ability.RegisterCallback<ClickEvent>(AbilityOne_Clicked);

        abilityTwo.ability.RegisterCallback<MouseEnterEvent>(AbilityTwo_Hover);
        abilityTwo.ability.RegisterCallback<MouseLeaveEvent>(AbilityTwo_Unhover);
        abilityTwo.ability.RegisterCallback<ClickEvent>(AbilityTwo_Clicked);

        abilityThree.ability.RegisterCallback<MouseEnterEvent>(AbilityThree_Hover);
        abilityThree.ability.RegisterCallback<MouseLeaveEvent>(AbilityThree_Unhover);
        abilityThree.ability.RegisterCallback<ClickEvent>(AbilityThree_Clicked);

        endSupportTurnBtn.RegisterCallback<MouseEnterEvent>(EndSupportTurn_Hover);
        endSupportTurnBtn.RegisterCallback<MouseLeaveEvent>(EndSupportTurn_Unhover);
        endSupportTurnBtn.RegisterCallback<ClickEvent>(EndSupportTurn_Clicked);

        switchConfirmPanel.RegisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover, switchConfirmPanel);
        switchConfirmPanel.RegisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover, switchConfirmPanel);
        switchConfirmPanel.RegisterCallback<ClickEvent>(SwitchConfirm_Clicked);

        switchEndPanel.RegisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover, switchEndPanel);
        switchEndPanel.RegisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover, switchEndPanel);
        switchEndPanel.RegisterCallback<ClickEvent>(SwitchEnd_Clicked);

        UIEvents.onUnitSelected += OnUnitSelected;
        GameEvents.onPhaseChanged += PhaseSwitchUI;
        GameEvents.onAbilityResolved += AbilityUsed;
        //GameEvents.onKill += SwitchPrompt;
    }

    protected override void UnsubscribeListeners()
    {
        promptCancel.UnregisterCallback<MouseEnterEvent>(OnPromptCancel_Hover);
        promptCancel.UnregisterCallback<MouseLeaveEvent>(OnPromptCancel_Unhover);
        promptCancel.UnregisterCallback<ClickEvent>(OnPromptCancel_Clicked);

        abilityOne.ability.UnregisterCallback<MouseEnterEvent>(AbilityOne_Hover);
        abilityOne.ability.UnregisterCallback<MouseLeaveEvent>(AbilityOne_Unhover);
        abilityOne.ability.UnregisterCallback<ClickEvent>(AbilityOne_Clicked);

        abilityTwo.ability.UnregisterCallback<MouseEnterEvent>(AbilityTwo_Hover);
        abilityTwo.ability.UnregisterCallback<MouseLeaveEvent>(AbilityTwo_Unhover);
        abilityTwo.ability.UnregisterCallback<ClickEvent>(AbilityTwo_Clicked);

        abilityThree.ability.UnregisterCallback<MouseEnterEvent>(AbilityThree_Hover);
        abilityThree.ability.UnregisterCallback<MouseLeaveEvent>(AbilityThree_Unhover);
        abilityThree.ability.UnregisterCallback<ClickEvent>(AbilityThree_Clicked);

        endSupportTurnBtn.UnregisterCallback<MouseEnterEvent>(EndSupportTurn_Hover);
        endSupportTurnBtn.UnregisterCallback<MouseLeaveEvent>(EndSupportTurn_Unhover);
        endSupportTurnBtn.UnregisterCallback<ClickEvent>(EndSupportTurn_Clicked);

        switchConfirmPanel.UnregisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover);
        switchConfirmPanel.UnregisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover);
        switchConfirmPanel.UnregisterCallback<ClickEvent>(SwitchConfirm_Clicked);

        switchEndPanel.UnregisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover);
        switchEndPanel.UnregisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover);
        switchEndPanel.UnregisterCallback<ClickEvent>(SwitchEnd_Clicked);

        UIEvents.onUnitSelected -= OnUnitSelected;
        GameEvents.onPhaseChanged -= PhaseSwitchUI;
        GameEvents.onAbilityResolved -= AbilityUsed;
        //GameEvents.onKill -= SwitchPrompt;
    }

    void SwitchConfirm_Clicked(ClickEvent evt)
    {
        AudioManager.instance.Play("OnMousePressed");
        Debug.Log("Switch Button Clicked");
        if (RoundController.phase == RoundController.Phase.PlayerSwap)
        {
            if (selectedUnit)
            {
                if (FieldController.main.IsUnitPlayer(SceneController.main.selectedUnit)) FieldController.main.SwapPlayerUnit();
            }
            else
            {
                switchBarContainer.style.display = DisplayStyle.None;
                promptBarContainer.style.display = DisplayStyle.Flex;
                prompt = "Switch";
                promptBarValue.text = "Select unit to swap into vanguard position";
            }
        }
        else Debug.Log("Player cannot swap right now!");
    }

    void SwitchEnd_Clicked(ClickEvent evt)
    {
        AudioManager.instance.Play("OnMousePressed");
        Debug.Log("End Switch Turn Button Clicked");
        if (RoundController.phase == RoundController.Phase.PlayerSwap) GameEvents.EndPhase();
        else Debug.Log("Player does not have priority right now!");
    }

    void Switch_Hover(MouseEnterEvent evt, VisualElement element)
    {
        AudioManager.instance.Play("OnMouseHover");
        element.style.width = new Length(100, LengthUnit.Percent);
        element.style.height = new Length(100, LengthUnit.Percent);
    }

    void Switch_Unhover(MouseLeaveEvent evt, VisualElement element)
    {
        element.style.width = new Length(94, LengthUnit.Percent);
        element.style.height = new Length(94, LengthUnit.Percent);
    }

    void OnPromptCancel_Clicked(ClickEvent evt)
    {
        prompt = "";
        AudioManager.instance.Play("OnMouseHover");

        if(RoundController.phase == RoundController.Phase.PlayerSwap) switchBarContainer.style.display = DisplayStyle.Flex;
        else supportBarContainer.style.display = DisplayStyle.Flex;

        promptBarContainer.style.display = DisplayStyle.None;
        GameEvents.GreyOut(null, false);
        Debug.Log("Prompt Cancel Clicked");
    }

    void OnPromptCancel_Hover(MouseEnterEvent evt)
    {
        if (RoundController.phase == RoundController.Phase.PlayerVanguard || RoundController.phase == RoundController.Phase.PlayerSupport)
        {
            AudioManager.instance.Play("OnMouseHover");
            promptCancel.style.width = new Length(92, LengthUnit.Percent);
            promptCancel.style.height = new Length(59, LengthUnit.Percent);
        }
    }

    void OnPromptCancel_Unhover(MouseLeaveEvent evt)
    {
        promptCancel.style.width = new Length(80, LengthUnit.Percent);
        promptCancel.style.height = new Length(42, LengthUnit.Percent);
    }

    void AbilityOne_Hover(MouseEnterEvent evt)
    {
        if (abilityActive[0])
        {
            AudioManager.instance.Play("OnMouseHover");
            
            abilityOne.hover.style.height = new Length(100, LengthUnit.Percent);
            abilityOne.active.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    void AbilityOne_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[0])
        {
            abilityOne.hover.style.height = new Length(0, LengthUnit.Percent);
            abilityOne.active.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    void AbilityOne_Clicked(ClickEvent evt)
    {
        if (abilityActive[0])
        {
            UseAbility(1);
            AudioManager.instance.Play("OnMousePressed");
            abilityOne.hover.style.height = new Length(0, LengthUnit.Percent);
            abilityOne.active.style.height = new Length(100, LengthUnit.Percent);
            Debug.Log("Ability One Button Clicked");
        }
    }

    void AbilityTwo_Hover(MouseEnterEvent evt)
    {
        if (abilityActive[1])
        {
            AudioManager.instance.Play("OnMouseHover");
            abilityTwo.hover.style.height = new Length(100, LengthUnit.Percent);
            abilityTwo.active.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    void AbilityTwo_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[1])
        {
            abilityTwo.hover.style.height = new Length(0, LengthUnit.Percent);
            abilityTwo.active.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    void AbilityTwo_Clicked(ClickEvent evt)
    {
        if (abilityActive[1])
        {
            UseAbility(2);
            AudioManager.instance.Play("OnMousePressed");
            abilityTwo.hover.style.height = new Length(0, LengthUnit.Percent);
            abilityTwo.active.style.height = new Length(100, LengthUnit.Percent);
            Debug.Log("Ability Two Button Clicked");
        }
    }

    void AbilityThree_Hover(MouseEnterEvent evt)
    {
        if (abilityActive[2])
        {
            AudioManager.instance.Play("OnMouseHover");
            abilityThree.hover.style.height = new Length(100, LengthUnit.Percent);
            abilityThree.active.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    void AbilityThree_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[2])
        {
            abilityThree.hover.style.height = new Length(0, LengthUnit.Percent);
            abilityThree.active.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    void AbilityThree_Clicked(ClickEvent evt)
    {
        if (abilityActive[2])
        {
            UseAbility(3);
            AudioManager.instance.Play("OnMousePressed");
            abilityThree.hover.style.height = new Length(0, LengthUnit.Percent);
            abilityThree.active.style.height = new Length(100, LengthUnit.Percent);
            Debug.Log("Ability Three Button Clicked");
        }
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
            Ability _ability = selectedUnit.SupportAbilities[_selectedAbility - 1];
            List<Unit> validTargets = FieldController.main.GetValidTargets(selectedUnit, _ability);
            if ((validTargets.Count == 1 || _ability.forceTarget == TargetMode.False) && _ability.forceTarget != TargetMode.True)
            {
                GameEvents.UseAbility(selectedUnit, validTargets[0], _selectedAbility);
            }
            else
            {
                supportBarContainer.style.display = DisplayStyle.None;
                promptBarContainer.style.display = DisplayStyle.Flex;
                prompt = "Ability";
                promptBarValue.text = "Select target for " + selectedUnit.SupportAbilities[_selectedAbility-1].AbilityName;
                selectedAbility = _selectedAbility;
                GameEvents.GreyOut(selectedUnit.SupportAbilities[_selectedAbility-1], FieldController.main.IsUnitPlayer(selectedUnit));
                return;
            }
        }
        OnUnitSelected(selectedUnit);
        //else GameEvents.UseAbility(selectedUnit, SceneController.main.selectedUnit, 3);
    }

    void EndSupportTurn_Hover(MouseEnterEvent evt)
    {
        if (RoundController.phase == RoundController.Phase.PlayerVanguard || RoundController.phase == RoundController.Phase.PlayerSupport)
        {
            AudioManager.instance.Play("OnMouseHover");
            endSupportTurnBtn.style.width = new Length(92, LengthUnit.Percent);
            endSupportTurnBtn.style.height = new Length(59, LengthUnit.Percent);
        }
    }

    void EndSupportTurn_Unhover(MouseLeaveEvent evt)
    {
        endSupportTurnBtn.style.width = new Length(80, LengthUnit.Percent);
        endSupportTurnBtn.style.height = new Length(42, LengthUnit.Percent);
    }

    void EndSupportTurn_Clicked(ClickEvent evt)
    {
        Debug.Log("End Support Turn Button Clicked");

        if (RoundController.phase == RoundController.Phase.PlayerVanguard || RoundController.phase == RoundController.Phase.PlayerSupport)
        {
            AudioManager.instance.Play("OnMousePressed");
            GameEvents.EndPhase();
        }
        else
        {
            Debug.Log("Player does not have priority right now!");
        }
    }

    void AbilityUsed(Unit unit)
    {
        FieldController.main.SupportUsed(unit);
        OnUnitSelected(unit);
        GameEvents.GreyOut(null, false);
    }
    void OnUnitSelected(Unit unit)
    {
        if(!unit) 
        {
            abilityOne.active.style.display = DisplayStyle.None;
            abilityOne.hover.style.display = DisplayStyle.None;
            abilityOne.disabled.style.display = DisplayStyle.None;

            abilityTwo.active.style.display = DisplayStyle.None;
            abilityTwo.hover.style.display = DisplayStyle.None;
            abilityTwo.disabled.style.display = DisplayStyle.None;

            abilityThree.active.style.display = DisplayStyle.None;
            abilityThree.hover.style.display = DisplayStyle.None;
            abilityThree.disabled.style.display = DisplayStyle.None;
            return;
        }
        //Debug.Log(unit.UnitName + " was selected");
        if (unit && prompt == "Switch")
        {
            if (SceneController.main.selectedUnit)
            {
                if (FieldController.main.IsUnitPlayer(SceneController.main.selectedUnit)) FieldController.main.SwapPlayerUnit();
            }
            prompt = "";
            return;
        }
        if (selectedUnit && unit)
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
            abilityOne.active.style.display = DisplayStyle.Flex;
            abilityOne.hover.style.display = DisplayStyle.Flex;
            abilityOne.disabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityOne.active.style.display = DisplayStyle.None;
            abilityOne.hover.style.display = DisplayStyle.None;
            abilityOne.disabled.style.display = DisplayStyle.Flex;
        }

        if (abilityActive[1])
        {
            abilityTwo.active.style.display = DisplayStyle.Flex;
            abilityTwo.hover.style.display = DisplayStyle.Flex;
            abilityTwo.disabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityTwo.active.style.display = DisplayStyle.None;
            abilityTwo.hover.style.display = DisplayStyle.None;
            abilityTwo.disabled.style.display = DisplayStyle.Flex;
        }

        if (abilityActive[2])
        {
            abilityThree.active.style.display = DisplayStyle.Flex;
            abilityThree.hover.style.display = DisplayStyle.Flex;
            abilityThree.disabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityThree.active.style.display = DisplayStyle.None;
            abilityThree.hover.style.display = DisplayStyle.None;
            abilityThree.disabled.style.display = DisplayStyle.Flex;
        }

        if(_abilities[0])
        {
            abilityOne.activeName.text = _abilities[0].AbilityName;
            abilityOne.activeCost.text = _abilities[0].xCost ? "X" : Mathf.Abs(_abilities[0].Cost) + "";
            abilityOne.activeDesc.text = _abilities[0].AbilityDescription;

            abilityOne.hoverName.text = _abilities[0].AbilityName;
            abilityOne.hoverCost.text = _abilities[0].xCost ? "X" : Mathf.Abs(_abilities[0].Cost) + "";
            abilityOne.hoverDesc.text = _abilities[0].AbilityDescription;

            abilityOne.disabledName.text = _abilities[0].AbilityName;
            abilityOne.disabledCost.text = _abilities[0].xCost ? "X" : Mathf.Abs(_abilities[0].Cost) + "";
            abilityOne.disabledDesc.text = _abilities[0].AbilityDescription;

            if (_abilities[0].Cost < 0)
            {
                abilityOne.activeOperation.text = "+";
                abilityOne.hoverOperation.text = "+";
                abilityOne.disabledOperation.text = "+";
            }
            else
            {
                abilityOne.activeOperation.text = "-";
                abilityOne.hoverOperation.text = "-";
                abilityOne.disabledOperation.text = "-";
            }

            if (_abilities[0].IsMagic)
            {
                abilityOne.activeAmmoIcon.style.display = DisplayStyle.None;
                abilityOne.hoverAmmoIcon.style.display = DisplayStyle.None;
                abilityOne.disabledAmmoIcon.style.display = DisplayStyle.None;

                abilityOne.activeManaIcon.style.display = DisplayStyle.Flex;
                abilityOne.hoverManaIcon.style.display = DisplayStyle.Flex;
                abilityOne.disabledManaIcon.style.display = DisplayStyle.Flex;
            }
            else
            {
                abilityOne.activeAmmoIcon.style.display = DisplayStyle.Flex;
                abilityOne.hoverAmmoIcon.style.display = DisplayStyle.Flex;
                abilityOne.disabledAmmoIcon.style.display = DisplayStyle.Flex;

                abilityOne.activeManaIcon.style.display = DisplayStyle.None;
                abilityOne.hoverManaIcon.style.display = DisplayStyle.None;
                abilityOne.disabledManaIcon.style.display = DisplayStyle.None;
            }
        }
        else
        {
            abilityOne.activeName.text = "";
            abilityOne.activeCost.text = "";
            abilityOne.activeDesc.text = "";
            abilityOne.activeOperation.text = "";

            abilityOne.hoverName.text = "";
            abilityOne.hoverCost.text = "";
            abilityOne.hoverDesc.text = "";
            abilityOne.hoverOperation.text = "";

            abilityOne.disabledName.text = "";
            abilityOne.disabledCost.text = "";
            abilityOne.disabledDesc.text = "";
            abilityOne.disabledOperation.text = "";

            abilityOne.activeAmmoIcon.style.display = DisplayStyle.None;
            abilityOne.hoverAmmoIcon.style.display = DisplayStyle.None;
            abilityOne.disabledAmmoIcon.style.display = DisplayStyle.None;

            abilityOne.activeManaIcon.style.display = DisplayStyle.None;
            abilityOne.hoverManaIcon.style.display = DisplayStyle.None;
            abilityOne.disabledManaIcon.style.display = DisplayStyle.None;
        }
        if(_abilities[1])
        {
            abilityTwo.activeName.text = _abilities[1].AbilityName;
            abilityTwo.activeCost.text = _abilities[1].xCost ? "X" : Mathf.Abs(_abilities[1].Cost) + "";
            abilityTwo.activeDesc.text = _abilities[1].AbilityDescription;

            abilityTwo.hoverName.text = _abilities[1].AbilityName;
            abilityTwo.hoverCost.text = _abilities[1].xCost ? "X" : Mathf.Abs(_abilities[1].Cost) + "";
            abilityTwo.hoverDesc.text = _abilities[1].AbilityDescription;

            abilityTwo.disabledName.text = _abilities[1].AbilityName;
            abilityTwo.disabledCost.text = _abilities[1].xCost ? "X" : Mathf.Abs(_abilities[1].Cost) + "";
            abilityTwo.disabledDesc.text = _abilities[1].AbilityDescription;

            if (_abilities[1].Cost < 0)
            {
                abilityTwo.activeOperation.text = "+";
                abilityTwo.hoverOperation.text = "+";
                abilityTwo.disabledOperation.text = "+";
            }
            else
            {
                abilityTwo.activeOperation.text = "-";
                abilityTwo.hoverOperation.text = "-";
                abilityTwo.disabledOperation.text = "-";
            }

            if (_abilities[1].IsMagic)
            {
                abilityTwo.activeAmmoIcon.style.display = DisplayStyle.None;
                abilityTwo.hoverAmmoIcon.style.display = DisplayStyle.None;
                abilityTwo.disabledAmmoIcon.style.display = DisplayStyle.None;

                abilityTwo.activeManaIcon.style.display = DisplayStyle.Flex;
                abilityTwo.hoverManaIcon.style.display = DisplayStyle.Flex;
                abilityTwo.disabledManaIcon.style.display = DisplayStyle.Flex;
            }
            else
            {
                abilityTwo.activeAmmoIcon.style.display = DisplayStyle.Flex;
                abilityTwo.hoverAmmoIcon.style.display = DisplayStyle.Flex;
                abilityTwo.disabledAmmoIcon.style.display = DisplayStyle.Flex;

                abilityTwo.activeManaIcon.style.display = DisplayStyle.None;
                abilityTwo.hoverManaIcon.style.display = DisplayStyle.None;
                abilityTwo.disabledManaIcon.style.display = DisplayStyle.None;
            }
        }
        else
        {
            abilityTwo.activeName.text = "";
            abilityTwo.activeCost.text = "";
            abilityTwo.activeDesc.text = "";
            abilityTwo.activeOperation.text = "";

            abilityTwo.hoverName.text = "";
            abilityTwo.hoverCost.text = "";
            abilityTwo.hoverDesc.text = "";
            abilityTwo.hoverOperation.text = "";

            abilityTwo.disabledName.text = "";
            abilityTwo.disabledCost.text = "";
            abilityTwo.disabledDesc.text = "";
            abilityTwo.disabledOperation.text = "";

            abilityTwo.activeAmmoIcon.style.display = DisplayStyle.None;
            abilityTwo.hoverAmmoIcon.style.display = DisplayStyle.None;
            abilityTwo.disabledAmmoIcon.style.display = DisplayStyle.None;

            abilityTwo.activeManaIcon.style.display = DisplayStyle.None;
            abilityTwo.hoverManaIcon.style.display = DisplayStyle.None;
            abilityTwo.disabledManaIcon.style.display = DisplayStyle.None;
        }
        if(_abilities[2])
        {
            abilityThree.activeName.text = _abilities[2].AbilityName;
            abilityThree.activeCost.text = _abilities[2].xCost ? "X" : Mathf.Abs(_abilities[2].Cost) + "";
            abilityThree.activeDesc.text = _abilities[2].AbilityDescription;

            abilityThree.hoverName.text = _abilities[2].AbilityName;
            abilityThree.hoverCost.text = _abilities[2].xCost ? "X" : Mathf.Abs(_abilities[2].Cost) + "";
            abilityThree.hoverDesc.text = _abilities[2].AbilityDescription;

            abilityThree.disabledName.text = _abilities[2].AbilityName;
            abilityThree.disabledCost.text = _abilities[2].xCost ? "X" : Mathf.Abs(_abilities[2].Cost) + "";
            abilityThree.disabledDesc.text = _abilities[2].AbilityDescription;

            if (_abilities[2].Cost < 0)
            {
                abilityThree.activeOperation.text = "+";
                abilityThree.hoverOperation.text = "+";
                abilityThree.disabledOperation.text = "+";
            }
            else
            {
                abilityThree.activeOperation.text = "-";
                abilityThree.hoverOperation.text = "-";
                abilityThree.disabledOperation.text = "-";
            }

            if (_abilities[2].IsMagic)
            {
                abilityThree.activeAmmoIcon.style.display = DisplayStyle.None;
                abilityThree.hoverAmmoIcon.style.display = DisplayStyle.None;
                abilityThree.disabledAmmoIcon.style.display = DisplayStyle.None;

                abilityThree.activeManaIcon.style.display = DisplayStyle.Flex;
                abilityThree.hoverManaIcon.style.display = DisplayStyle.Flex;
                abilityThree.disabledManaIcon.style.display = DisplayStyle.Flex;
            }
            else
            {
                abilityThree.activeAmmoIcon.style.display = DisplayStyle.Flex;
                abilityThree.hoverAmmoIcon.style.display = DisplayStyle.Flex;
                abilityThree.disabledAmmoIcon.style.display = DisplayStyle.Flex;

                abilityThree.activeManaIcon.style.display = DisplayStyle.None;
                abilityThree.hoverManaIcon.style.display = DisplayStyle.None;
                abilityThree.disabledManaIcon.style.display = DisplayStyle.None;
            }

            
        }
        else
        {
            abilityThree.activeName.text = "";
            abilityThree.activeCost.text = "";
            abilityThree.activeDesc.text = "";
            abilityThree.activeOperation.text = "";

            abilityThree.hoverName.text = "";
            abilityThree.hoverCost.text = "";
            abilityThree.hoverDesc.text = "";
            abilityThree.hoverOperation.text = "";

            abilityThree.disabledName.text = "";
            abilityThree.disabledCost.text = "";
            abilityThree.disabledDesc.text = "";
            abilityThree.disabledOperation.text = "";

            abilityThree.activeAmmoIcon.style.display = DisplayStyle.None;
            abilityThree.hoverAmmoIcon.style.display = DisplayStyle.None;
            abilityThree.disabledAmmoIcon.style.display = DisplayStyle.None;

            abilityThree.activeManaIcon.style.display = DisplayStyle.None;
            abilityThree.hoverManaIcon.style.display = DisplayStyle.None;
            abilityThree.disabledManaIcon.style.display = DisplayStyle.None;
        }
    }

    void PhaseSwitchUI(RoundController.Phase phase)
    {
        supportBarContainer.style.display = DisplayStyle.None;
        switchBarContainer.style.display = DisplayStyle.None;
        promptBarContainer.style.display = DisplayStyle.None;

        if (!FieldController.main.GetUnit(FieldController.Position.Vanguard, true))
        {
            switchEndPanelContainer.style.display = DisplayStyle.None;
            switchBarContainer.style.display = DisplayStyle.Flex;
            OnUnitSelected(selectedUnit);
            return;
        }
        else switchEndPanelContainer.style.display = DisplayStyle.Flex;

        switch (phase)
        {
            case RoundController.Phase.PlayerVanguard:
                supportBarContainer.style.display = DisplayStyle.Flex;
                UIEvents.UnitSelected(FieldController.main.GetUnit(FieldController.Position.Vanguard, true));
                break;
            case RoundController.Phase.EnemyVangaurd:
                supportBarContainer.style.display = DisplayStyle.Flex;
                break;
            case RoundController.Phase.PlayerSwap:
                switchBarContainer.style.display = DisplayStyle.Flex;
                selectedUnit = null;
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
            promptCancel = promptBarContainer.Query<VisualElement>("end-container");

            // Support Bar
            supportBarContainer = supportBarUIDocument.rootVisualElement.Query<VisualElement>("container");

            abilityOne.ability = supportBarContainer.Query<VisualElement>("ability-one");
            abilityOne.active = abilityOne.ability.Query<VisualElement>("active");
            abilityOne.hover = abilityOne.ability.Query<VisualElement>("hover");
            abilityOne.disabled = abilityOne.ability.Query<VisualElement>("disabled");
            abilityOne.activeName = abilityOne.active.Q<TextElement>("name");
            abilityOne.activeCost = abilityOne.active.Q<TextElement>("cost");
            abilityOne.activeDesc = abilityOne.active.Q<TextElement>("description");
            abilityOne.activeOperation = abilityOne.active.Q<TextElement>("op");
            abilityOne.activeAmmoIcon = abilityOne.active.Q<VisualElement>("ammo-icon");
            abilityOne.activeManaIcon = abilityOne.active.Q<VisualElement>("mana-icon");
            abilityOne.hoverName = abilityOne.hover.Q<TextElement>("name");
            abilityOne.hoverCost = abilityOne.hover.Q<TextElement>("cost");
            abilityOne.hoverDesc = abilityOne.hover.Q<TextElement>("description");
            abilityOne.hoverOperation = abilityOne.hover.Q<TextElement>("op");
            abilityOne.hoverAmmoIcon = abilityOne.hover.Q<VisualElement>("ammo-icon");
            abilityOne.hoverManaIcon = abilityOne.hover.Q<VisualElement>("mana-icon");
            abilityOne.disabledName = abilityOne.disabled.Q<TextElement>("name");
            abilityOne.disabledCost = abilityOne.disabled.Q<TextElement>("cost");
            abilityOne.disabledDesc = abilityOne.disabled.Q<TextElement>("description");
            abilityOne.disabledOperation = abilityOne.disabled.Q<TextElement>("op");
            abilityOne.disabledAmmoIcon = abilityOne.disabled.Q<VisualElement>("ammo-icon");
            abilityOne.disabledManaIcon = abilityOne.disabled.Q<VisualElement>("mana-icon");

            abilityTwo.ability = supportBarContainer.Query<VisualElement>("ability-two");
            abilityTwo.active = abilityTwo.ability.Query<VisualElement>("active");
            abilityTwo.hover = abilityTwo.ability.Query<VisualElement>("hover");
            abilityTwo.disabled = abilityTwo.ability.Query<VisualElement>("disabled");
            abilityTwo.activeName = abilityTwo.active.Q<TextElement>("name");
            abilityTwo.activeCost = abilityTwo.active.Q<TextElement>("cost");
            abilityTwo.activeDesc = abilityTwo.active.Q<TextElement>("description");
            abilityTwo.activeOperation = abilityTwo.active.Q<TextElement>("op");
            abilityTwo.activeAmmoIcon = abilityTwo.active.Q<VisualElement>("ammo-icon");
            abilityTwo.activeManaIcon = abilityTwo.active.Q<VisualElement>("mana-icon");
            abilityTwo.hoverName = abilityTwo.hover.Q<TextElement>("name");
            abilityTwo.hoverCost = abilityTwo.hover.Q<TextElement>("cost");
            abilityTwo.hoverDesc = abilityTwo.hover.Q<TextElement>("description");
            abilityTwo.hoverOperation = abilityTwo.hover.Q<TextElement>("op");
            abilityTwo.hoverAmmoIcon = abilityTwo.hover.Q<VisualElement>("ammo-icon");
            abilityTwo.hoverManaIcon = abilityTwo.hover.Q<VisualElement>("mana-icon");
            abilityTwo.disabledName = abilityTwo.disabled.Q<TextElement>("name");
            abilityTwo.disabledCost = abilityTwo.disabled.Q<TextElement>("cost");
            abilityTwo.disabledDesc = abilityTwo.disabled.Q<TextElement>("description");
            abilityTwo.disabledOperation = abilityTwo.disabled.Q<TextElement>("op");
            abilityTwo.disabledAmmoIcon = abilityTwo.disabled.Q<VisualElement>("ammo-icon");
            abilityTwo.disabledManaIcon = abilityTwo.disabled.Q<VisualElement>("mana-icon");

            abilityThree.ability = supportBarContainer.Query<VisualElement>("ability-three");
            abilityThree.active = abilityThree.ability.Query<VisualElement>("active");
            abilityThree.hover = abilityThree.ability.Query<VisualElement>("hover");
            abilityThree.disabled = abilityThree.ability.Query<VisualElement>("disabled");
            abilityThree.activeName = abilityThree.active.Q<TextElement>("name");
            abilityThree.activeCost = abilityThree.active.Q<TextElement>("cost");
            abilityThree.activeDesc = abilityThree.active.Q<TextElement>("description");
            abilityThree.activeOperation = abilityThree.active.Q<TextElement>("op");
            abilityThree.activeAmmoIcon = abilityThree.active.Q<VisualElement>("ammo-icon");
            abilityThree.activeManaIcon = abilityThree.active.Q<VisualElement>("mana-icon");
            abilityThree.hoverName = abilityThree.hover.Q<TextElement>("name");
            abilityThree.hoverCost = abilityThree.hover.Q<TextElement>("cost");
            abilityThree.hoverDesc = abilityThree.hover.Q<TextElement>("description");
            abilityThree.hoverOperation = abilityThree.hover.Q<TextElement>("op");
            abilityThree.hoverAmmoIcon = abilityThree.hover.Q<VisualElement>("ammo-icon");
            abilityThree.hoverManaIcon = abilityThree.hover.Q<VisualElement>("mana-icon");
            abilityThree.disabledName = abilityThree.disabled.Q<TextElement>("name");
            abilityThree.disabledCost = abilityThree.disabled.Q<TextElement>("cost");
            abilityThree.disabledDesc = abilityThree.disabled.Q<TextElement>("description");
            abilityThree.disabledOperation = abilityThree.disabled.Q<TextElement>("op");
            abilityThree.disabledAmmoIcon = abilityThree.disabled.Q<VisualElement>("ammo-icon");
            abilityThree.disabledManaIcon = abilityThree.disabled.Q<VisualElement>("mana-icon");

            endSupportTurnBtn = supportBarContainer.Query<VisualElement>("end-container");

            // Switch Bar
            switchBarContainer = switchBarUIDocument.rootVisualElement.Query<VisualElement>("container");

            switchConfirmPanel = switchBarContainer.Query<VisualElement>("switch");
            switchEndPanelContainer = switchBarContainer.Query<VisualElement>("skip-container");
            switchEndPanel = switchEndPanelContainer.Query<VisualElement>("skip");

        }
        catch
        {
            Debug.LogError($"{gameObject.name} : ActionbarUI - Element Query Failed.");
        }
    }
}
