using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable SA1602 // EnumerationItemsMustBeDocumented
#pragma warning disable SA1413 // UseTrailingCommasInMultiLineInitializers

public class FieldController : Listener
{
    private static FieldController main;

    [SerializeField] private Unit playerSupportLeft;
    [SerializeField] private Unit playerSupportRight;
    [SerializeField] private Unit playerVanguard;
    [SerializeField] private Vector3 playerVanguardPos;

    [SerializeField] private Unit enemySupportLeft;
    [SerializeField] private Unit enemySupportRight;
    [SerializeField] private Unit enemyVanguard;
    [SerializeField] private Vector3 enemyVanguardPos;

    private Unit[] allUnits;

    private SceneController sceneController;
    private Vector3 vanguardPos;
    private Vector3 selectedUnitPos;

    private Transform vanguardToSupport;
    private Transform supportToVanguard;
    private float timer;
    [SerializeField] private float maxTime = 0.5f;

    [SerializeField] private bool supportLeftUsed = false;
    [SerializeField] private bool supportRightUsed = false;

    public enum Position
    {
        Vanguard,
        SupportLeft,
        SupportRight
    }

    public static FieldController Main => main;

    private Vector3 PlayerVanguardPos
    {
        get
        {
            UpdatePlayerVanguardPos();

            return playerVanguardPos;
        }
    }

    private Vector3 EnemyVanguardPos
    {
        get
        {
            UpdateEnemyVanguardPos();

            return enemyVanguardPos;
        }
    }

    public void SupportUsed(Unit unit)
    {
        if (GetIsSupportLeft(unit))
        {
            /*
            *
            *
            *
            *
            *
            *
            *
            *
            *
            */
            supportLeftUsed = true;
        }

        if (GetIsSupportRight(unit))
        {
            supportRightUsed = true;
        }

        UIEvents.AllSupportUsed(supportLeftUsed && supportRightUsed);
    }

    public bool IsUnitPlayer(Unit unit)
    {
        return unit == playerVanguard || unit == playerSupportLeft || unit == playerSupportRight;
    }

    public List<Unit> GetAllies(Unit unit)
    {
        List<Unit> unitList = new List<Unit>();

        int checkRange = IsUnitPlayer(unit) ? 0 : 3;
        for (int i = 0; i < 3; i++)
        {
            if (allUnits[i])
            {
                unitList.Add(allUnits[i]);
            }
        }

        if (IsUnitPlayer(unit))
        {
            if (playerVanguard)
            {
                unitList.Add(playerVanguard);
            }

            if (playerSupportLeft)
            {
                unitList.Add(playerSupportLeft);
            }

            if (playerSupportRight)
            {
                unitList.Add(playerSupportRight);
            }
        }
        else
        {
            if (enemyVanguard)
            {
                unitList.Add(enemyVanguard);
            }

            if (enemySupportLeft)
            {
                unitList.Add(enemySupportLeft);
            }

            if (enemySupportRight)
            {
                unitList.Add(enemySupportRight);
            }
        }

        return unitList;
    }

    public bool IsUnitActive(Unit unit)
    {
        if ((unit == playerSupportLeft && supportLeftUsed) || (unit == playerSupportRight && supportRightUsed))
        {
            return false;
        }

        return (unit == playerSupportLeft && RoundController.Phase == RoundController.PhaseType.PlayerSupport)
        || (unit == playerSupportRight && RoundController.Phase == RoundController.PhaseType.PlayerSupport)
        || (unit == playerVanguard && RoundController.Phase == RoundController.PhaseType.PlayerVanguard)
        || (unit == enemySupportLeft && RoundController.Phase == RoundController.PhaseType.EnemySupport)
        || (unit == enemySupportRight && RoundController.Phase == RoundController.PhaseType.EnemySupport)
        || (unit == enemyVanguard && RoundController.Phase == RoundController.PhaseType.EnemyVangaurd);
    }

    public List<Unit> GetValidTargets(Unit caster, Ability ability)
    {
        if (!caster)
        {
            Debug.Log("No Caster wtf");
            return null;
        }

        if (!ability)
        {
            Debug.LogError("No ability wtf");
            return null;
        }

        List<Unit> unitList = new List<Unit>();

        foreach (Unit unit in allUnits)
        {
            if (!unit)
            {
                continue;
            }

            if (ability.IsAbilityValid(caster, unit))
            {
                unitList.Add(unit);
            }
        }

        return unitList;
    }

