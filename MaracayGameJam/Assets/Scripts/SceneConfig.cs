using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConfig : MonoBehaviour
{
    [SerializeField] private string sceneSong;
    [SerializeField] private bool autostartSong;

    #region Class Logic
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        
    }

    private void Start()
    {
        if(autostartSong == true)
        {
            SoundHandler.Instance.Play(sceneSong, 0.1f);
        }
    }

    private void Update()
    {
        
    }
    #endregion
}
