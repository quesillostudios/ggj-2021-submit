using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public bool IsAUniqueObject = false;

    private Renderer objectRenderer;

    private bool actualSelection;
    public bool ActualSelection
    {
        get { return actualSelection; }
        set 
        {
            if(IsAUniqueObject)
            {
                actualSelection = true;
                return;
            }

            actualSelection = value; 
        }
    }

    #region Class Logic
    public void ChangeMaterial(Material material) => objectRenderer.material = material;
    #endregion

    #region MonoBehaviour API
    private void Awake() => objectRenderer = GetComponent<Renderer>();

    private void OnCollisionEnter(Collision other) 
    {
        if(IsAUniqueObject)
        {
            Debug.Log("Estoy aquí");
            objectRenderer.material = LimboManager.Instance.GetHighLightMaterial();
        }
    }
    #endregion
}
