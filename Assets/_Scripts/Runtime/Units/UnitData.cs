using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif


[CreateAssetMenu(fileName = "new Unit", menuName = "Units/new Unit")]
public class UnitData : ScriptableObject
{
    public string UnitName;
    public int MaxAvailableActions;

    [SerializeReference]
    public List<BaseAction> Actions = new List<BaseAction>()
    {
        new A_Move(),
        new A_TakeCOver(),
    };
}

#if UNITY_EDITOR
[CustomEditor(typeof(UnitData))]
public class ActionDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        var UnitData = (UnitData)target;

        var subclasses = Assembly
            .GetAssembly(typeof(BaseAction))
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(BaseAction)));

        foreach (var subclass in subclasses)
        {
            if (GUILayout.Button(subclass.Name))
            {
                object toAdd=Activator.CreateInstance(subclass);
                UnitData.Actions.Add((BaseAction) toAdd);
            }
        }

        base.OnInspectorGUI();
    }
}
#endif



