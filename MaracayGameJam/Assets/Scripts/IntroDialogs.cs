using UnityEngine;
using UnityEngine.UI;

public class IntroDialogs : MonoBehaviour
{
    [SerializeField] private string[] dialogs;
    [SerializeField] private Text currentDialog;
    private int actualDialog = 0;
    private Animator animator;

    #region Class Logic
    public void NextDialog()
    {
        if(actualDialog <= dialogs.Length)
        {
            actualDialog++;
        }
        currentDialog.text = dialogs[actualDialog];
    }
    #endregion

    #region MonoBehaviour API
    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }


    private void Start()
    {
        actualDialog = 0;
        currentDialog.text = dialogs[actualDialog];
    }

    private void Update()
    {
        
    }
    #endregion
}
