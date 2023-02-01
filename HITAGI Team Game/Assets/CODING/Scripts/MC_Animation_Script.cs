using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Animation_Script : MonoBehaviour
{
    public Animator animeBody;

    //This MUST MUST MUST look for the animator instead of being put in the scene editor. TO BE DONE 100% LATER;
    public Animator animeGun;
    //And it will take it from the selectedGun.
    public GameObject selectedGun;
    public Shooting shootingScript;

    void Start()
    {
        animeGun = GameObject.FindGameObjectWithTag("Selected_Gun").GetComponent<Animator>();
        shootingScript = GameObject.FindGameObjectWithTag("Selected_Gun").GetComponent<Shooting>();

    }

    public void RunAnimation(bool x)
    {
        if (x == true)
        {
            animeBody.SetBool("IsRunning", true);
            animeGun.SetBool("IsRunning", true);
        }

        if (x == false)
        {
            animeBody.SetBool("IsRunning", false);
            animeGun.SetBool("IsRunning", false);
        }
    }

    public void Shot(int x)
    {
        if (x == 1)
        {
            //STRAIGHT (1)
            animeGun.ResetTrigger("ShotStraightT");
            animeGun.SetTrigger("ShotStraightT");
        }

        if (x == 2)
        {
            //DOWN (2)
            //animeGun.Play("MC_Shot_Gun1_Down", -1, 0f);
        }
    }

}
