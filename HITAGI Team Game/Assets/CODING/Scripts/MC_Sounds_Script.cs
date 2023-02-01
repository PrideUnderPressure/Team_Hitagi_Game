using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Sounds_Script : MonoBehaviour
{
    public AudioSource runDirt;
    public AudioSource runStoneTiles;

    public Player_Controller pcScript;
    public bool playingSound = false;

    void Start()
    {
        pcScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }

    void Update()
    {

        if (pcScript.moveX != 0 || pcScript.moveY != 0)
        {
            playingSound = true;
        }

        if (pcScript.moveX == 0 && pcScript.moveY == 0)
        {
            playingSound = false;
            runDirt.Pause();
        }
    }

    void FixedUpdate()
    {

    }


    public void RunSfxReset()
    {
        runDirt.Pause();
        runStoneTiles.Stop();
    }

}