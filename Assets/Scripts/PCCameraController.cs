using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCCameraController : MonoBehaviour
{

    public float rotationSpeed;

    private bool isLocked;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.GameMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isLocked = !isLocked;

            if (isLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        MoveCameraToMouse();
    }

    private void MoveCameraToMouse()
    {
        transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X") * rotationSpeed), Space.World);

        
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * rotationSpeed, 0,0), Space.Self);

    }
}
