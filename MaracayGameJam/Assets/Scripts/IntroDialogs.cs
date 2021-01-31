using UnityEngine;
using UnityEngine.UI;

public class IntroDialogs : MonoBehaviour
{
    [SerializeField] private string[] dialogs;
    [SerializeField] private Text currentDialog;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject SkipButton;
    private int actualDialog = 0;
    private Animator animator;

    #region Class Logic
    public void NextDialog()
    {
        if(actualDialog == dialogs.Length)
        {
            return;
        }
        actualDialog++;
        currentDialog.text = dialogs[actualDialog];
    }

    public void ContinueButton()
    {
        continueButton.SetActive(true);
        SkipButton.SetActive(false);
        SoundHandler.Instance.Stop("MainMenu", 0.5f);
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
