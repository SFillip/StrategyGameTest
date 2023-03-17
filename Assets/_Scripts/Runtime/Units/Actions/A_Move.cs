using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class A_Move : BaseAction
{
    [SerializeField] private bool HasMoved;

    public override void Perform(Unit actor)
    {

    }

    public override bool CanPerform(Unit actor)
    {
        return base.CanPerform(actor) && !HasMoved;
    }

    public override void OnTurnStart()
    {
        HasMoved = false;
    }
}
