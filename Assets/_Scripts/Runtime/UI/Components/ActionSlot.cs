using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionSlot : Selectable
{
    public BaseAction Action { private get; set; }

    public override void OnSelect(BaseEventData eventData)
    {
        Cursor.SetCursor(Action.CursorTexture, Vector2.zero, CursorMode.Auto);
        base.OnSelect(eventData);
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        base.OnDeselect(eventData);
    }
}
