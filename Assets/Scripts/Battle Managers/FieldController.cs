using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : Listener
{
    public enum Position { Vanguard, SupportLeft, SupportRight };

    [SerializeField] Unit PlayerVanguard;
    [SerializeField] Unit PlayerSupportLeft;
    [SerializeField] Unit PlayerSupportRight;

    [SerializeField] Unit EnemyVanguard;
    [SerializeField] Unit EnemySupportLeft;
    [SerializeField] Unit EnemySupportRight;

    SceneController sceneController;
    Vector3 vanguardPos;
    Vector3 selectedUnitPos;
    
    Transform VanguardToSupport;
    Transform SupportToVanguard;
    float timer;
    public float maxTime = 0.5f;
    public static bool disableInput;
    List<Unit> deathNote = new List<Unit>();

    [SerializeField] bool supportLeftUsed = false;
    [SerializeField] bool supportRightUsed = false;

    public static FieldController main;
    // Start is called before the first frame update
    void SetupUnits(List<Unit> playerUnits, List<Unit> enemyUnits)
    {
        PlayerVanguard = playerUnits[0];
        PlayerSupportLeft = playerUnits[1];
        PlayerSupportRight = playerUnits[2];
        EnemyVanguard = enemyUnits[0];
        EnemySupportLeft = enemyUnits[1];
        EnemySupportRight = enemyUnits[2];

        this.enemyVisual();
    }
    void Start()
    {
        sceneController = GetComponent<SceneController>();
        timer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G) && RoundController.phase == RoundController.Phase.PlayerSwap) {
            SwapPlayerUnit();
        }
        if(timer < maxTime)
        {
            timer += Time.deltaTime;
            if(timer >= maxTime)
            {
                timer = maxTime;
                disableInput = false;
                GameEvents.SetPhase();
                Debug.Log(VanguardToSupport);
                Debug.Log(SupportToVanguard);
            }
            LerpSwap();
        }
    }

    private void LerpSwap()
    {
        VanguardToSupport.position = Vector3.Lerp(vanguardPos, selectedUnitPos, timer/maxTime);
        SupportToVanguard.position = Vector3.Lerp(selectedUnitPos, vanguardPos, timer/maxTime);        
    }

    public bool IsUnitPlayer(Unit unit)
    {
        return (unit == PlayerVanguard || unit == PlayerSupportLeft || unit == PlayerSupportRight);
    }

    public bool IsUnitActive(Unit unit)
    {
        if(unit == PlayerSupportLeft && supportLeftUsed || unit == PlayerSupportRight && supportRightUsed) return false;

        return (unit == PlayerSupportLeft && RoundController.phase == RoundController.Phase.PlayerSupport)
        || (unit == PlayerSupportRight && RoundController.phase == RoundController.Phase.PlayerSupport)
        || (unit == PlayerVanguard && RoundController.phase == RoundController.Phase.PlayerVanguard)
        || (unit == EnemySupportLeft && RoundController.phase == RoundController.Phase.EnemySupport)
        || (unit == EnemySupportRight && RoundController.phase == RoundController.Phase.EnemySupport)
        || (unit == EnemyVanguard && RoundController.phase == RoundController.Phase.EnemyVangaurd);
    }

    public List<Unit> GetValidTargets(Unit Caster, Ability ability)
    {
        if(!Caster) {Debug.Log("No Caster. wtf."); return null;}
        List<Unit> unitList = new List<Unit>();
        if(ability.IsAbilityValid(Caster, PlayerVanguard)) unitList.Add(PlayerVanguard);
        if(ability.IsAbilityValid(Caster, PlayerSupportLeft)) unitList.Add(PlayerSupportLeft);
        if(ability.IsAbilityValid(Caster, PlayerSupportRight)) unitList.Add(PlayerSupportRight);
        if(ability.IsAbilityValid(Caster, EnemyVanguard)) unitList.Add(EnemyVanguard);
        if(ability.IsAbilityValid(Caster, EnemySupportLeft)) unitList.Add(EnemySupportLeft);
        if(ability.IsAbilityValid(Caster, EnemySupportRight)) unitList.Add(EnemySupportRight);
        return unitList;
    }

    public Unit GetUnit(Position position, bool isPlayer)
    {
        switch (position)
        {
            case Position.SupportLeft:
                {
                    if (isPlayer) return PlayerSupportLeft;
                    else return EnemySupportLeft;
                }
            case Position.SupportRight:
                {
                    if (isPlayer) return PlayerSupportRight;
                    else return EnemySupportRight;
                }
            default:
                {
                    if (isPlayer) return PlayerVanguard;
                    else return EnemyVanguard;
                }
        }
    }

    public Position GetPosition(Unit unit)
    {
        if (GetIsSupportLeft(unit)) return Position.SupportLeft;
        else if (GetIsSupportRight(unit)) return Position.SupportRight;
        else return Position.Vanguard;
    }

    public bool GetIsVanguard(Unit unit)
    {
        return (unit == PlayerVanguard || unit == EnemyVanguard);
    }

    public bool GetIsSupportLeft(Unit unit)
    {
        return (unit == PlayerSupportLeft || unit == EnemySupportLeft);
    }

    public bool GetIsSupportRight(Unit unit)
    {
        return (unit == PlayerSupportRight || unit == EnemySupportRight);
    }

    protected override void SubscribeListeners()
    {
        GameEvents.resetBuffs += ResetSupportUsed;
        GameEvents.onAbilityResolved += SupportUsed;
        GameEvents.onKill += Kill;
        GameEvents.onSetupUnits += SetupUnits;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.resetBuffs -= ResetSupportUsed;
        GameEvents.onAbilityResolved -= SupportUsed;
        GameEvents.onKill -= Kill;
        GameEvents.onSetupUnits += SetupUnits;
    }

    private void Kill(Unit unit)
    {
        //vanguardPos = PlayerVanguard.transform.position;
        deathNote.Add(unit);
        //https://i.kym-cdn.com/entries/icons/original/000/034/833/snapchat_kill.jpg
    }

    public void ActivateKill()
    {

    }

    private void ResetSupportUsed()
    {
        supportLeftUsed = false;
        supportRightUsed = false;
    }

    private void SupportUsed(Unit unit)
    {
        if(GetIsSupportLeft(unit)) supportLeftUsed = true;
        if(GetIsSupportRight(unit)) supportRightUsed = true;
    }

    private void Awake()
    {
        main = this;
    }

    public void SwapPlayerUnit(Unit chosenUnit = null)
    {
        if(!chosenUnit) chosenUnit = sceneController.selectedUnit;
        vanguardPos = PlayerVanguard.transform.position;
        selectedUnitPos = chosenUnit.transform.position;
        
        VanguardToSupport = PlayerVanguard.transform;
        SupportToVanguard = chosenUnit.transform;
        disableInput = true;
        timer = 0;
        //chosenUnit.transform.position = vanguardPos;
        //PlayerVanguard.transform.position = selectedUnitPos;

        if (GetIsSupportLeft(chosenUnit))
        {
            Unit temp = PlayerSupportLeft;
            PlayerSupportLeft = PlayerVanguard;
            PlayerVanguard = temp;

            //Debug.Log("Player Vanguard: " + PlayerVanguard.transform.position);
            //Debug.Log("Player Support Left: " + PlayerSupportLeft.transform.position);
            //Debug.Log("Player Support Right: " + PlayerSupportRight.transform.position);
        }
        else if (GetIsSupportRight(chosenUnit))
        {
            Unit temp = PlayerSupportRight;
            PlayerSupportRight = PlayerVanguard;
            PlayerVanguard = temp;

            //Debug.Log("Player Vanguard: " + PlayerVanguard.transform.position);
            //Debug.Log("Player Support Left: " + PlayerSupportLeft.transform.position);
            //Debug.Log("Player Support Right: " + PlayerSupportRight.transform.position);
        }
        //GameEvents.SetPhase(RoundController.Phase.EnemySwap);
    }

    public void SwapEnemyUnit(Unit chosenUnit = null)
    {
        Debug.Log("swapping enemy units B)");
        if(!chosenUnit) chosenUnit = sceneController.selectedUnit;
        vanguardPos = EnemyVanguard.transform.position;
        selectedUnitPos = chosenUnit.transform.position;
        
        VanguardToSupport = EnemyVanguard.transform;
        SupportToVanguard = chosenUnit.transform;
        disableInput = true;
        timer = 0;
        //chosenUnit.transform.position = vanguardPos;
        //EnemyVanguard.transform.position = selectedUnitPos;

        if (GetIsSupportLeft(chosenUnit))
        {
            Unit temp = EnemySupportLeft;
            EnemySupportLeft = EnemyVanguard;
            EnemyVanguard = temp;

            //Debug.Log("Enemy Vanguard: " + PlayerVanguard.transform.position);
            //Debug.Log("Enemy Support Left: " + PlayerSupportLeft.transform.position);
            //Debug.Log("Enemy Support Right: " + PlayerSupportRight.transform.position);
        }
        else if (GetIsSupportRight(chosenUnit))
        {
            Unit temp = EnemySupportRight;
            EnemySupportRight = EnemyVanguard;
            EnemyVanguard = temp;

            //Debug.Log("Enemy Vanguard: " + PlayerVanguard.transform.position);
            //Debug.Log("Enemy Support Left: " + PlayerSupportLeft.transform.position);
            //Debug.Log("Enemy Support Right: " + PlayerSupportRight.transform.position);
        }
        //GameEvents.SetPhase(RoundController.Phase.PlayerSupport);
    }

    public void enemyVisual()
    {
        EnemyVanguard.UpdateEnemyVisual();
        if(EnemySupportLeft) EnemySupportLeft.UpdateEnemyVisual();
        if(EnemySupportRight) EnemySupportRight.UpdateEnemyVisual();
    }

}
