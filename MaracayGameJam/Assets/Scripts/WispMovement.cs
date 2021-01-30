using UnityEngine;
using UnityEngine.UI;

public enum MovementStatus
{
    Idle,
    Walking,
    Running,
    Blocked
}

public class WispMovement : AMoveable
{

    private CharacterController controller;

    [SerializeField] private MovementStatus movementStatus;
    [SerializeField] private Text movementText;
    [SerializeField] private int maxMovements;
    [SerializeField] private float movementSpeed;

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

    private Vector3 lastMovementToTranslate = Vector3.zero;

    #region Class Logic

    public override void DoMovement(Vector3 targetPosition)
    {
        if(movementStatus ==  MovementStatus.Idle)
        {
            lastMovementToTranslate = (targetPosition - transform.position).normalized * movementSpeed * Time.deltaTime;
            movementStatus = MovementStatus.Walking;
        }
        
    }

    public void Move()
    {
        transform.Translate(lastMovementToTranslate, Space.World);
    }

    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        MovementsLeft = maxMovements;
    }

    private void Start()
    {
        
    }

    private void FixedUpdate() 
    {
        if(movementStatus == MovementStatus.Walking)
        {
            Move();
        }
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        lastMovementToTranslate = Vector3.zero;
        movementStatus = MovementStatus.Idle;
    }
    #endregion
}
