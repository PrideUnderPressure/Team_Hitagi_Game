using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public bool disableInputs = false;
    public float moveX;
    public float moveY;

    private Vector2 moveDirection;
    public float walkSpeed;
    private float defaultSpeed;

    //SCRIPT REFERENCES
    public Roll scriptRoll;
    public GameObject objectShooting;
    public Shooting scriptShooting;

    //Animations
    public MC_Animation_Script aniScript;
    public bool disableAnimations = false;
    public SpriteRenderer spriteRenderer;

    private float mousePosFloat;
    public float playerPosX;
    public float mousePosInRelation;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        scriptRoll = gameObject.GetComponent<Roll>();
        scriptShooting = objectShooting.GetComponent<Shooting>();
        aniScript = gameObject.GetComponent<MC_Animation_Script>();
        defaultSpeed = walkSpeed;
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

        if (disableAnimations != true)
        {
            Animations();
        }

        Flips();
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

        playerPosX = transform.position.x;
        mousePosInRelation = mousePosFloat - playerPosX;

    }

    public void Movement()
    {
        //Makes a new Vector2 to be used in Movement
        moveDirection = new Vector2(moveX, moveY);
        //Adds velocity to the rigidbody
        rigidBody.velocity = new Vector2(moveDirection.x * walkSpeed, moveDirection.y * walkSpeed);
    }

    public void Animations()
    {
        if (moveX != 0 || moveY != 0)
        {
            aniScript.RunAnimation(true);
        }
        else
        {
            aniScript.RunAnimation(false);
        }
    }

    public void Flips()
    {
        mousePosFloat = scriptShooting.mousePosX;

        if (mousePosInRelation < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (mousePosInRelation > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
