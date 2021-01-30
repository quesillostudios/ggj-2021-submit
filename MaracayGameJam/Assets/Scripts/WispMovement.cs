using UnityEngine;
using UnityEngine.UI;

public class WispMovement : MonoBehaviour
{

    private CharacterController controller;

    [SerializeField] private Text movementText;
    [SerializeField] private int maxMovements;


    private int movementsLeft;
    public int MovementsLeft
    {
        get { return movementsLeft; }
        set 
        {
            movementsLeft = value;
            movementText.text = movementsLeft.ToString(); 
        }
    }

    [SerializeField] private float movementSpeed;

    #region Class Logic

    public float GetMovementSpeed() => movementSpeed;

    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        MovementsLeft = maxMovements;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    #endregion
}
