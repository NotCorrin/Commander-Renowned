using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable SA1602 // EnumerationItemsMustBeDocumented

public class RoundController : Listener
{
    private static RoundController main;

    private static PhaseType phase;

    [SerializeField] private bool debugChangePhase;

    public enum PhaseType
    {
        PlayerVanguard,
        EnemyVangaurd,
        PlayerSwap,
        EnemySwap,
        PlayerSupport,
        EnemySupport,
    }

    public static PhaseType Phase => phase;

    public static bool IsPlayerPhase => ((int)Phase) % 2 == 0;

    public static RoundController Main => main;

    public static void SetPhase()
    {
        phase = (PhaseType)((int)(Phase + 1) % 6);
        GameEvents.PhaseChanged(Phase);
    }

    public bool IsCurrentRoundPlayer()
    {
        return (Phase == PhaseType.PlayerVanguard) || (Phase == PhaseType.PlayerSwap) || (Phase == PhaseType.PlayerSupport);
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

    private void Start()
    {
        Invoke("TEST_StartBattle", 0.1f);
    }

    private void TEST_StartBattle()
    {
        MenuEvents.BattleStartSelected();
    }

    private void Update()
    {
        // Debug Code
        if (debugChangePhase)
        {
            GameEvents.EndPhase();
            debugChangePhase = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Phase);
        }
    }

    private void ChooseAttack()
    {
        phase = PhaseType.PlayerVanguard;
    }

    private void ChangePhase()
    {
        if (RoundController.Phase == RoundController.PhaseType.PlayerVanguard || RoundController.Phase == RoundController.PhaseType.EnemyVangaurd)
        {
            GameEvents.ResetBuffs();
        }

        RoundController.SetPhase();
    }

    private void Awake()
    {
        main = this;
    }

    private void StartBattle()
    {
        phase = PhaseType.PlayerSwap;
        GameEvents.PhaseChanged(Phase);
    }
}

#pragma warning restore SA1602 // EnumerationItemsMustBeDocumented