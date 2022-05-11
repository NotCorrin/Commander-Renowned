using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : Listener
{
    public static RoundController main;
    public static Phase phase;
    public static bool isPlayerPhase => ((int)phase) % 2 == 0;
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
    {   //Debug Code
        /*if (Input.GetKeyDown(KeyCode.F1)) MenuEvents.BattleStartSelected(); //Start battle button
        if (Input.GetKeyDown(KeyCode.F2)) GameEvents.UseAbility(FieldController.main.GetUnit(FieldController.Position.Vanguard, true), FieldController.main.GetUnit(FieldController.Position.Vanguard, false), 1); //Use vanguard ability
        if (Input.GetKeyDown(KeyCode.F3)) MenuEvents.QTETriggered(); //QTE Triggered
        if (Input.GetKeyDown(KeyCode.Space)) Debug.Log(phase);
        if (DEBUG_NextPhase)
        {
            GameEvents.EndPhase();
            DEBUG_NextPhase = false;
        }*/
    }

    void ChooseAttack()
    {
        phase = Phase.PlayerVanguard;
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onBattleStarted += StartBattle;
        GameEvents.roundcontrollerEndPhase += ChangePhase;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onBattleStarted -= StartBattle;
        GameEvents.roundcontrollerEndPhase -= ChangePhase;
    }

    private void ChangePhase()
    {
        if (RoundController.phase == RoundController.Phase.PlayerVanguard || RoundController.phase == RoundController.Phase.EnemyVangaurd)
        {
            GameEvents.ResetBuffs();
        }

        RoundController.SetPhase(Phase.NextPhase);
    }
    
    public static void SetPhase(Phase _phase)
    {
        if (!isPlayerPhase) FieldController.main.ActivateKill();
        //Debug.LogWarning("this should happen third" + FieldController.main.GetUnit(FieldController.Position.Vanguard, true));
        //if(!FieldController.main.GetUnit(FieldController.Position.Vanguard, true)) Debug.LogError("It works");
        if (_phase == Phase.NextPhase) phase++;
        else phase = _phase;
        if (phase == Phase.NextPhase) { phase = Phase.PlayerVanguard; Debug.Log("reached last phase, cycling back"); }
        GameEvents.PhaseChanged(phase);
        //if(phase == Phase.EnemyVangaurd) GameEvents.QTEStart(QTEController.QTEType.shrinkingCircle, 1);
    }

    public bool IsCurrentRoundPlayer()
    {
        return true;
    }

    private void Awake()
    {
        main = this;
    }

    private void StartBattle()
    {
        //Debug.LogWarning("Battle Started");
        phase = Phase.PlayerVanguard;
        GameEvents.PhaseChanged(phase);
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
