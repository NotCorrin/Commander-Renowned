using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

 static public class CameraEventSystem
{
    static public Action<Vector3> onPlayerClickWorld;
    static public void PlayerClickWorld(Vector3 worldPosition)
    {
        if (onPlayerClickWorld != null)
        {
            onPlayerClickWorld(worldPosition);
        }
    }

    static public Action<int> onCameraMove;
    static public void CameraMove(int id)
    {
        if (onCameraMove != null)
        {
            onCameraMove(id);
        }
    }
}
