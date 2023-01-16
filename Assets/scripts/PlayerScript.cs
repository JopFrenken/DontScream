using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    Vector3 moveInput;
    Vector3 moveDirection;

    PlayerInputActions inputActions;
    [SerializeField] private float jumpPower = 6f;
    Rigidbody playerBody;

    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float runSpeed = 12f;
    private bool jumped = false;

    Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        moveSpeed = walkSpeed;
        spawn = transform.position;
    }
    
    //happens before script is loaded
    private void Awake()
    {
        inputActions = new PlayerInputActions();    
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * moveSpeed  * Time.deltaTime, Space.Self);
        
        if(inputActions.Player.Jump.triggered && jumped == false)
        { // You can't jump when you are already jumping
            playerBody.AddForce(moveInput.x, jumpPower, moveInput.y, ForceMode.Impulse);
            jumped = true;
        }

        if (inputActions.Player.Run.inProgress)
        { // you can hold shift while running
            moveSpeed = runSpeed;
        } else
        {
            moveSpeed = walkSpeed;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable(); 
    }

    private void OnCollisionEnter(Collision collision)
    { // You die if you collide with the enemy
        if(collision.gameObject.tag == "enemy")
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("DeathScene");
          //  Debug.Log("enemy hit");
        }
        // game ends when you reach the end
        if(collision.gameObject.tag == "end")
        {
            SceneManager.LoadScene("EndScene");
        }
        // you are not jumping if you are touching the terrain
        if(collision.gameObject.tag == "terrain")
        {
            jumped = false;
        }
    }
}
