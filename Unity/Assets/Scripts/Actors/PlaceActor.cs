using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlaceActor : MonoBehaviour
{
    [Header("Actor Prefabs")]
    [SerializeField] private GameObject humanActorPrefab;
    [SerializeField] private GameObject bicycleActorPrefab;

    [Header("Parents")]
    [SerializeField] private Transform humanParent;
    [SerializeField] private Transform bicycleParent;

    [Header("UI References")]
    [SerializeField] private Button humanButton;
    [SerializeField] private Button bicycleButton;
    
    [Header("Button Colors")]
    [SerializeField] private Color selectedColor = Color.red;
    
    [Header("Placement Settings")]
    [SerializeField] private Camera placementCamera;
    [SerializeField] private LayerMask navMeshLayer;
    [SerializeField] private float maxRaycastDistance = 100f;
    
    [Header("Input System References")]
    [SerializeField] private InputActionReference pointerPositionAction;
    [SerializeField] private InputActionReference pointerClickAction;

    private bool _isHumanPlacementActive = false;
    private bool _isBicyclePlacementActive = false;
    private GameObject _currentPrefabToPlace;
    private Transform _parent;
    
    // Store position for delayed UI check
    private Vector2 lastClickPosition;
    private bool checkForUI = false;

    // Store original button colors
    private ColorBlock humanButtonColors;
    private ColorBlock bicycleButtonColors;

    // Actor type enum for easier handling of actor types
    private enum ActorType
    {
        Human,
        Bicycle
    }

    private void Awake()
    {
        // Ensure input actions are set up
        if (pointerClickAction == null)
            Debug.LogError("Pointer Click Action is not assigned to PlaceActor component!");
            
        if (pointerPositionAction == null)
            Debug.LogError("Pointer Position Action is not assigned to PlaceActor component!");
    }

    void Start()
    {
        if (placementCamera == null)
            placementCamera = Camera.main;
            
        // Store the original button colors
        if (humanButton != null)
            humanButtonColors = humanButton.colors;
        
        if (bicycleButton != null)
            bicycleButtonColors = bicycleButton.colors;
            
        SetupButtons();
        EnableInputActions();
    }

    private void OnEnable()
    {
        EnableInputActions();
    }

    private void OnDisable()
    {
        DisableInputActions();
    }

    private void EnableInputActions()
    {
        if (pointerClickAction != null)
        {
            pointerClickAction.action.Enable();
            pointerClickAction.action.performed += OnPointerClick;
        }
        
        if (pointerPositionAction != null)
        {
            pointerPositionAction.action.Enable();
        }
    }

    private void DisableInputActions()
    {
        if (pointerClickAction != null)
        {
            pointerClickAction.action.Disable();
            pointerClickAction.action.performed -= OnPointerClick;
        }
        
        if (pointerPositionAction != null)
        {
            pointerPositionAction.action.Disable();
        }
    }

    private void OnPointerClick(InputAction.CallbackContext context)
    {
        // Store the click position for checking in the next Update call
        lastClickPosition = pointerPositionAction != null 
            ? pointerPositionAction.action.ReadValue<Vector2>() 
            : Mouse.current.position.ReadValue();
            
        checkForUI = true;
    }

    private void Update()
    {
        // Handle UI checks during normal Update rather than within an Input System callback
        if (checkForUI)
        {
            checkForUI = false;
            
            // Check if any placement mode is active and we have a prefab to place
            if ((_isHumanPlacementActive || _isBicyclePlacementActive) && _currentPrefabToPlace != null)
            {
                // We're now checking for UI elements outside of the input callback
                if (!IsPointerOverUI())
                {
                    PlaceActorAtPosition(lastClickPosition);
                }
            }
        }
    }

    private bool IsPointerOverUI()
    {
        // First check using standard EventSystem
        if (EventSystem.current.IsPointerOverGameObject())
            return true;
            
        // Additional check using Input System's UI module if available
        var inputModule = EventSystem.current.currentInputModule as InputSystemUIInputModule;
        if (inputModule != null)
        {
            // Try to get the pointer event data
            var pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = lastClickPosition
            };
            
            // Raycast against UI elements
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);
            
            return results.Count > 0;
        }
        
        return false;
    }

    private void SetupButtons()
    {
        if (humanButton != null)
        {
            humanButton.onClick.AddListener(() => ToggleActorPlacement(ActorType.Human));
        }
        
        if (bicycleButton != null)
        {
            bicycleButton.onClick.AddListener(() => ToggleActorPlacement(ActorType.Bicycle));
        }
    }

    private void ToggleActorPlacement(ActorType actorType)
    {
        GameObject prefabToPlace;
        Transform parentTransform;
        ref bool isActiveFlag = ref _isHumanPlacementActive; // Default reference to human flag
        Button activeButton;
        Button otherButton;
        
        // Set up actor-specific properties based on type
        if (actorType == ActorType.Human)
        {
            prefabToPlace = humanActorPrefab;
            parentTransform = humanParent;
            isActiveFlag = ref _isHumanPlacementActive;
            activeButton = humanButton;
            otherButton = bicycleButton;
        }
        else // Bicycle
        {
            prefabToPlace = bicycleActorPrefab;
            parentTransform = bicycleParent;
            isActiveFlag = ref _isBicyclePlacementActive;
            activeButton = bicycleButton;
            otherButton = humanButton;
        }
        
        // Toggle the active state
        isActiveFlag = !isActiveFlag;
        
        if (isActiveFlag)
        {
            // Turn off other placement if it's active
            if (actorType == ActorType.Human)
                _isBicyclePlacementActive = false;
            else
                _isHumanPlacementActive = false;
                
            _currentPrefabToPlace = prefabToPlace;
            _parent = parentTransform;
            
            // Apply selected color to active button
            SetButtonSelectedColor(activeButton, true);
            
            // Reset other button color
            SetButtonSelectedColor(otherButton, false);
        }
        else
        {
            _currentPrefabToPlace = null;
            
            // Reset button color
            SetButtonSelectedColor(activeButton, false);
        }
    }

    private void SetButtonSelectedColor(Button button, bool isSelected)
    {
        if (button == null) return;
        
        ColorBlock colorBlock = button.colors;
        
        if (isSelected)
        {
            colorBlock.normalColor = selectedColor;
            colorBlock.selectedColor = selectedColor;                
        }
        else
        {
            // Reset to default colors
            colorBlock = (button == humanButton) ? humanButtonColors : bicycleButtonColors;
        }
        
        button.colors = colorBlock;
    }

    // Convenience methods for direct button action connections
    public void ToggleHumanPlacement() => ToggleActorPlacement(ActorType.Human);
    public void ToggleBicyclePlacement() => ToggleActorPlacement(ActorType.Bicycle);

    private void PlaceActorAtPosition(Vector2 screenPosition)
    {
        // Cast a ray from the mouse position
        Ray ray = placementCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        // Check if the ray hits the NavMesh
        bool hitSomething = Physics.Raycast(ray, out hit, maxRaycastDistance, navMeshLayer);
        
        if (hitSomething)
        {
            // Check if position is on NavMesh
            NavMeshHit navHit;
            bool foundNavMeshPosition = NavMesh.SamplePosition(hit.point, out navHit, 5.0f, NavMesh.AllAreas);
            
            if (foundNavMeshPosition)
            {
                // Instantiate the selected actor prefab at the NavMesh position
                GameObject actor = Instantiate(_currentPrefabToPlace, navHit.position, Quaternion.identity, _parent);
                
                // Get NavMeshAgent component
                actor.GetComponent<NavMeshAgent>();
            }
        }
        else
        {
            // Try a raycast without layer mask to see if we hit anything at all
            Physics.Raycast(ray, out hit, maxRaycastDistance);
        }
    }
}
