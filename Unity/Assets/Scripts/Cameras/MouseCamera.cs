using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float zoomSpeed = 5f;
    [SerializeField] private float minZoomDistance = 10f;
    [SerializeField] private float maxZoomDistance = 50f;
    
    [Header("Input References")]
    [SerializeField] private InputActionReference mousePositionAction;
    [SerializeField] private InputActionReference mouseDeltaAction;
    [SerializeField] private InputActionReference mouseButtonAction;
    [SerializeField] private InputActionReference keyboardMoveAction;
    
    private Camera _camera;
    private bool _isDragging = false;
    private float _currentZoomDistance;
    
    private void Awake()
    {
        _camera = GetComponent<Camera>();
        if (_camera == null)
        {
            _camera = Camera.main;
        }
        
        _currentZoomDistance = Vector3.Distance(transform.position, Vector3.zero);
    }

    private void OnEnable()
    {
        // Enable input actions
        mousePositionAction.action.Enable();
        mouseDeltaAction.action.Enable();
        mouseButtonAction.action.Enable();
        if (keyboardMoveAction != null)
        {
            keyboardMoveAction.action.Enable();
        }
        
        // Subscribe to mouse button events
        mouseButtonAction.action.started += OnMouseButtonPressed;
        mouseButtonAction.action.canceled += OnMouseButtonReleased;
    }

    private void OnDisable()
    {
        // Disable input actions
        mousePositionAction.action.Disable();
        mouseDeltaAction.action.Disable();
        mouseButtonAction.action.Disable();
        if (keyboardMoveAction != null)
        {
            keyboardMoveAction.action.Disable();
        }
        
        // Unsubscribe from mouse button events
        mouseButtonAction.action.started -= OnMouseButtonPressed;
        mouseButtonAction.action.canceled -= OnMouseButtonReleased;
    }
    
    private void OnMouseButtonPressed(InputAction.CallbackContext context)
    {
        _isDragging = true;
    }
    
    private void OnMouseButtonReleased(InputAction.CallbackContext context)
    {
        _isDragging = false;
    }
    
    private void Update()
    {
        HandleMouseInput();
        HandleKeyboardInput();
    }
    
    private void HandleMouseInput()
    {
        if (_isDragging)
        {
            // Get mouse delta movement
            Vector2 mouseDelta = mouseDeltaAction.action.ReadValue<Vector2>();
            
            if (mouseDelta.magnitude > 0.01f)
            {
                // Handle camera rotation based on mouse movement
                float yaw = mouseDelta.x * rotationSpeed * Time.deltaTime;
                float pitch = -mouseDelta.y * rotationSpeed * Time.deltaTime;
                
                // Rotate around Y-axis (left/right)
                transform.Rotate(Vector3.up, yaw, Space.World);
                
                // Rotate around X-axis (up/down)
                transform.Rotate(Vector3.right, pitch, Space.Self);
            }
        }
    }

    private void HandleKeyboardInput()
    {
        if (keyboardMoveAction != null)
        {
            // Read WASD input
            Vector2 moveInput = keyboardMoveAction.action.ReadValue<Vector2>();
            
            if (moveInput.magnitude > 0.01f)
            {
                // Calculate movement direction in world space
                Vector3 rightMovement = transform.right * moveInput.x;
                Vector3 forwardMovement = transform.forward * moveInput.y;
                
                // Ensure forward movement is horizontal (no vertical component)
                forwardMovement.y = 0f;
                forwardMovement.Normalize();
                
                // Combine movements and apply speed
                Vector3 movement = (rightMovement + forwardMovement).normalized * moveSpeed * Time.deltaTime;
                
                // Move the camera
                transform.position += movement;
            }
        }
    }
}
