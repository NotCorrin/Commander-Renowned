using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all UI listeners.
/// </summary>
public abstract class UISubscriber : MonoBehaviour
{
    /// <summary>
    /// Subscribes UIElements to events.
    /// </summary>
    /// <remarks>
    /// This method is called when the listener is enabled.
    /// </remarks>
    protected virtual void RegisterCallbacks()
    {
    }

    /// <summary>
    /// Unsubscribes UIElements from events.
    /// </summary>
    /// <remarks>
    /// This method is called when the listener is disabled.
    /// </remarks>
    protected virtual void UnregisterCallbacks()
    {
    }

    /// <summary>
    /// Assign UI elements to fields.
    /// </summary>
    protected abstract void AssignUIElements();

    /// <summary>
    /// Subscribe to events.
    /// </summary>
    /// <remarks>
    /// This method is called when the listener is enabled.
    /// Optional to implement.
    /// </remarks>
    protected virtual void SubscribeListeners()
    {
    }

    /// <summary>
    /// Unsubscribe from events.
    /// </summary>
    /// <remarks>
    /// This method is called when the listener is disabled.
    /// Optional to implement.
    /// </remarks>
    protected virtual void UnsubscribeListeners()
    {
    }

    private void OnEnable()
    {
        try
        {
            AssignUIElements();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
        }

        SubscribeListeners();
        RegisterCallbacks();
    }

    private void OnDisable()
    {
        UnsubscribeListeners();
        UnregisterCallbacks();
    }
}
