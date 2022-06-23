using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all UI listeners.
/// </summary>
public abstract class UISubscriber : Listener
{
    /// <summary>
    /// Subscribes UIElements to events.
    /// </summary>
    /// <remarks>
    /// This method is called when the listener is enabled.
    /// </remarks>
    protected abstract void SubscribeCallbacks();

    /// <summary>
    /// Unsubscribes UIElements from events.
    /// </summary>
    /// <remarks>
    /// This method is called when the listener is disabled.
    /// </remarks>
    protected abstract void UnsubscribeCallbacks();

    private void OnEnable()
    {
        SubscribeCallbacks();
    }

    private void OnDisable()
    {
        UnsubscribeCallbacks();
    }
}
