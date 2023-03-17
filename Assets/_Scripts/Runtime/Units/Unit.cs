using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private bool _selected;

    public bool Selected
    {
        get=> _selected; set{ _selected = value;
            Ui_Manager.Instance.UnitSelected(this);
        } 
     }

    public UnitData UnitData;

    public int RemainingActions;

    private Grid _characterGrid;

    // Start is called before the first frame update
    void Start()
    {
        _characterGrid = GameObject.FindGameObjectWithTag("CharacterGrid")
            .GetComponent<Grid>();

        transform.position = _characterGrid.GetCellCenterWorld(Vector3Int.RoundToInt(transform.position));
    }
}
