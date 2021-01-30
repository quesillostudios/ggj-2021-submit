﻿using UnityEngine;

public class CameraController : MonoBehaviour
{

    private const float ROTATE_LIMIT = 90f;
    private const string    INPUT_MOUSE_X = "Mouse X", 
                            INPUT_MOUSE_Y = "Mouse Y";

    [Header("Opciones de cámara")]
    [SerializeField] KeyCode keyCodeTransport;
    [SerializeField] KeyCode keyCodeCursorStatus;
    [SerializeField] private float cameraSensivity = 30f;

    [Header("Opciones de objetivo")]
    [SerializeField] private Transform targetToHandle;

    private float rotationX = Vector3.zero.x;

    private Camera theCamera;
    private CameraSelection CameraSelection;

    #region Class Logic
    private float InputMouse(float input) => input * cameraSensivity * Time.deltaTime;

    private void RotateCameraOnX()
    {
        rotationX -= InputMouse(Input.GetAxis(INPUT_MOUSE_Y));
        rotationX = Mathf.Clamp(rotationX, -ROTATE_LIMIT, ROTATE_LIMIT);
        transform.localRotation = Quaternion.Euler(rotationX, Vector3.zero.y, Vector3.zero.z);
    }

    private void RotateTarget() => targetToHandle.Rotate(Vector3.up * InputMouse(Input.GetAxis(INPUT_MOUSE_X)));

    private void InputCursorStatus()
    {
        if(Input.GetKeyDown(keyCodeCursorStatus))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    private void TranslateTarget()
    {
        if(Input.GetKey(keyCodeTransport))
        {
            //targetToHandle.position = CameraSelection.LastSelectedWorldPosition;
            targetToHandle.Translate((CameraSelection.LastSelectedWorldPosition - targetToHandle.position).normalized * targetToHandle.GetComponent<WispMovement>().GetMovementSpeed() * Time.deltaTime, Space.World);
        }
    }

    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        theCamera = Camera.main;
        CameraSelection = GetComponent<CameraSelection>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RotateCameraOnX();
        RotateTarget();
        InputCursorStatus();
        TranslateTarget();
    }
    #endregion
}
