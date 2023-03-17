using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public static Ui_Manager Instance { get; private set; }

    [SerializeField] private Transform ActionsBorder;

    [Space, Header("Prefebs")]
    [SerializeField] private GameObject ActionSlot;

    private List<GameObject> Actions = new List<GameObject>();

    private void Awake()
    {
        Instance=this;
    }

    public void UnitSelected(Unit unit)
    {
        foreach(var Action in unit.UnitData.Actions)
        {
            GameObject slot = GameObject.Instantiate(ActionSlot, ActionsBorder);

            slot.GetComponent<ActionSlot>().Action=Action;
            Actions.Add(slot);
        }
    }

    public void UnitDeselected()
    {
        foreach(GameObject Action in Actions)
            Destroy(Action);
    }
}
