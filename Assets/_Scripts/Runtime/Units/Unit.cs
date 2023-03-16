using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool Selected { get; set; }

    private Grid _characterGrid;

    // Start is called before the first frame update
    void Start()
    {
        _characterGrid =GameObject.FindGameObjectWithTag("CharacterGrid")
            .GetComponent<Grid>();

        transform.position = _characterGrid.GetCellCenterWorld(Vector3Int.RoundToInt(transform.position));
    }
}
