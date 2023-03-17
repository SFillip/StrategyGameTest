using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[System.Serializable]
public abstract class BaseAction
{
    public string Name;
    public int Cost;

    public Sprite Icon;

    public Texture2D CursorTexture;

    public abstract void Perform(Unit actor);

    public virtual bool CanPerform(Unit actor)
    {
        return Cost <= actor.RemainingActions;
    }

    public virtual void OnTurnStart()
    {
        return;
    }

    public virtual void OnTurnEnd()
    {
        return;
    }

}
