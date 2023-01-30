using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public int rollSpeed = 15;
    public float rollDistance;
    public float cooldown = 2f;
    public bool cooldownOn = false;

    void Start()
    {
        playerControllerScript = gameObject.GetComponent<PlayerController>();
    }

    public void DoRoll()
    {
        if (cooldownOn != true)
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
        playerControllerScript.walkSpeed = 6;
        //Sets the cooldown
        yield return new WaitForSeconds(cooldown);
        cooldownOn = false;
    }
}
