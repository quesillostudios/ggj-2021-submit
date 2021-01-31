using UnityEngine;

public class Skymap : MonoBehaviour
{
    [SerializeField] private Transform targetToFollow;
    [SerializeField] private float speed;

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
        transform.Rotate(this.transform.rotation * Vector3.up * speed * Time.deltaTime);
    }
    #endregion
}
