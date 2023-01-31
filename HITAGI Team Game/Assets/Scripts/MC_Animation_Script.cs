using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Animation_Script : MonoBehaviour
{
    public Animator anime;

    public void RunAnimation(bool x)
    {
        if (x == true)
        {
            anime.SetBool("IsRunning", true);
        }

        if (x == false)
        {
            anime.SetBool("IsRunning", false);
        }
    }


}
