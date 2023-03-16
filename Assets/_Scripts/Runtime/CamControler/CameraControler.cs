using Codice.Client.Commands;
using Project.Controls;
using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControler : MonoBehaviour
{
    [SerializeField] private float screenEdgeBorderThickness = 5.0f;

    [Space,SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeed;

    [Space, SerializeField] private Transform camParent;

    [Space, SerializeField] private Grid _characterGrid;

    private Camera _camera;
    private Controler _controler;

    private Vector2 mouseDelta;
    private float zoomDelta;

    private Vector2 mousePos;

    private Unit selectedUnit;

    private void Awake()
    {
        _controler = new();
    }

    private void Start()
    {
        _camera = GetComponent<Camera>();

        _controler.Gameplay.MouseMove.performed += _ => mouseDelta = _.ReadValue<Vector2>();
        _controler.Gameplay.MouseMove.canceled += _ => mouseDelta = Vector2.zero;

        _controler.Gameplay.ZoomDelta.performed += _ =>zoomDelta=_.ReadValue<float>();
        _controler.Gameplay.ZoomDelta.canceled+= _ => zoomDelta = 0;

        _controler.Gameplay.MousePos.performed += _ => mousePos = _.ReadValue<Vector2>();

        _controler.Gameplay.Interact.performed += _ => Interact();
    }

    private void Update() => Move();

    private void FixedUpdate() => Zoom();

    private void Move()
    {
        Vector2 panMovement = Vector2.zero;
        if(mouseDelta.y >= Screen.height - screenEdgeBorderThickness)
        {
            panMovement.y += moveSpeed * Time.deltaTime;
        }
        if(mouseDelta.y <= screenEdgeBorderThickness)
        {
            panMovement.y -= moveSpeed * Time.deltaTime;
        }
        if(mouseDelta.x <= screenEdgeBorderThickness)
        {
            panMovement.x -= moveSpeed * Time.deltaTime;
        }
        if(mouseDelta.x >= Screen.width - screenEdgeBorderThickness)
        {
            panMovement.x += moveSpeed * Time.deltaTime;
        }

        camParent.Translate(panMovement,Space.World);
    }

    private void Zoom()
    {
        Debug.Log(zoomDelta);
        _camera.fieldOfView += zoomDelta * zoomDelta * Time.deltaTime;
    }

    private void Interact()
    {
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos,Vector2.zero);

        
        if (hit.transform != null && hit.transform.CompareTag("Unit"))
        {

            selectedUnit = hit.transform.GetComponent<Unit>();
            selectedUnit.Selected = true;
        }
    }

    #region OnEnable/Disable
    private void OnEnable() => _controler.Enable();
    private void OnDisable() => _controler.Disable();
    #endregion
}
