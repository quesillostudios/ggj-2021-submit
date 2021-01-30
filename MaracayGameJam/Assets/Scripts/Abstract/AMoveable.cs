using UnityEngine;

public abstract class AMoveable : MonoBehaviour
{
    public abstract void DoMovement(Vector3 targetPosition);
}