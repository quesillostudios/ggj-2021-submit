using UnityEngine;

public class CameraSelection : MonoBehaviour
{

    [SerializeField] private string selectTag = "Selectable";
    [SerializeField] private Material materialColorToHighlight;
    
    private Material OldMaterialSelected;
    private Transform selected;

    private Vector3 lastSelectedWorldPosition;
    public Vector3 LastSelectedWorldPosition
    {
        get { return lastSelectedWorldPosition; }
        set { lastSelectedWorldPosition = value; }
    }
    

    #region Class Logic
    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {

        if(selected != null)
        {
            var selectionRenderer = selected.GetComponent<Renderer>();
            selectionRenderer.material = OldMaterialSelected;
            selected = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cameraHit;
        if (Physics.Raycast(ray, out cameraHit))
        {
            var selection = cameraHit.transform;
            if (selection.CompareTag(selectTag))
            {
                Vector3 selectedPosition = new Vector3(selection.transform.position.x, selection.transform.position.y, selection.transform.position.z);
                LastSelectedWorldPosition = selectedPosition;
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null)
                {
                    OldMaterialSelected = selectionRenderer.material;
                    selectionRenderer.material = materialColorToHighlight;
                } 

                selected = selection;
            }
        }
    }
    #endregion
}
