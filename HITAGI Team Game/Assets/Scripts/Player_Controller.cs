using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public bool disableInputs = false;
    public float moveX;
    public float moveY;

    private Vector2 moveDirection;
    public float walkSpeed;

    public Roll scriptRoll;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        scriptRoll = gameObject.GetComponent<Roll>();
    }

    void Update()
    {
        if (disableInputs != true)
        {
            Inputs();
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Inputs()
    {
        //Does that so A and D work for controlling the movement
        moveX = Input.GetAxisRaw("Horizontal");
        //Same but with W and S for vertical movement
        moveY = Input.GetAxisRaw("Vertical");
        //Input for ROLL
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scriptRoll.DoRoll();
        }
    }

    public void Movement()
    {
        //Makes a new Vector2 to be used in Movement
        moveDirection = new Vector2(moveX, moveY);
        //Adds velocity to the rigidbody
        rigidBody.velocity = new Vector2(moveDirection.x * walkSpeed, moveDirection.y * walkSpeed);
    }
}
