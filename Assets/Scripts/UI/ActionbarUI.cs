using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Contains code for the actionbar.
/// </summary>
public class ActionbarUI : UISubscriber
{
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
    private string prompt = string.Empty;

    private bool[] abilityActive = new bool[3];

    /// <summary>
    /// Subscribes ActionbarUI UIElements to events.
    /// </summary>
    protected override void SubscribeCallbacks()
    {
        promptCancel.RegisterCallback<MouseEnterEvent>(OnPromptCancel_Hover);
        promptCancel.RegisterCallback<MouseLeaveEvent>(OnPromptCancel_Unhover);
        promptCancel.RegisterCallback<ClickEvent>(OnPromptCancel_Clicked);

        abilityOne.Ability.RegisterCallback<MouseEnterEvent>(AbilityOne_Hover);
        abilityOne.Ability.RegisterCallback<MouseLeaveEvent>(AbilityOne_Unhover);
        abilityOne.Ability.RegisterCallback<ClickEvent>(AbilityOne_Clicked);

        abilityTwo.Ability.RegisterCallback<MouseEnterEvent>(AbilityTwo_Hover);
        abilityTwo.Ability.RegisterCallback<MouseLeaveEvent>(AbilityTwo_Unhover);
        abilityTwo.Ability.RegisterCallback<ClickEvent>(AbilityTwo_Clicked);

        abilityThree.Ability.RegisterCallback<MouseEnterEvent>(AbilityThree_Hover);
        abilityThree.Ability.RegisterCallback<MouseLeaveEvent>(AbilityThree_Unhover);
        abilityThree.Ability.RegisterCallback<ClickEvent>(AbilityThree_Clicked);

        endSupportTurnBtn.RegisterCallback<MouseEnterEvent>(EndSupportTurn_Hover);
        endSupportTurnBtn.RegisterCallback<MouseLeaveEvent>(EndSupportTurn_Unhover);
        endSupportTurnBtn.RegisterCallback<ClickEvent>(EndSupportTurn_Clicked);

        switchConfirmPanel.RegisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover, switchConfirmPanel);
        switchConfirmPanel.RegisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover, switchConfirmPanel);
        switchConfirmPanel.RegisterCallback<ClickEvent>(SwitchConfirm_Clicked);

        switchEndPanel.RegisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover, switchEndPanel);
        switchEndPanel.RegisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover, switchEndPanel);
        switchEndPanel.RegisterCallback<ClickEvent>(SwitchEnd_Clicked);
    }

    /// <summary>
    /// Unsubscribes ActionbarUI UIElements from events.
    /// </summary>
    protected override void UnsubscribeCallbacks()
    {
        promptCancel.UnregisterCallback<MouseEnterEvent>(OnPromptCancel_Hover);
        promptCancel.UnregisterCallback<MouseLeaveEvent>(OnPromptCancel_Unhover);
        promptCancel.UnregisterCallback<ClickEvent>(OnPromptCancel_Clicked);

        abilityOne.Ability.UnregisterCallback<MouseEnterEvent>(AbilityOne_Hover);
        abilityOne.Ability.UnregisterCallback<MouseLeaveEvent>(AbilityOne_Unhover);
        abilityOne.Ability.UnregisterCallback<ClickEvent>(AbilityOne_Clicked);

        abilityTwo.Ability.UnregisterCallback<MouseEnterEvent>(AbilityTwo_Hover);
        abilityTwo.Ability.UnregisterCallback<MouseLeaveEvent>(AbilityTwo_Unhover);
        abilityTwo.Ability.UnregisterCallback<ClickEvent>(AbilityTwo_Clicked);

        abilityThree.Ability.UnregisterCallback<MouseEnterEvent>(AbilityThree_Hover);
        abilityThree.Ability.UnregisterCallback<MouseLeaveEvent>(AbilityThree_Unhover);
        abilityThree.Ability.UnregisterCallback<ClickEvent>(AbilityThree_Clicked);

        endSupportTurnBtn.UnregisterCallback<MouseEnterEvent>(EndSupportTurn_Hover);
        endSupportTurnBtn.UnregisterCallback<MouseLeaveEvent>(EndSupportTurn_Unhover);
        endSupportTurnBtn.UnregisterCallback<ClickEvent>(EndSupportTurn_Clicked);

        switchConfirmPanel.UnregisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover);
        switchConfirmPanel.UnregisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover);
        switchConfirmPanel.UnregisterCallback<ClickEvent>(SwitchConfirm_Clicked);

        switchEndPanel.UnregisterCallback<MouseEnterEvent, VisualElement>(Switch_Hover);
        switchEndPanel.UnregisterCallback<MouseLeaveEvent, VisualElement>(Switch_Unhover);
        switchEndPanel.UnregisterCallback<ClickEvent>(SwitchEnd_Clicked);
    }

    /// <summary>
    /// Subscribes ActionbarUI to events.
    /// </summary>
    protected override void SubscribeListeners()
    {
        UIEvents.onUnitSelected += OnUnitSelected;
        UIEvents.onAllSupportUsed += AllSupportUsed;
        GameEvents.onPhaseChanged += PhaseSwitchUI;
        GameEvents.onAbilityResolved += AbilityUsed;
        /* GameEvents.onKill += SwitchPrompt; */
    }

    /// <summary>
    /// Unsubscribes ActionbarUI to events.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        UIEvents.onUnitSelected -= OnUnitSelected;
        UIEvents.onAllSupportUsed -= AllSupportUsed;
        GameEvents.onPhaseChanged -= PhaseSwitchUI;
        GameEvents.onAbilityResolved -= AbilityUsed;
        /* GameEvents.onKill -= SwitchPrompt; */
    }

    private void Awake()
    {
        VerifyVariables();
        RunQueries();

        promptBarContainer.style.display = DisplayStyle.None;
        /* supportBarContainer.style.display = DisplayStyle.None; */
        switchBarContainer.style.display = DisplayStyle.None;
    }

    private void SwitchConfirm_Clicked(ClickEvent evt)
    {
        AudioManager.instance.Play("OnMousePressed");
        Debug.Log("Switch Button Clicked");
        if (RoundController.phase == RoundController.Phase.PlayerSwap)
        {
            if (selectedUnit)
            {
                if (FieldController.main.IsUnitPlayer(SceneController.main.selectedUnit))
                {
                    FieldController.main.SwapPlayerUnit();
                }
            }
            else
            {
                switchBarContainer.style.display = DisplayStyle.None;
                promptBarContainer.style.display = DisplayStyle.Flex;
                prompt = "Switch";
                promptBarValue.text = "Select unit to swap into vanguard position";
            }
        }
        else
        {
            Debug.Log("Player cannot swap right now!");
        }
    }

    private void SwitchEnd_Clicked(ClickEvent evt)
    {
        AudioManager.instance.Play("OnMousePressed");
        Debug.Log("End Switch Turn Button Clicked");
        if (RoundController.phase == RoundController.Phase.PlayerSwap)
        {
            GameEvents.EndPhase();
        }
        else
        {
            Debug.Log("Player does not have priority right now!");
        }
    }

    private void Switch_Hover(MouseEnterEvent evt, VisualElement element)
    {
        AudioManager.instance.Play("OnMouseHover");
        element.style.width = new Length(100, LengthUnit.Percent);
        element.style.height = new Length(100, LengthUnit.Percent);
    }

    private void Switch_Unhover(MouseLeaveEvent evt, VisualElement element)
    {
        element.style.width = new Length(94, LengthUnit.Percent);
        element.style.height = new Length(94, LengthUnit.Percent);
    }

    private void OnPromptCancel_Clicked(ClickEvent evt)
    {
        prompt = string.Empty;
        AudioManager.instance.Play("OnMouseHover");

        if (RoundController.phase == RoundController.Phase.PlayerSwap)
        {
            switchBarContainer.style.display = DisplayStyle.Flex;
        }
        else
        {
            supportBarContainer.style.display = DisplayStyle.Flex;
        }

        promptBarContainer.style.display = DisplayStyle.None;
        GameEvents.GreyOut(null, false);
        Debug.Log("Prompt Cancel Clicked");
    }

    private void OnPromptCancel_Hover(MouseEnterEvent evt)
    {
        if (RoundController.phase == RoundController.Phase.PlayerVanguard || RoundController.phase == RoundController.Phase.PlayerSupport)
        {
            AudioManager.instance.Play("OnMouseHover");
            promptCancel.style.width = new Length(92, LengthUnit.Percent);
            promptCancel.style.height = new Length(59, LengthUnit.Percent);
        }
    }

    private void OnPromptCancel_Unhover(MouseLeaveEvent evt)
    {
        promptCancel.style.width = new Length(80, LengthUnit.Percent);
        promptCancel.style.height = new Length(42, LengthUnit.Percent);
    }

    private void AbilityOne_Hover(MouseEnterEvent evt)
    {
        if (abilityActive[0])
        {
            AudioManager.instance.Play("OnMouseHover");

            abilityOne.Hover.style.height = new Length(100, LengthUnit.Percent);
            abilityOne.Active.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    private void AbilityOne_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[0])
        {
            abilityOne.Hover.style.height = new Length(0, LengthUnit.Percent);
            abilityOne.Active.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    private void AbilityOne_Clicked(ClickEvent evt)
    {
        if (abilityActive[0])
        {
            UseAbility(1);
            AudioManager.instance.Play("OnMousePressed");
            abilityOne.Hover.style.height = new Length(0, LengthUnit.Percent);
            abilityOne.Active.style.height = new Length(100, LengthUnit.Percent);
            Debug.Log("Ability One Button Clicked");
        }
    }

    private void AbilityTwo_Hover(MouseEnterEvent evt)
    {
        if (abilityActive[1])
        {
            AudioManager.instance.Play("OnMouseHover");
            abilityTwo.Hover.style.height = new Length(100, LengthUnit.Percent);
            abilityTwo.Active.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    private void AbilityTwo_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[1])
        {
            abilityTwo.Hover.style.height = new Length(0, LengthUnit.Percent);
            abilityTwo.Active.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    private void AbilityTwo_Clicked(ClickEvent evt)
    {
        if (abilityActive[1])
        {
            UseAbility(2);
            AudioManager.instance.Play("OnMousePressed");
            abilityTwo.Hover.style.height = new Length(0, LengthUnit.Percent);
            abilityTwo.Active.style.height = new Length(100, LengthUnit.Percent);
            Debug.Log("Ability Two Button Clicked");
        }
    }

    private void AbilityThree_Hover(MouseEnterEvent evt)
    {
        if (abilityActive[2])
        {
            AudioManager.instance.Play("OnMouseHover");
            abilityThree.Hover.style.height = new Length(100, LengthUnit.Percent);
            abilityThree.Active.style.height = new Length(0, LengthUnit.Percent);
        }
    }

    private void AbilityThree_Unhover(MouseLeaveEvent evt)
    {
        if (abilityActive[2])
        {
            abilityThree.Hover.style.height = new Length(0, LengthUnit.Percent);
            abilityThree.Active.style.height = new Length(100, LengthUnit.Percent);
        }
    }

    private void AbilityThree_Clicked(ClickEvent evt)
    {
        if (abilityActive[2])
        {
            UseAbility(3);
            AudioManager.instance.Play("OnMousePressed");
            abilityThree.Hover.style.height = new Length(0, LengthUnit.Percent);
            abilityThree.Active.style.height = new Length(100, LengthUnit.Percent);
            Debug.Log("Ability Three Button Clicked");
        }
    }

    private void UseAbility(int selectedAbility)
    {
        if (RoundController.phase == RoundController.Phase.PlayerVanguard)
        {
            if (!abilityActive[selectedAbility - 1])
            {
                return;
            }

            if (FieldController.main.IsUnitActive(selectedUnit))
            {
                GameEvents.UseAbility(
                    selectedUnit,
                    FieldController.main.GetUnit(FieldController.Position.Vanguard, !FieldController.main.IsUnitPlayer(selectedUnit)),
                    selectedAbility);
            }

            AbilityUI(selectedUnit, true);
            return;
        }
        else if (RoundController.phase == RoundController.Phase.PlayerSupport)
        {
            if (!abilityActive[selectedAbility - 1])
            {
                return;
            }

            Ability ability = selectedUnit.SupportAbilities[selectedAbility - 1];
            List<Unit> validTargets = FieldController.main.GetValidTargets(selectedUnit, ability);

            if ((validTargets.Count == 1 || ability.forceTarget == TargetMode.False) && ability.forceTarget != TargetMode.True)
            {
                GameEvents.UseAbility(selectedUnit, validTargets[0], selectedAbility);
            }
            else
            {
                supportBarContainer.style.display = DisplayStyle.None;
                promptBarContainer.style.display = DisplayStyle.Flex;
                prompt = "Ability";
                promptBarValue.text = "Select target for " + selectedUnit.SupportAbilities[selectedAbility - 1].AbilityName;
                this.selectedAbility = selectedAbility;
                GameEvents.GreyOut(selectedUnit.SupportAbilities[selectedAbility - 1], FieldController.main.IsUnitPlayer(selectedUnit));
                return;
            }
        }

        OnUnitSelected(selectedUnit);
    }

    private void EndSupportTurn_Hover(MouseEnterEvent evt)
    {
        if (RoundController.phase == RoundController.Phase.PlayerVanguard || RoundController.phase == RoundController.Phase.PlayerSupport)
        {
            AudioManager.instance.Play("OnMouseHover");
            endSupportTurnBtn.style.width = new Length(92, LengthUnit.Percent);
            endSupportTurnBtn.style.height = new Length(59, LengthUnit.Percent);
        }
    }

    private void EndSupportTurn_Unhover(MouseLeaveEvent evt)
    {
        endSupportTurnBtn.style.width = new Length(80, LengthUnit.Percent);
        endSupportTurnBtn.style.height = new Length(42, LengthUnit.Percent);
    }

    private void EndSupportTurn_Clicked(ClickEvent evt)
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

    private void AbilityUsed(Unit unit)
    {
        FieldController.main.SupportUsed(unit);
        OnUnitSelected(unit);
        GameEvents.GreyOut(null, false);
    }

    private void AllSupportUsed(bool supportUsed)
    {
        if (supportUsed)
        {
            endSupportTurnBtn.Q<VisualElement>("end-yellow").style.display = DisplayStyle.None;
            endSupportTurnBtn.Q<VisualElement>("end-red").style.display = DisplayStyle.Flex;
        }
        else
        {
            endSupportTurnBtn.Q<VisualElement>("end-yellow").style.display = DisplayStyle.Flex;
            endSupportTurnBtn.Q<VisualElement>("end-red").style.display = DisplayStyle.None;
        }
    }

    private void OnUnitSelected(Unit unit)
    {
        if (!unit)
        {
            abilityOne.Active.style.display = DisplayStyle.None;
            abilityOne.Hover.style.display = DisplayStyle.None;
            abilityOne.Disabled.style.display = DisplayStyle.None;

            abilityTwo.Active.style.display = DisplayStyle.None;
            abilityTwo.Hover.style.display = DisplayStyle.None;
            abilityTwo.Disabled.style.display = DisplayStyle.None;

            abilityThree.Active.style.display = DisplayStyle.None;
            abilityThree.Hover.style.display = DisplayStyle.None;
            abilityThree.Disabled.style.display = DisplayStyle.None;
            return;
        }

        /* Debug.Log(unit.UnitName + " was selected"); */
        if (unit && prompt == "Switch")
        {
            if (SceneController.main.selectedUnit)
            {
                if (FieldController.main.IsUnitPlayer(SceneController.main.selectedUnit))
                {
                    FieldController.main.SwapPlayerUnit();
                }
            }

            prompt = string.Empty;
            return;
        }

        if (selectedUnit && unit)
        {
            if (prompt == "Ability")
            {
                if (RoundController.phase != RoundController.Phase.PlayerSupport)
                {
                    prompt = string.Empty;
                }
                else if (selectedUnit.SupportAbilities[selectedAbility - 1].IsAbilityValid(selectedUnit, unit))
                {
                    Debug.Log("Caster = " + selectedUnit + "\n" + "Target = " + unit);
                    supportBarContainer.style.display = DisplayStyle.Flex;
                    promptBarContainer.style.display = DisplayStyle.None;
                    prompt = string.Empty;
                    GameEvents.UseAbility(selectedUnit, unit, selectedAbility);
                }

                return;
            }
            else if (prompt == "Death")
            {
                if (FieldController.main.IsUnitPlayer(unit) && !FieldController.main.GetIsVanguard(unit))
                {
                    supportBarContainer.style.display = DisplayStyle.Flex;
                    promptBarContainer.style.display = DisplayStyle.None;
                    prompt = string.Empty;
                    FieldController.main.SwapPlayerUnit(unit);
                }

                return;
            }
        }

        selectedUnit = unit;
        AbilityUI(unit);
    }

    private void AbilityUI(Unit unit, bool setAllFalse = false)
    {
        /* Debug.Log("Rendering abilities... "); */
        Ability[] abilities = FieldController.main.GetIsVanguard(unit) ? unit.VanguardAbilities : unit.SupportAbilities;

        for (int i = 0; i < abilities.Length; i++)
        {
            if (setAllFalse)
            {
                abilityActive[i] = false;
                continue;
            }

            if (!FieldController.main.IsUnitActive(unit)
            || abilities[i] == null)
            {
                abilityActive[i] = false;
                continue;
            }

            if (!abilities[i].IsCasterValid(unit))
            {
                abilityActive[i] = false;
                continue;
            }

            abilityActive[i] = true;
        }

        /* if (abilityActive[0]) abilityOneBtn.style.backgroundColor = new StyleColor(new Color(1, 1, 1, 0.69f));
        // else abilityOneBtn.style.backgroundColor = new StyleColor(new Color(0.364f, 0.364f, 0.364f, 0.69f)); */

        if (abilityActive[0])
        {
            abilityOne.Active.style.display = DisplayStyle.Flex;
            abilityOne.Hover.style.display = DisplayStyle.Flex;
            abilityOne.Disabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityOne.Active.style.display = DisplayStyle.None;
            abilityOne.Hover.style.display = DisplayStyle.None;
            abilityOne.Disabled.style.display = DisplayStyle.Flex;
        }

        if (abilityActive[1])
        {
            abilityTwo.Active.style.display = DisplayStyle.Flex;
            abilityTwo.Hover.style.display = DisplayStyle.Flex;
            abilityTwo.Disabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityTwo.Active.style.display = DisplayStyle.None;
            abilityTwo.Hover.style.display = DisplayStyle.None;
            abilityTwo.Disabled.style.display = DisplayStyle.Flex;
        }

        if (abilityActive[2])
        {
            abilityThree.Active.style.display = DisplayStyle.Flex;
            abilityThree.Hover.style.display = DisplayStyle.Flex;
            abilityThree.Disabled.style.display = DisplayStyle.None;
        }
        else
        {
            abilityThree.Active.style.display = DisplayStyle.None;
            abilityThree.Hover.style.display = DisplayStyle.None;
            abilityThree.Disabled.style.display = DisplayStyle.Flex;
        }

        if (abilities[0])
        {
            abilityOne.ActiveName.text = abilities[0].AbilityName;
            abilityOne.ActiveCost.text = abilities[0].xCost ? "X" : Mathf.Abs(abilities[0].Cost) + string.Empty;
            abilityOne.ActiveDesc.text = abilities[0].AbilityDescription;

            abilityOne.HoverName.text = abilities[0].AbilityName;
            abilityOne.HoverCost.text = abilities[0].xCost ? "X" : Mathf.Abs(abilities[0].Cost) + string.Empty;
            abilityOne.HoverDesc.text = abilities[0].AbilityDescription;

            abilityOne.DisabledName.text = abilities[0].AbilityName;
            abilityOne.DisabledCost.text = abilities[0].xCost ? "X" : Mathf.Abs(abilities[0].Cost) + string.Empty;
            abilityOne.DisabledDesc.text = abilities[0].AbilityDescription;

            if (abilities[0].Cost < 0)
            {
                abilityOne.ActiveOperation.text = "+";
                abilityOne.HoverOperation.text = "+";
                abilityOne.DisabledOperation.text = "+";
            }
            else
            {
                abilityOne.ActiveOperation.text = "-";
                abilityOne.HoverOperation.text = "-";
                abilityOne.DisabledOperation.text = "-";
            }

            if (abilities[0].IsMagic)
            {
                abilityOne.ActiveAmmoIcon.style.display = DisplayStyle.None;
                abilityOne.HoverAmmoIcon.style.display = DisplayStyle.None;
                abilityOne.DisabledAmmoIcon.style.display = DisplayStyle.None;

                abilityOne.ActiveManaIcon.style.display = DisplayStyle.Flex;
                abilityOne.HoverManaIcon.style.display = DisplayStyle.Flex;
                abilityOne.DisabledManaIcon.style.display = DisplayStyle.Flex;
            }
            else
            {
                abilityOne.ActiveAmmoIcon.style.display = DisplayStyle.Flex;
                abilityOne.HoverAmmoIcon.style.display = DisplayStyle.Flex;
                abilityOne.DisabledAmmoIcon.style.display = DisplayStyle.Flex;

                abilityOne.ActiveManaIcon.style.display = DisplayStyle.None;
                abilityOne.HoverManaIcon.style.display = DisplayStyle.None;
                abilityOne.DisabledManaIcon.style.display = DisplayStyle.None;
            }
        }
        else
        {
            abilityOne.ActiveName.text = string.Empty;
            abilityOne.ActiveCost.text = string.Empty;
            abilityOne.ActiveDesc.text = string.Empty;
            abilityOne.ActiveOperation.text = string.Empty;

            abilityOne.HoverName.text = string.Empty;
            abilityOne.HoverCost.text = string.Empty;
            abilityOne.HoverDesc.text = string.Empty;
            abilityOne.HoverOperation.text = string.Empty;

            abilityOne.DisabledName.text = string.Empty;
            abilityOne.DisabledCost.text = string.Empty;
            abilityOne.DisabledDesc.text = string.Empty;
            abilityOne.DisabledOperation.text = string.Empty;

            abilityOne.ActiveAmmoIcon.style.display = DisplayStyle.None;
            abilityOne.HoverAmmoIcon.style.display = DisplayStyle.None;
            abilityOne.DisabledAmmoIcon.style.display = DisplayStyle.None;

            abilityOne.ActiveManaIcon.style.display = DisplayStyle.None;
            abilityOne.HoverManaIcon.style.display = DisplayStyle.None;
            abilityOne.DisabledManaIcon.style.display = DisplayStyle.None;
        }

        if (abilities[1])
        {
            abilityTwo.ActiveName.text = abilities[1].AbilityName;
            abilityTwo.ActiveCost.text = abilities[1].xCost ? "X" : Mathf.Abs(abilities[1].Cost) + string.Empty;
            abilityTwo.ActiveDesc.text = abilities[1].AbilityDescription;

            abilityTwo.HoverName.text = abilities[1].AbilityName;
            abilityTwo.HoverCost.text = abilities[1].xCost ? "X" : Mathf.Abs(abilities[1].Cost) + string.Empty;
            abilityTwo.HoverDesc.text = abilities[1].AbilityDescription;

            abilityTwo.DisabledName.text = abilities[1].AbilityName;
            abilityTwo.DisabledCost.text = abilities[1].xCost ? "X" : Mathf.Abs(abilities[1].Cost) + string.Empty;
            abilityTwo.DisabledDesc.text = abilities[1].AbilityDescription;

            if (abilities[1].Cost < 0)
            {
                abilityTwo.ActiveOperation.text = "+";
                abilityTwo.HoverOperation.text = "+";
                abilityTwo.DisabledOperation.text = "+";
            }
            else
            {
                abilityTwo.ActiveOperation.text = "-";
                abilityTwo.HoverOperation.text = "-";
                abilityTwo.DisabledOperation.text = "-";
            }

            if (abilities[1].IsMagic)
            {
                abilityTwo.ActiveAmmoIcon.style.display = DisplayStyle.None;
                abilityTwo.HoverAmmoIcon.style.display = DisplayStyle.None;
                abilityTwo.DisabledAmmoIcon.style.display = DisplayStyle.None;

                abilityTwo.ActiveManaIcon.style.display = DisplayStyle.Flex;
                abilityTwo.HoverManaIcon.style.display = DisplayStyle.Flex;
                abilityTwo.DisabledManaIcon.style.display = DisplayStyle.Flex;
            }
            else
            {
                abilityTwo.ActiveAmmoIcon.style.display = DisplayStyle.Flex;
                abilityTwo.HoverAmmoIcon.style.display = DisplayStyle.Flex;
                abilityTwo.DisabledAmmoIcon.style.display = DisplayStyle.Flex;

                abilityTwo.ActiveManaIcon.style.display = DisplayStyle.None;
                abilityTwo.HoverManaIcon.style.display = DisplayStyle.None;
                abilityTwo.DisabledManaIcon.style.display = DisplayStyle.None;
            }
        }
        else
        {
            abilityTwo.ActiveName.text = string.Empty;
            abilityTwo.ActiveCost.text = string.Empty;
            abilityTwo.ActiveDesc.text = string.Empty;
            abilityTwo.ActiveOperation.text = string.Empty;

            abilityTwo.HoverName.text = string.Empty;
            abilityTwo.HoverCost.text = string.Empty;
            abilityTwo.HoverDesc.text = string.Empty;
            abilityTwo.HoverOperation.text = string.Empty;

            abilityTwo.DisabledName.text = string.Empty;
            abilityTwo.DisabledCost.text = string.Empty;
            abilityTwo.DisabledDesc.text = string.Empty;
            abilityTwo.DisabledOperation.text = string.Empty;

            abilityTwo.ActiveAmmoIcon.style.display = DisplayStyle.None;
            abilityTwo.HoverAmmoIcon.style.display = DisplayStyle.None;
            abilityTwo.DisabledAmmoIcon.style.display = DisplayStyle.None;

            abilityTwo.ActiveManaIcon.style.display = DisplayStyle.None;
            abilityTwo.HoverManaIcon.style.display = DisplayStyle.None;
            abilityTwo.DisabledManaIcon.style.display = DisplayStyle.None;
        }

        if (abilities[2])
        {
            abilityThree.ActiveName.text = abilities[2].AbilityName;
            abilityThree.ActiveCost.text = abilities[2].xCost ? "X" : Mathf.Abs(abilities[2].Cost) + string.Empty;
            abilityThree.ActiveDesc.text = abilities[2].AbilityDescription;

            abilityThree.HoverName.text = abilities[2].AbilityName;
            abilityThree.HoverCost.text = abilities[2].xCost ? "X" : Mathf.Abs(abilities[2].Cost) + string.Empty;
            abilityThree.HoverDesc.text = abilities[2].AbilityDescription;

            abilityThree.DisabledName.text = abilities[2].AbilityName;
            abilityThree.DisabledCost.text = abilities[2].xCost ? "X" : Mathf.Abs(abilities[2].Cost) + string.Empty;
            abilityThree.DisabledDesc.text = abilities[2].AbilityDescription;

            if (abilities[2].Cost < 0)
            {
                abilityThree.ActiveOperation.text = "+";
                abilityThree.HoverOperation.text = "+";
                abilityThree.DisabledOperation.text = "+";
            }
            else
            {
                abilityThree.ActiveOperation.text = "-";
                abilityThree.HoverOperation.text = "-";
                abilityThree.DisabledOperation.text = "-";
            }

            if (abilities[2].IsMagic)
            {
                abilityThree.ActiveAmmoIcon.style.display = DisplayStyle.None;
                abilityThree.HoverAmmoIcon.style.display = DisplayStyle.None;
                abilityThree.DisabledAmmoIcon.style.display = DisplayStyle.None;

                abilityThree.ActiveManaIcon.style.display = DisplayStyle.Flex;
                abilityThree.HoverManaIcon.style.display = DisplayStyle.Flex;
                abilityThree.DisabledManaIcon.style.display = DisplayStyle.Flex;
            }
            else
            {
                abilityThree.ActiveAmmoIcon.style.display = DisplayStyle.Flex;
                abilityThree.HoverAmmoIcon.style.display = DisplayStyle.Flex;
                abilityThree.DisabledAmmoIcon.style.display = DisplayStyle.Flex;

                abilityThree.ActiveManaIcon.style.display = DisplayStyle.None;
                abilityThree.HoverManaIcon.style.display = DisplayStyle.None;
                abilityThree.DisabledManaIcon.style.display = DisplayStyle.None;
            }
        }
        else
        {
            abilityThree.ActiveName.text = string.Empty;
            abilityThree.ActiveCost.text = string.Empty;
            abilityThree.ActiveDesc.text = string.Empty;
            abilityThree.ActiveOperation.text = string.Empty;

            abilityThree.HoverName.text = string.Empty;
            abilityThree.HoverCost.text = string.Empty;
            abilityThree.HoverDesc.text = string.Empty;
            abilityThree.HoverOperation.text = string.Empty;

            abilityThree.DisabledName.text = string.Empty;
            abilityThree.DisabledCost.text = string.Empty;
            abilityThree.DisabledDesc.text = string.Empty;
            abilityThree.DisabledOperation.text = string.Empty;

            abilityThree.ActiveAmmoIcon.style.display = DisplayStyle.None;
            abilityThree.HoverAmmoIcon.style.display = DisplayStyle.None;
            abilityThree.DisabledAmmoIcon.style.display = DisplayStyle.None;

            abilityThree.ActiveManaIcon.style.display = DisplayStyle.None;
            abilityThree.HoverManaIcon.style.display = DisplayStyle.None;
            abilityThree.DisabledManaIcon.style.display = DisplayStyle.None;
        }
    }

    private void PhaseSwitchUI(RoundController.Phase phase)
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
        else
        {
            switchEndPanelContainer.style.display = DisplayStyle.Flex;
        }

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

        /* endSupportTurnBtn.text = phase.ToString() + "\nEnd Phase"; */
    }

    private void VerifyVariables()
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

    private void RunQueries()
    {
        try
        {
            // Prompt Bar
            promptBarContainer = promptBarUIDocument.rootVisualElement.Query<VisualElement>("container");
            promptBarValue = promptBarContainer.Query<TextElement>("prompt");
            promptCancel = promptBarContainer.Query<VisualElement>("end-container");

            // Support Bar
            supportBarContainer = supportBarUIDocument.rootVisualElement.Query<VisualElement>("container");

            abilityOne.Ability = supportBarContainer.Query<VisualElement>("Ability-one");
            abilityOne.Active = abilityOne.Ability.Query<VisualElement>("Active");
            abilityOne.Hover = abilityOne.Ability.Query<VisualElement>("hover");
            abilityOne.Disabled = abilityOne.Ability.Query<VisualElement>("disabled");
            abilityOne.ActiveName = abilityOne.Active.Q<TextElement>("name");
            abilityOne.ActiveCost = abilityOne.Active.Q<TextElement>("cost");
            abilityOne.ActiveDesc = abilityOne.Active.Q<TextElement>("description");
            abilityOne.ActiveOperation = abilityOne.Active.Q<TextElement>("op");
            abilityOne.ActiveAmmoIcon = abilityOne.Active.Q<VisualElement>("ammo-icon");
            abilityOne.ActiveManaIcon = abilityOne.Active.Q<VisualElement>("mana-icon");
            abilityOne.HoverName = abilityOne.Hover.Q<TextElement>("name");
            abilityOne.HoverCost = abilityOne.Hover.Q<TextElement>("cost");
            abilityOne.HoverDesc = abilityOne.Hover.Q<TextElement>("description");
            abilityOne.HoverOperation = abilityOne.Hover.Q<TextElement>("op");
            abilityOne.HoverAmmoIcon = abilityOne.Hover.Q<VisualElement>("ammo-icon");
            abilityOne.HoverManaIcon = abilityOne.Hover.Q<VisualElement>("mana-icon");
            abilityOne.DisabledName = abilityOne.Disabled.Q<TextElement>("name");
            abilityOne.DisabledCost = abilityOne.Disabled.Q<TextElement>("cost");
            abilityOne.DisabledDesc = abilityOne.Disabled.Q<TextElement>("description");
            abilityOne.DisabledOperation = abilityOne.Disabled.Q<TextElement>("op");
            abilityOne.DisabledAmmoIcon = abilityOne.Disabled.Q<VisualElement>("ammo-icon");
            abilityOne.DisabledManaIcon = abilityOne.Disabled.Q<VisualElement>("mana-icon");

            abilityTwo.Ability = supportBarContainer.Query<VisualElement>("Ability-two");
            abilityTwo.Active = abilityTwo.Ability.Query<VisualElement>("Active");
            abilityTwo.Hover = abilityTwo.Ability.Query<VisualElement>("hover");
            abilityTwo.Disabled = abilityTwo.Ability.Query<VisualElement>("disabled");
            abilityTwo.ActiveName = abilityTwo.Active.Q<TextElement>("name");
            abilityTwo.ActiveCost = abilityTwo.Active.Q<TextElement>("cost");
            abilityTwo.ActiveDesc = abilityTwo.Active.Q<TextElement>("description");
            abilityTwo.ActiveOperation = abilityTwo.Active.Q<TextElement>("op");
            abilityTwo.ActiveAmmoIcon = abilityTwo.Active.Q<VisualElement>("ammo-icon");
            abilityTwo.ActiveManaIcon = abilityTwo.Active.Q<VisualElement>("mana-icon");
            abilityTwo.HoverName = abilityTwo.Hover.Q<TextElement>("name");
            abilityTwo.HoverCost = abilityTwo.Hover.Q<TextElement>("cost");
            abilityTwo.HoverDesc = abilityTwo.Hover.Q<TextElement>("description");
            abilityTwo.HoverOperation = abilityTwo.Hover.Q<TextElement>("op");
            abilityTwo.HoverAmmoIcon = abilityTwo.Hover.Q<VisualElement>("ammo-icon");
            abilityTwo.HoverManaIcon = abilityTwo.Hover.Q<VisualElement>("mana-icon");
            abilityTwo.DisabledName = abilityTwo.Disabled.Q<TextElement>("name");
            abilityTwo.DisabledCost = abilityTwo.Disabled.Q<TextElement>("cost");
            abilityTwo.DisabledDesc = abilityTwo.Disabled.Q<TextElement>("description");
            abilityTwo.DisabledOperation = abilityTwo.Disabled.Q<TextElement>("op");
            abilityTwo.DisabledAmmoIcon = abilityTwo.Disabled.Q<VisualElement>("ammo-icon");
            abilityTwo.DisabledManaIcon = abilityTwo.Disabled.Q<VisualElement>("mana-icon");

            abilityThree.Ability = supportBarContainer.Query<VisualElement>("Ability-three");
            abilityThree.Active = abilityThree.Ability.Query<VisualElement>("Active");
            abilityThree.Hover = abilityThree.Ability.Query<VisualElement>("hover");
            abilityThree.Disabled = abilityThree.Ability.Query<VisualElement>("disabled");
            abilityThree.ActiveName = abilityThree.Active.Q<TextElement>("name");
            abilityThree.ActiveCost = abilityThree.Active.Q<TextElement>("cost");
            abilityThree.ActiveDesc = abilityThree.Active.Q<TextElement>("description");
            abilityThree.ActiveOperation = abilityThree.Active.Q<TextElement>("op");
            abilityThree.ActiveAmmoIcon = abilityThree.Active.Q<VisualElement>("ammo-icon");
            abilityThree.ActiveManaIcon = abilityThree.Active.Q<VisualElement>("mana-icon");
            abilityThree.HoverName = abilityThree.Hover.Q<TextElement>("name");
            abilityThree.HoverCost = abilityThree.Hover.Q<TextElement>("cost");
            abilityThree.HoverDesc = abilityThree.Hover.Q<TextElement>("description");
            abilityThree.HoverOperation = abilityThree.Hover.Q<TextElement>("op");
            abilityThree.HoverAmmoIcon = abilityThree.Hover.Q<VisualElement>("ammo-icon");
            abilityThree.HoverManaIcon = abilityThree.Hover.Q<VisualElement>("mana-icon");
            abilityThree.DisabledName = abilityThree.Disabled.Q<TextElement>("name");
            abilityThree.DisabledCost = abilityThree.Disabled.Q<TextElement>("cost");
            abilityThree.DisabledDesc = abilityThree.Disabled.Q<TextElement>("description");
            abilityThree.DisabledOperation = abilityThree.Disabled.Q<TextElement>("op");
            abilityThree.DisabledAmmoIcon = abilityThree.Disabled.Q<VisualElement>("ammo-icon");
            abilityThree.DisabledManaIcon = abilityThree.Disabled.Q<VisualElement>("mana-icon");

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

    private struct AbilityButton
    {
        public VisualElement Ability;
        public VisualElement Active;
        public VisualElement Hover;
        public VisualElement Disabled;
        public TextElement ActiveName;
        public TextElement ActiveCost;
        public TextElement ActiveDesc;
        public TextElement ActiveOperation;
        public VisualElement ActiveManaIcon;
        public VisualElement ActiveAmmoIcon;
        public TextElement HoverName;
        public TextElement HoverCost;
        public TextElement HoverDesc;
        public TextElement HoverOperation;
        public VisualElement HoverManaIcon;
        public VisualElement HoverAmmoIcon;
        public TextElement DisabledName;
        public TextElement DisabledCost;
        public TextElement DisabledDesc;
        public TextElement DisabledOperation;
        public VisualElement DisabledManaIcon;
        public VisualElement DisabledAmmoIcon;
    }
}
