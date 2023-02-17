using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControllerScript : MonoBehaviour
{
    public List<AudioClip> bgmList;
    public AudioSource bgmSource;
    void Start()
    {
        bgmSource.clip = bgmList[1];
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch(bool x)
    {
        if (x == true)
        {
            bgmSource.Stop();
            bgmSource.clip = bgmList[1];
            bgmSource.Play();
        }
        if (x == false)
        {
            bgmSource.Stop();
            bgmSource.clip = bgmList[0];
            bgmSource.Play();
        }
    }
}
