using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{

    [Header("Menú de pausa")]
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject[] objectsToHide;

    private bool pausePanelStatus;
    public bool PausePanelStatus
    {
        get { return pausePanelStatus; }
        set 
        { 
            if(value == true)
            {
                ToogleObjectsToHide(false);
                pausePanel.SetActive(true);
            }
            else
            {
                ToogleObjectsToHide(true);
                pausePanel.SetActive(false);
            }

            pausePanelStatus = value; 
        }
    }
    

    #region Class Logic
    private void ToogleObjectsToHide(bool status)
    {
        for (int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(status);
        }
    }

    public void ContinueButton()
    {
        if(LimboManager.Instance != null)
        {
            PausePanelStatus = !PausePanelStatus;
            LimboManager.Instance.PausedGame = !LimboManager.Instance.PausedGame;
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    #region MonoBehaviour API

    private void Awake()
    {
        pausePanelStatus = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            if(LimboManager.Instance != null)
            {
                PausePanelStatus = !PausePanelStatus;
                LimboManager.Instance.PausedGame = !LimboManager.Instance.PausedGame;
            }
        }
    }
    #endregion
}
