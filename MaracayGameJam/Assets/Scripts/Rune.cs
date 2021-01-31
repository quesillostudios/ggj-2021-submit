using UnityEngine;

public class Rune : MonoBehaviour
{
    #region Class Logic
    #endregion

    #region MonoBehaviour API
    private void OnCollisionEnter(Collision other) 
    {
        LimboManager.Instance.AddGameScore();
        Destroy(this.gameObject);
    }
    #endregion
}
