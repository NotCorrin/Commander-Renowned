using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status
{
    /// <summary>
    /// Gets or sets the number of stacks of a status on an unit.
    /// </summary>
    public int StackAmount { get; protected set; }

    /// <summary>
    /// Gets or sets the icon to be displayed on the status bar.
    /// </summary>
    public Sprite Icon { get; protected set; }

    /// <summary>
    /// Gets or sets the unit afflicted by the affect.
    /// </summary>
    public Unit Afflicted { get; protected set; }

    /// <summary>
    /// Adds new status or stacks of an existing status to a unit.
    /// </summary>
    /// <param name="afflicted">
    /// The unit recieving the status.
    /// </param>
    /// <param name="amount">
    /// The amount of stacks to be added.
    /// </param>
    protected virtual void AddEffect(Unit afflicted, int amount)
    {
        foreach (Status status in afflicted.StatusList)
        {
            if (status.GetType() == this.GetType())
            {
                status.AddStacks(amount);
                return;
            }
        }

        afflicted.StatusList.Add(this);
        Afflicted = afflicted;
        AddStacks(amount);
    }

    /// <summary>
    /// Adds stacks to an existing effect.
    /// </summary>
    /// <param name="amount">
    /// Amount of stacks to add.
    /// </param>
    protected virtual void AddStacks(int amount)
    {
        StackAmount += amount;
        OnTriggered();
        if (StackAmount == 0)
        {
            RemoveStatus();
        }
    }

    /// <summary>
    /// Called when a status is removed from afflicted.
    /// </summary>
    protected virtual void RemoveStatus()
    {
        Afflicted.StatusList.Remove(this);
    }

    /// <summary>
    /// Subscribe to event corresponding to when status should decay.
    /// </summary>
    protected virtual void DecayStatus()
    {
        StackAmount = 0;
        OnTriggered();
        RemoveStatus();
    }

    /// <summary>
    /// Activate the effect of the status.
    /// </summary>
    protected abstract void OnTriggered();

}
