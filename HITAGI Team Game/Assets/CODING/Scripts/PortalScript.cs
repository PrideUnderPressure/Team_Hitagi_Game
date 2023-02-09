using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PortalScript : MonoBehaviour
{

    public Player_Controller playerController;
    public GameObject playerObject;
    public bool isHolding = false;
    public Transform whereToTeleportObject;
    public Vector3 whereToTeleport;
    public bool isInCircle = false;
    void Start()
    {
        whereToTeleport = whereToTeleportObject.position;
    }

    private void Update()
    {
        if (isInCircle)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerController.moveX = 0;
                playerController.moveY = 0;
                isHolding = true;
                Debug.Log("startedHolding");
                StartCoroutine(Wait());
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                isHolding = false;
                playerController.disableInputs = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController = other.gameObject.GetComponent<Player_Controller>();
            playerObject = other.gameObject;
            isInCircle = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isHolding = false;
            isInCircle = false;
        }
    }

    public void InitiateClosing()
    {
        
    }


    IEnumerator Wait()
    {
        Debug.Log("Wait Begun");
        playerController.disableInputs = true;
        yield return new WaitForSeconds(3f);
        if (isHolding)
        {
            Debug.Log("HELDDDDDDD");
            playerObject.transform.position = (whereToTeleport);
            playerController.disableInputs = false;
        }
    }
}