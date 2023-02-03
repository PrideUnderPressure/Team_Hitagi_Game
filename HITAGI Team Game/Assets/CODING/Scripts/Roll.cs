using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Roll : MonoBehaviour
{
    public Player_Controller playerControllerScript;
    public int rollSpeed = 15;
    public float rollDistance;
    public float cooldown = 2f;
    public bool cooldownOn = false;
    private float defaultSpeed;
    private MC_Animation_Script aniScript;

    public GameObject objectShooting;
    public Shooting scriptShooting;


    void Start()
    {
        scriptShooting = objectShooting.GetComponent<Shooting>();
        playerControllerScript = gameObject.GetComponent<Player_Controller>();
        defaultSpeed = playerControllerScript.walkSpeed;
        aniScript = gameObject.GetComponent<MC_Animation_Script>();
    }

    public void DoRoll()
    {
        if (playerControllerScript.moveX != 0 || playerControllerScript.moveY != 0)
        {
            if (cooldownOn != true)
                StartCoroutine(RollRoutine());
        }
    }

    IEnumerator RollRoutine()
    {
        cooldownOn = true;
        aniScript.Roll();
        scriptShooting.notRolling = false;
        //Does the roll
        playerControllerScript.walkSpeed = rollSpeed;
        //How much will it roll
        yield return new WaitForSeconds(rollDistance);
        //resets back to normal movement speed
        playerControllerScript.walkSpeed = defaultSpeed;
        scriptShooting.notRolling = true;
        //Sets the cooldown
        yield return new WaitForSeconds(cooldown);
        cooldownOn = false;
    }
}
