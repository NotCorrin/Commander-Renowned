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
    /// Gets or sets the unit afflicted by the affect.
    /// </summary>
    public Unit Afflicted { get; protected set; }

    /// <summary>
    /// Gets the name of the status.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Adds new status or stacks of an existing status to a unit.
    /// </summary>
    /// <param name="afflicted">
    /// The unit recieving the status.
    /// </param>
    /// <param name="amount">
    /// The amount of stacks to be added.
    /// </param>
    public virtual void AddEffect(Unit afflicted, int amount)
    {
        foreach (Status status in afflicted.StatusList)
        {
            if (status != null)
            {
                if (status.GetType() == this.GetType())
                {
                    status.AddStacks(amount);
                    return;
                }
            }
        }

        afflicted.StatusList.Add(this);
        Afflicted = afflicted;
        StatusEvents.StatusAdded(Afflicted, this);
        SubscribeListeners();
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
        OnChanged(amount);
        StatusEvents.StatusStacked(Afflicted, this);
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
        StatusEvents.StatusRemoved(Afflicted, this);
        UnsubscribeListeners();
    }

    /// <summary>
    /// Subscribe to event corresponding to when status should decay.
    /// </summary>
    protected virtual void DecayStatus()
    {
        AddStacks(-StackAmount);
    }

    /// <summary>
    /// Activate the effect of the status.
    /// </summary>
    /// <param name="changeAmount">
    /// The difference between the old and new stack value.
    /// </param>
    protected virtual void OnChanged(int changeAmount)
    {
    }

    protected virtual void SubscribeListeners()
    {
        if (Afflicted)
        {
            Afflicted.OnStatusDecayTrigger += DecayStatus;
        }
    }

    protected virtual void UnsubscribeListeners()
    {
        if (Afflicted)
        {
            Afflicted.OnStatusDecayTrigger -= DecayStatus;
        }
    }
}
