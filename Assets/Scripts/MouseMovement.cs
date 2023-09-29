using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f; // speed of the movement of the mouse

    // variables which help to change the rotation
    float xRotation = 0f;
    float yRotation = 0f;
    void Start()
    {
        // locked cursor in the middle
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // recieve the input mouse x and y
        // in settings it checks on x and y axis
        /* time.deltatime is used so there's no difference between 60fps or 400 fps 
        because update counts every frame so we don't sensitivity be faster on 400 fps */

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // - because if mouseY is up, which is obvious when you look up, the rotation in the inspector is negative
        xRotation -= mouseY;
        // clamp is written so we can look only on our feets and to the sky which is 90degrees max
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // simply inverting the movement so it works correctly
        yRotation += mouseX;

        // quarternion represents rotations and euler which deals with z y and z
        // z = 0f because we don't want to move back and forth with mouse :D

        // it rotates every frame with transform in inspector
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
