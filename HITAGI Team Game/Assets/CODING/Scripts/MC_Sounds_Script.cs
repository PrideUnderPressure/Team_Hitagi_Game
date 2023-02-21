using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(AudioSource))]
public class MC_Sounds_Script : MonoBehaviour
{

    private Player_Controller pcScript;
    public AudioSource audioSource1;
    public AudioSource audioSource2;


    public float soundDelay;
    


    public bool canPlayFootstep;
    

    void Start()
    {
        pcScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }

    void Update()
    {
        if (pcScript.moveX != 0 || pcScript.moveY != 0)
        {
            if (canPlayFootstep)
            {
                canPlayFootstep = false;
                StartCoroutine(PlayFootstep());
            }
        }
        if (pcScript.moveX == 0 && pcScript.moveY == 0)
        {
            StopFootstep();
            canPlayFootstep = true;
        }
    }

    private IEnumerator PlayFootstep()
    {
        audioSource1.Play();
        audioSource2.Play();
        yield return new WaitForSeconds(soundDelay);
    }

    private void StopFootstep()
    {
        audioSource1.Stop();
        audioSource2.Stop();
    }
    
}