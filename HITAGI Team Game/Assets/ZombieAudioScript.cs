using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieAudioScript : MonoBehaviour
{
    public List<AudioClip> soundList;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayGroan()
    {
        int x = Random.Range(0, 4);
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.PlayOneShot(soundList[x], 1f);
    }
}
