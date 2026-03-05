using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMoveCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Handle camera translation
        float translationX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float translationZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float translationY = 0;

        if (Input.GetKey(KeyCode.E))
        {
            translationY = moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            translationY = -moveSpeed * Time.deltaTime;
        }

        transform.Translate(translationX, translationY, translationZ);

        // Handle camera rotation
        float rotationX = Input.GetAxis("Mouse X") * lookSpeed;
        float rotationY = -Input.GetAxis("Mouse Y") * lookSpeed;
        //transform.Rotate(rotationY, 0, 0);
        transform.Rotate(rotationY, rotationX, 0);
    }
}
