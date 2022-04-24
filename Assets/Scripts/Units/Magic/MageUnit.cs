using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageUnit : MagicUnit
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
