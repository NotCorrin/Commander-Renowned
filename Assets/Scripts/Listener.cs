using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all UI listeners.
/// </summary>
public abstract class Listener : MonoBehaviour
{
    /// <summary>
    /// Subscribe to events.
    /// </summary>
    protected abstract void SubscribeListeners();

    /// <summary>
    /// Unsubscribe from events.
    /// </summary>
    protected abstract void UnsubscribeListeners();

    private void OnEnable()
    {
        SubscribeListeners();
    }

    private void OnDisable()
    {
        UnsubscribeListeners();
    }
}
