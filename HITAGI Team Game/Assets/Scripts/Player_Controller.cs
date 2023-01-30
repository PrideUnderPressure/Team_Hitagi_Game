using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public bool disableInputs = false;

    private Vector2 moveDirection;
    public float walkSpeed;
    public float moveX;
    public float moveY;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
        //Makes a new Vector2 to be used in Movement
        moveDirection = new Vector2(moveX, moveY);
    }

    public void Movement()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * walkSpeed, moveDirection.y * walkSpeed);
    }
}
