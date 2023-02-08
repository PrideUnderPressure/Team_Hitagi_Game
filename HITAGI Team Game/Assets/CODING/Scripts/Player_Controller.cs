using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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
    public SpriteRenderer hitSprite;
    public GameObject gunObject;
    public Animator animeBody;
    public Animator animeGun;

    public float mousePosFloatX;
    public float mousePosFloatY;
    public float playerPosX;
    public float playerPosY;
    public float mousePosInRelationX;
    public float mousePosInRelationY;


    public bool check = false;

    private int shotAngle = 0;
    public bool disableWarp;
    public bool warping;

    public GameObject world1;
    public GameObject world2;

    public bool inNormalWorld;
    public SpriteRenderer spriteGun;

    public int activeWeapon;

    void Start()
    {
        inNormalWorld = true;
        world1 = GameObject.FindGameObjectWithTag("Normal_World");
        world2 = GameObject.FindGameObjectWithTag("Zombie_World");
        world2.SetActive(false);

        animeGun = GameObject.FindGameObjectWithTag("Selected_Gun").GetComponent<Animator>();
        spriteGun = GameObject.FindGameObjectWithTag("Selected_Gun").GetComponent<SpriteRenderer>();   
        
        hitSprite = GameObject.FindGameObjectWithTag("Hit_Sprite").GetComponent<SpriteRenderer>();
        
        rigidBody = GetComponent<Rigidbody2D>();
        scriptRoll = gameObject.GetComponent<Roll>();
        scriptShooting = objectShooting.GetComponent<Shooting>();
        aniScript = gameObject.GetComponent<MC_Animation_Script>();
        defaultSpeed = walkSpeed;
        sRBody = gameObject.GetComponent<SpriteRenderer>();
        sRGun = gunObject.GetComponent<SpriteRenderer>();

        scriptShooting.onShoot.AddListener(() => { aniScript.Shot(shotAngle); });

        hitSprite.enabled = false;
    }

    void Update()
    {
        MousePositions();

        if (disableInputs != true)
        {
            Inputs();
            Flips();
        }

        if (disableWarp != true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                InitiateWarp();
            }
        }

        if (warping)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                animeBody.SetBool("IsWarping", false);
                animeGun.SetBool("IsWarping", false);
                disableInputs = false;
            }
        }
        
    }

    public void InitiateWarp()
    {
        disableInputs = true;
        warping = true;
        moveX = 0;
        moveY = 0;
        animeBody.SetBool("IsWarping", true);
        animeGun.SetBool("IsWarping", true);

    }

    public void Warp()
    {
        if (inNormalWorld) ;
        {
            world1.SetActive(!inNormalWorld);
            world2.SetActive(inNormalWorld);
            Debug.Log("Warped");
        }
        /*if (inNormalWorld == false);
        {
            world2.SetActive(false);
            world1.SetActive(true);
            Debug.Log("Warped Back wow");
        }*/
        inNormalWorld = !inNormalWorld;
        disableInputs = false;
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


        if (Input.GetKey(KeyCode.Space))
        {
            scriptRoll.DoRoll();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameObject.GetComponent<WeaponSwap>().CarriedWeapon1(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameObject.GetComponent<WeaponSwap>().CarriedWeapon2(false);
        }
        
        if (mousePosInRelationY > -0.22 && mousePosInRelationY < 0.22)
        {
            shotAngle = 1;
        }

        if (mousePosInRelationY < -0.22)
        {
            shotAngle = 2;
        }

        if (mousePosInRelationY > 0.22)
        {
            shotAngle = 3;
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Z_Melee_Attack")
        {
            gameObject.GetComponent<Player_Stats>().canDamage = true;
            other.GetComponent<Attack_Vfx_Script>().Attacking();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Z_Melee_Attack")
        {
            gameObject.GetComponent<Player_Stats>().canDamage = false;
        }
    }

    public void Blink()
    {
        StartCoroutine(BlinkOnHit());
    }
    
    IEnumerator BlinkOnHit()
    {
        spriteGun.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        hitSprite.enabled = true;
        yield return new WaitForSeconds(0.1f);
        hitSprite.enabled = false;
        spriteGun.enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;


    }


    
}

