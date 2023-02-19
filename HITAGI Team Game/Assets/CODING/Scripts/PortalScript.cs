using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{

    public Player_Controller playerController;
    public GameObject playerObject;
    public bool isHolding = false;
    public Transform whereToTeleportObject;
    public Vector3 whereToTeleport;
    public bool isInCircle = false;
    
    public MeshRenderer textRenderer;
    public bool isBigDaddy = false;

    public AudioSource audioSource;
    void Start()
    {
        whereToTeleport = whereToTeleportObject.position;
        audioSource = gameObject.GetComponent<AudioSource>();
        textRenderer.enabled = false;
    }

    private void Update()
    {
        if (isInCircle)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (isBigDaddy != true)
                {
                    playerController.moveX = 0;
                    playerController.moveY = 0;
                    isHolding = true;
                    Debug.Log("startedHolding");
                    StartCoroutine(Wait());
                }
                if (isBigDaddy != false)
                {
                    playerController.moveX = 0;
                    playerController.moveY = 0;
                    isHolding = true;
                    Debug.Log("startedHolding");
                    StartCoroutine(WaitToExit());
                }
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                isHolding = false;
                playerController.disableInputs = false;
                audioSource.pitch = 1f;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController = other.gameObject.GetComponent<Player_Controller>();
            playerObject = other.gameObject;
            isInCircle = true;
            textRenderer.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isHolding = false;
            isInCircle = false;
            textRenderer.enabled = false;
            audioSource.pitch = 1f;
        }
    }

    public void InitiateClosing()
    {
        
    }


    IEnumerator Wait()
    {
        Debug.Log("Wait Begun");
        playerController.disableInputs = true;
        audioSource.PlayOneShot(audioSource.clip, 1f);
        yield return new WaitForSeconds(1f);
        audioSource.pitch = 1.2f;
        if (isHolding)
        {
            audioSource.PlayOneShot(audioSource.clip, 1f);
            yield return new WaitForSeconds(1f);

            if (isHolding)
            {
                audioSource.pitch = 1.4f;
                audioSource.PlayOneShot(audioSource.clip, 1f);
                yield return new WaitForSeconds(1f);


                if (isHolding)
                {
                    Debug.Log("HELDDDDDDD");
                    playerObject.transform.position = (whereToTeleport);
                    playerController.disableInputs = false;
                    playerObject.GetComponent<LevelDataHolder>().portalCount++;
                    Destroy(this.gameObject);
                }
            }
        }
    }

    IEnumerator WaitToExit()
    {
        playerController.disableInputs = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}