    public Unit GetUnit(Position position, bool isPlayer)
    {
        switch (position)
        {
            case Position.SupportLeft:
            {
                if (isPlayer)
                {
                    return playerSupportLeft;
                }

                return enemySupportLeft;
            }

            case Position.SupportRight:
            {
                if (isPlayer)
                {
                    return playerSupportRight;
                }

                return enemySupportRight;
            }

            default:
            {
                if (isPlayer)
                {
                    return playerVanguard;
                }

                return enemyVanguard;
            }
        }
    }

    public Position GetPosition(Unit unit)
    {
        if (GetIsSupportLeft(unit))
        {
            return Position.SupportLeft;
        }
        else if (GetIsSupportRight(unit))
        {
            return Position.SupportRight;
        }
        else
        {
            return Position.Vanguard;
        }
    }

    public bool GetIsVanguard(Unit unit) => unit == playerVanguard || unit == enemyVanguard;

    public bool GetIsSupportLeft(Unit unit) => unit == playerSupportLeft || unit == enemySupportLeft;

    public bool GetIsSupportRight(Unit unit) => unit == playerSupportRight || unit == enemySupportRight;

    public void SwapPlayerUnit(Unit chosenUnit = null)
    {
        if (!chosenUnit)
        {
            chosenUnit = sceneController.selectedUnit;
        }

        vanguardPos = PlayerVanguardPos;
        selectedUnitPos = chosenUnit.transform.position;

        if (playerVanguard)
        {
            vanguardToSupport = playerVanguard.transform;
        }
        else
        {
            vanguardToSupport = null;
        }

        supportToVanguard = chosenUnit.transform;
        timer = 0;

        // chosenUnit.transform.position = vanguardPos;
        // PlayerVanguard.transform.position = selectedUnitPos;
        if (GetIsSupportLeft(chosenUnit))
        {
            Unit temp = playerSupportLeft;
            playerSupportLeft = playerVanguard;
            playerVanguard = temp;

            // Debug.Log("Player Vanguard: " + PlayerVanguard.transform.position);
            // Debug.Log("Player Support Left: " + PlayerSupportLeft.transform.position);
            // Debug.Log("Player Support Right: " + PlayerSupportRight.transform.position);
        }
        else if (GetIsSupportRight(chosenUnit))
        {
            Unit temp = playerSupportRight;
            playerSupportRight = playerVanguard;
            playerVanguard = temp;

            // Debug.Log("Player Vanguard: " + PlayerVanguard.transform.position);
            // Debug.Log("Player Support Left: " + PlayerSupportLeft.transform.position);
            // Debug.Log("Player Support Right: " + PlayerSupportRight.transform.position);
        }
        else
        {
            Debug.Log("what the fuck where did the unit go");
        }
    }

    public void SwapEnemyUnit(Unit chosenUnit = null)
    {
        Debug.Log("swapping enemy units B)");
        if (!chosenUnit)
        {
            chosenUnit = sceneController.selectedUnit;
        }

        vanguardPos = EnemyVanguardPos;
        selectedUnitPos = chosenUnit.transform.position;

        if (enemyVanguard)
        {
            vanguardToSupport = enemyVanguard.transform;
        }
        else
        {
            vanguardToSupport = null;
        }

        supportToVanguard = chosenUnit.transform;
        timer = 0;

        // chosenUnit.transform.position = vanguardPos;
        // EnemyVanguard.transform.position = selectedUnitPos;
        if (GetIsSupportLeft(chosenUnit))
        {
            Unit temp = enemySupportLeft;
            enemySupportLeft = enemyVanguard;
            enemyVanguard = temp;

            // Debug.Log("Enemy Vanguard: " + PlayerVanguard.transform.position);
            // Debug.Log("Enemy Support Left: " + PlayerSupportLeft.transform.position);
            // Debug.Log("Enemy Support Right: " + PlayerSupportRight.transform.position);
        }
        else if (GetIsSupportRight(chosenUnit))
        {
            Unit temp = enemySupportRight;
            enemySupportRight = enemyVanguard;
            enemyVanguard = temp;

            // Debug.Log("Enemy Vanguard: " + PlayerVanguard.transform.position);
            // Debug.Log("Enemy Support Left: " + PlayerSupportLeft.transform.position);
            // Debug.Log("Enemy Support Right: " + PlayerSupportRight.transform.position);
        }

        // GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
    }

