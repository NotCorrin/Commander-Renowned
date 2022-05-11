using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QTEAbility : Ability
{
    protected Unit Caster;
    protected Unit Target;

    public override void UseAbility(Unit Caster, Unit Target)
    {
        //Overridable code snippet that starts the QTE sequence
        if (IsAbilityValid(Caster, Target))
        {
            this.Caster = Caster;
            this.Target = Target;
            GameEvents.QTEStart(GetQTEType(), -Caster.Accuracy);
            GameEvents.onQTEResolved += OnQTEResolved;
        }
    }

    protected void OnQTEResolved(QTEController.QTEResult result)
    {
        AbilityUsed(result);
        Invoke("SetPhase",0.5f);
        GameEvents.onQTEResolved -= OnQTEResolved;
    }

    protected void SetPhase()
    {
        GameEvents.EndPhase();
    }

    // Use this to set the QTE type
    protected abstract QTEController.QTEType GetQTEType();

    protected abstract void AbilityUsed(QTEController.QTEResult result);


}
