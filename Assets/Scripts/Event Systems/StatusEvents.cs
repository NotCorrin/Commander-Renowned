using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1401 // Fields should be private

public static class StatusEvents
{
    public static Action<Unit, Status> onStatusAdded;

    public static void StatusAdded(Unit unit, Status status)
    {
        onStatusAdded?.Invoke(unit, status);
    }

    public static Action<Unit, Status> onStatusRemoved;

    public static void StatusRemoved(Unit unit, Status status)
    {
        onStatusRemoved?.Invoke(unit, status);
    }

    public static Action<Unit, Status> onStatusStacked;

    public static void StatusStacked(Unit unit, Status status)
    {
        onStatusStacked?.Invoke(unit, status);
    }
}

#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1401 // Fields should be private