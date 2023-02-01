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

    //SPRITE RENDERERS
    public SpriteRenderer sRBody;
    public SpriteRenderer sRGun;
    public GameObject gunObject;

    public float mousePosFloatX;
    public float mousePosFloatY;
    public float playerPosX;
    public float playerPosY;
    public float mousePosInRelationX;
    public float mousePosInRelationY;


    public bool check = false;
    

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        scriptRoll = gameObject.GetComponent<Roll>();
        scriptShooting = objectShooting.GetComponent<Shooting>();
        aniScript = gameObject.GetComponent<MC_Animation_Script>();
        defaultSpeed = walkSpeed;
        sRBody = gameObject.GetComponent<SpriteRenderer>();
        sRGun = gunObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MousePositions();

        if (disableInputs != true)
        {
            Inputs();
            Flips();
        }

    }

    void FixedUpdate()
    {
        Movement();

        if (disableAnimations != true)
        {
            Animations();
        }

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

        if (Input.GetMouseButtonDown(0) && scriptShooting.canFire && mousePosInRelationY > -0.22)
        {
            aniScript.Shot(1);
        }

        if (Input.GetMouseButtonDown(0) && scriptShooting.canFire && mousePosInRelationY < -0.22)
        {
            aniScript.Shot(2);
        }


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

        if (mousePosInRelationX < 0)
        {
            sRBody.flipX = false;
            sRGun.flipX = false;
        }

        if (mousePosInRelationX > 0)
        {
            sRBody.flipX = true;
            sRGun.flipX = true;
        }

    }

    public void MousePositions()
    {
        mousePosFloatX = scriptShooting.mousePosX;
        mousePosFloatY = scriptShooting.mousePosY;
        playerPosX = transform.position.x;
        playerPosY = transform.position.y;
        mousePosInRelationX = mousePosFloatX - playerPosX;
        mousePosInRelationY = mousePosFloatY - playerPosY;
    }

}
