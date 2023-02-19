using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControllerScript : MonoBehaviour
{
    public List<AudioClip> bgmList;
    public AudioSource bgmSource;
    void Start()
    {
        bgmSource.clip = bgmList[0];
        bgmSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch(bool x)
    {
        int y = 1;
    }
}
