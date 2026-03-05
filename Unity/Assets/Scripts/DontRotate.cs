using UnityEngine;

public class DontRotate : MonoBehaviour
{
    private Quaternion _initialRotation;

    void Start()
    {
        _initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = _initialRotation;
    }
}
