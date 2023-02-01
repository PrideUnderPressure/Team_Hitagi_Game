using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(AudioSource))]
public class MC_Sounds_Script : MonoBehaviour
{
    public List<AudioClip> footstepSounds;
    public List<Tile> floorTile;

    private Player_Controller pcScript;
    private AudioSource _audioSource;
    private int listIndex;
    private Rigidbody2D feetRb;
    public float soundDelay;
    
    public GameObject objectShooting;
    public Shooting scriptShooting;

    public bool canPlayFootstep;
    

    void Start()
    {
        scriptShooting = objectShooting.GetComponent<Shooting>();

        pcScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        feetRb = gameObject.GetComponent<Rigidbody2D>();
        listIndex = 0;
        
    }

    void Update()
    {
        if (pcScript.moveX != 0 || pcScript.moveY != 0)
        {
            _audioSource.clip = footstepSounds[listIndex];
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

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Stone_Tiles":
                if(listIndex != 0)
                    listIndex = 0;
                    break; 
            
            case "Dirt": 
                if(listIndex != 1)
                    listIndex = 1;
                    break; 
            case "Grass": 
                if(listIndex != 2) 
                    listIndex = 2;
                    break;
        }
        _audioSource.clip = footstepSounds[listIndex];
        _audioSource.Play();
    }

    private IEnumerator PlayFootstep()
    {
        _audioSource.Play();
        yield return new WaitForSeconds(soundDelay);
    }

    private void StopFootstep()
    {
        _audioSource.Stop();
    }

    public void PlayShot()
    {
        
    }
}