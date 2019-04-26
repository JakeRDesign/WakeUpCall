using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float mouseSensitivity = 0f;     // The sensitivity of the mouse to look around.
    public float clampAngle = 0f;            // The space in which the mouse can move around on screen. A "boundary" area.

    private float rotY = 0.0f;                  // Point of origin for the mouse/camera.
    private float rotX = 0.0f;                  // Point of origin for the mouse/camera.

    //--------------------------------------------------------------------------------------
    //	    Start()
    //          Runs during initialisation. The starting position of the mouse to orient.
    //
    //      Param:
    //		       None
    //      Return:
    //		       Void
    //--------------------------------------------------------------------------------------
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //--------------------------------------------------------------------------------------
    //	    Update()
    //          Runs every frame.
    //
    //      Param:
    //		       None
    //      Return:
    //		       Void
    //--------------------------------------------------------------------------------------
    void Update()
    {
        // Input of mouse each frame.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
        rotY = Mathf.Clamp(rotY, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.localRotation = localRotation;
    }
}