using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour
{
    //player controls
    private PlayerInputActions controls;
    [SerializeField] float mouseSensivity = 15f;

    private float xRotation = 0f;
    private Vector2 mouseLook;
    // the body the camera is stuck at
    private Transform playerBody;

    private void Awake()
    {
        playerBody = transform.parent;
        controls = new PlayerInputActions();
        // you cant move the mouse while playing game
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    { 
        // gets the location of the cursor where the players look
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;
        // prevents the camera from too far up and down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //sets the rotation along the x-axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // sets players's body rotation according to the movement of the mouse in the horizontal axis.
        playerBody.Rotate(Vector2.up, mouseX);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
