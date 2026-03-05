using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]private InputAction switchCameraAction;
    private List<CinemachineVirtualCamera> _vCams;
    private int _index = 0;


    private void Start()
    {
        _vCams = new();
        _vCams.AddRange(GetComponentsInChildren<CinemachineVirtualCamera>());
    }

#region InputBindings
    private void OnEnable()
    {
        switchCameraAction.Enable();
        switchCameraAction.performed += ctx => NextCam();
    }

    private void OnDisable()
    {
        switchCameraAction.Disable();
        switchCameraAction.performed -= ctx => NextCam();
    }
#endregion
    
    public void NextCam()
    {
        _vCams[_index].Priority = 0;
        _index++;

        if (_index >= _vCams.Count)
            _index = 0;
        
        _vCams[_index].Priority = 1;
    }
}
