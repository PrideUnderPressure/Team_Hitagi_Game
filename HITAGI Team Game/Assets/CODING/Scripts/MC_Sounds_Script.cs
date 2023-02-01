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
    

    void Start()
    {
        scriptShooting = objectShooting.GetComponent<Shooting>();

        pcScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        _audioSource = gameObject.GetComponent<AudioSource>();
        feetRb = gameObject.GetComponent<Rigidbody2D>();
        listIndex = 0;
        
    }

    /*private void Update()
    {
        if (feetRb.velocity.x > 0 || feetRb.velocity.y > 0)
        {
            StartCoroutine(PlayFootstep());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Tilemap_StoneTiles":
                if(listIndex != 0)
                    listIndex = 0;
                    break;
                case "Tilemap_Dirt":
                listIndex = 1;
                break;
        }
    }*/

    private IEnumerator PlayFootstep()
    {
        _audioSource.clip = footstepSounds[listIndex];
        _audioSource.Play();
        yield return new WaitForSeconds(soundDelay);
    }

    public void PlayShot()
    {
        
    }
}