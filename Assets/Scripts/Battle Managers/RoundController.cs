using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : Listener
{
    public static RoundController main;
    public static Phase phase;
    private int numUnitsUsed;
    public Unit unitSwitched;
    public Unit unitUsed;
    [SerializeField]
    private bool DEBUG_NextPhase;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TEST_StartBattle", 0.1f);
    }
    void TEST_StartBattle()
    {
        MenuEvents.BattleStartSelected();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)) MenuEvents.BattleStartSelected(); //Start battle button
        if(Input.GetKeyDown(KeyCode.F2)) GameEvents.UseAbility(FieldController.main.GetUnit(FieldController.Position.Vanguard, true), FieldController.main.GetUnit(FieldController.Position.Vanguard, false), 1); //Use vanguard ability
        if(Input.GetKeyDown(KeyCode.F3)) MenuEvents.QTETriggered(); //QTE Triggered
        if(Input.GetKeyDown(KeyCode.Space)) Debug.Log(phase);
        if(DEBUG_NextPhase)
        {
            GameEvents.SetPhase();
            DEBUG_NextPhase = false;
        }
    }

    void ChooseAttack()
    {
        phase = Phase.PlayerVanguard;
    }

    void SwapSupport(QTEController.QTEResult QTEResult)
    {
        GameEvents.SetPhase(Phase.NextPhase);
    }
    void SwapSupport(Unit unit)
    {
        Debug.Log("c");
        GameEvents.SetPhase(Phase.NextPhase);
    }

    public static void SetPhase(Phase _phase)
    {
        if(((int)phase)%2 == 1) FieldController.main.ActivateKill();
        Debug.LogWarning("this should happen third" + FieldController.main.GetUnit(FieldController.Position.Vanguard, true));
        if(!FieldController.main.GetUnit(FieldController.Position.Vanguard, true)) Debug.LogError("It works");
        if(_phase == Phase.NextPhase) phase++;
        else phase = _phase;
        if(((int)phase) >= 6) {phase = Phase.PlayerVanguard; Debug.Log("reached last phase, cycling back");}

        //if(phase == Phase.EnemyVangaurd) GameEvents.QTEStart(QTEController.QTEType.shrinkingCircle, 1);
    }

    void PhaseSwitchAbilityUsed(Unit caster, Unit target, int abilityNumber)
    {
        if(phase == Phase.PlayerVanguard) GameEvents.QTEStart(QTEController.QTEType.shrinkingCircle, 1);
    }

    protected override void SubscribeListeners()
    {
        //throw new System.NotImplementedException();
    }

    protected override void UnsubscribeListeners()
    {
        //throw new System.NotImplementedException();
    }

    public bool IsCurrentRoundPlayer()
    {
        return true;
    }

    private void Awake()
    {
        main = this;
    }

    public enum Phase
    {
        PlayerVanguard,
        EnemyVangaurd,
        PlayerSwap,
        EnemySwap,
        PlayerSupport,
        EnemySupport,
        NextPhase
    }
}
