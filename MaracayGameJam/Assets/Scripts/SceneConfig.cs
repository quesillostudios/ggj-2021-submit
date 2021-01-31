using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneConfig : MonoBehaviour
{
    [SerializeField] private string sceneSong;

    #region Class Logic
    private void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void ExitGame()
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
        SoundHandler.Instance.Play(sceneSong, 0.1f);
    }

    private void Update()
    {
        
    }
    #endregion
}
