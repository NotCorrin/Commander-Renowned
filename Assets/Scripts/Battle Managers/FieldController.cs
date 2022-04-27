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


    public static FieldController main;
    // Start is called before the first frame update
    void Start()
    {
        
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
        return (unit == PlayerSupportLeft || unit == PlayerSupportRight);
    }

    public bool GetIsSupportRight(Unit unit)
    {
        return (unit == PlayerSupportRight || unit == PlayerSupportRight);
    }

    protected override void SubscribeListeners()
    {
        //throw new System.NotImplementedException();
    }

    protected override void UnsubscribeListeners()
    {
        //throw new System.NotImplementedException();
    }


}
