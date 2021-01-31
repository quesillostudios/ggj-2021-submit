using UnityEngine;

public class LimboManager : MonoBehaviour
{
    public static LimboManager Instance;

    [SerializeField] private Material primaryMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private SelectableObject actualObjectSelected;
    private SelectableObject lastObjectSelected;

    private bool pausedGame;
    public bool PausedGame
    {
        get { return pausedGame; }
        set 
        {
            if(value == true)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1;
            }

            pausedGame = value; 
        }
    }
    

    #region Class Logic
    public Material GetPrimaryMaterial() => primaryMaterial;
    public Material GetHighLightMaterial() => highlightMaterial;

    public void SetSelectedObject(SelectableObject selected) => actualObjectSelected = selected;
    public SelectableObject GetSelectedObject() => actualObjectSelected;

    private void SetLastObjectReference(ref SelectableObject selected) => lastObjectSelected = selected;

    public void PerformWorldTranslate()
    {
        actualObjectSelected.ActualSelection = true;

        SetLastObjectReference(ref actualObjectSelected);

        if(lastObjectSelected != null && lastObjectSelected != actualObjectSelected)
        {
            lastObjectSelected.ActualSelection = false;
        }
    }

    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        } 
        else 
        {
            Instance = this;
        }

        pausedGame = false;
    }
    #endregion
}
