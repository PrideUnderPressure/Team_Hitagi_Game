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

    void Start()
    {
        playerControllerScript = gameObject.GetComponent<Player_Controller>();
        defaultSpeed = playerControllerScript.walkSpeed;
    }

    public void DoRoll()
    {
        if (cooldownOn != true && playerControllerScript.moveX != 0 || playerControllerScript.moveY != 0)
        StartCoroutine(RollRoutine());
    }

    IEnumerator RollRoutine()
    {
        cooldownOn = true;
        //Does the roll
        playerControllerScript.walkSpeed = rollSpeed;
        //How much will it roll
        yield return new WaitForSeconds(rollDistance);
        //resets back to normal movement speed
        playerControllerScript.walkSpeed = defaultSpeed;
        //Sets the cooldown
        yield return new WaitForSeconds(cooldown);
        cooldownOn = false;
    }
}
