using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : CommanderUnit
{
    public override int GetStickScore()
    {
        return GetMoveScoreAIAlgorithm();
    }

    public override int GetSwitchScore()
    {
        return GetMoveScoreAIAlgorithm();
    }
}
