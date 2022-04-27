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
    Vector3 PlayerVanguardPos;
    Vector3 selectedUnitPos;

    public static FieldController main;
    // Start is called before the first frame update
    void Start()
    {
        sceneController = GameObject.Find("GameObject").GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsUnitPlayer(Unit unit)
    {
        return (unit == PlayerVanguard || unit == PlayerSupportLeft || unit == PlayerSupportRight);
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
        //throw new System.NotImplementedException();
    }

    protected override void UnsubscribeListeners()
    {
        //throw new System.NotImplementedException();
    }


    public void SwapUnit()
    {
        PlayerVanguardPos = PlayerVanguard.transform.position;
        selectedUnitPos = sceneController.selectedUnit.transform.position;
        

        sceneController.selectedUnit.transform.position = PlayerVanguardPos;
        PlayerVanguard.transform.position = selectedUnitPos;

        if (GetIsSupportLeft(sceneController.selectedUnit))
        {
            Unit temp = PlayerSupportLeft;
            PlayerSupportLeft = PlayerVanguard;
            PlayerVanguard = temp;

            Debug.Log("Player Vanguard: " + PlayerVanguard.transform.position);
            Debug.Log("Player Support Left: " + PlayerSupportLeft.transform.position);
            Debug.Log("Player Support Right: " + PlayerSupportRight.transform.position);
        }
        else if (GetIsSupportRight(sceneController.selectedUnit))
        {
            Unit temp = PlayerSupportRight;
            PlayerSupportRight = PlayerVanguard;
            PlayerVanguard = temp;

            Debug.Log("Player Vanguard: " + PlayerVanguard.transform.position);
            Debug.Log("Player Support Left: " + PlayerSupportLeft.transform.position);
            Debug.Log("Player Support Right: " + PlayerSupportRight.transform.position);
        }
    }

}