    public void EnemyVisual()
    {
        enemyVanguard.UpdateEnemyVisual();
        if (enemySupportLeft)
        {
            enemySupportLeft.UpdateEnemyVisual();
        }

        if (enemySupportRight)
        {
            enemySupportRight.UpdateEnemyVisual();
        }
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onPhaseChanged += ResetSupportUsed;
        GameEvents.onKill += Kill;
        GameEvents.OnSetupUnits += SetupUnits;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onPhaseChanged -= ResetSupportUsed;
        GameEvents.onKill -= Kill;
        GameEvents.OnSetupUnits += SetupUnits;
    }

    private void CheckValid(Unit caster, Ability ability, Unit unit, List<Unit> unitList)
    {
        if (ability.IsAbilityValid(caster, unit))
        {
            unitList.Add(unit);
        }
    }

    private void UpdatePlayerVanguardPos()
    {
        if (playerVanguard)
        {
            playerVanguardPos = playerVanguard.transform.position;
        }
    }

    private void UpdateEnemyVanguardPos()
    {
        if (enemyVanguard)
        {
            enemyVanguardPos = enemyVanguard.transform.position;
        }
    }

    private void SetupUnits(List<Unit> playerUnits, List<Unit> enemyUnits)
    {
        playerVanguard = playerUnits[0];
        playerSupportLeft = playerUnits[1];
        playerSupportRight = playerUnits[2];
        enemyVanguard = enemyUnits[0];
        enemySupportLeft = enemyUnits[1];
        enemySupportRight = enemyUnits[2];

        allUnits = new Unit[] { playerVanguard, playerSupportLeft, playerSupportRight, enemyVanguard, enemySupportLeft, enemySupportRight };

        UpdatePlayerVanguardPos();
        UpdateEnemyVanguardPos();

        EnemyVisual();
    }

    private void Start()
    {
        sceneController = GetComponent<SceneController>();
        timer = maxTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && RoundController.Phase == RoundController.PhaseType.PlayerSwap)
        {
            SwapPlayerUnit();
        }

        if (timer < maxTime)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                timer = maxTime;
                GameEvents.EndPhase();
                LerpSwap();
                UpdatePlayerVanguardPos();
                UpdateEnemyVanguardPos();
            }
            else
            {
                LerpSwap();
            }
        }
    }

    private void LerpSwap()
    {
        if (vanguardToSupport)
        {
            vanguardToSupport.position = Vector3.Lerp(vanguardPos, selectedUnitPos, timer / maxTime);
        }

        if (supportToVanguard)
        {
            supportToVanguard.position = Vector3.Lerp(selectedUnitPos, vanguardPos, timer / maxTime);
        }
    }

    private void Kill(Unit unit)
    {
        if (unit == playerSupportLeft)
        {
            playerSupportLeft = null;
        }

        if (unit == playerSupportRight)
        {
            playerSupportRight = null;
        }

        if (unit == playerVanguard)
        {
            playerVanguard = null;
        }

        if (unit == enemySupportLeft)
        {
            enemySupportLeft = null;
        }

        if (unit == enemySupportRight)
        {
            enemySupportRight = null;
        }

        if (unit == enemyVanguard)
        {
            enemyVanguard = null;
        }

        if (!playerSupportLeft && !playerSupportRight && !playerVanguard)
        {
            GameEvents.GameEnd(false);
        }
        else if (!enemySupportLeft && !enemySupportRight && !enemyVanguard)
        {
            GameEvents.GameEnd(true);
        }

        UIEvents.UnitSelected(null);

        // https://i.kym-cdn.com/entries/icons/original/000/034/833/snapchat_kill.jpg
    }

    private void ResetSupportUsed(RoundController.PhaseType phase)
    {
        supportLeftUsed = false;
        supportRightUsed = false;

        if (RoundController.IsPlayerPhase)
        {
            supportLeftUsed = !playerSupportLeft;
            supportRightUsed = !playerSupportRight;
        }

        if (phase != RoundController.PhaseType.PlayerSupport)
        {
            UIEvents.AllSupportUsed(false);
        }
    }

    private void Awake()
    {
        main = this;
    }
}

#pragma warning restore SA1602 // EnumerationItemsMustBeDocumented
#pragma warning restore SA1413 // UseTrailingCommasInMultiLineInitializers