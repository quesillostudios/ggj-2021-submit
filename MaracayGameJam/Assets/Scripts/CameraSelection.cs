using UnityEngine;

public class CameraSelection : MonoBehaviour
{

    [SerializeField] private string selectTag = "Selectable";
    [SerializeField] private float maxRayDistance = 50f;

    private Transform selected = null;

    private Vector3 lastSelectedWorldPosition = Vector3.zero;
    public Vector3 LastSelectedWorldPosition
    {
        get { return lastSelectedWorldPosition; }
        set { lastSelectedWorldPosition = value; }
    }
    

    #region Class Logic
    public Transform GetSelected() => selected;
    #endregion

    #region MonoBehaviour API
    private void Update()
    {

        if(selected != null)
        {
            var selectionRenderer = selected.GetComponent<Renderer>();

            selectionRenderer.material = LimboManager.Instance.GetPrimaryMaterial();
            selected = null; 
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cameraHit;
        if (Physics.Raycast(ray, out cameraHit, maxRayDistance))
        {
            var selection = cameraHit.transform;
            if (selection.GetComponent<SelectableObject>() != null)
            {
                LimboManager.Instance.SetSelectedObject(selection.GetComponent<SelectableObject>());
                LastSelectedWorldPosition = selection.position;

                LimboManager.Instance.GetSelectedObject().ChangeMaterial(LimboManager.Instance.GetHighLightMaterial());

                selected = selection;
            }
        }
    }
    #endregion
}
