using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class Player_Gun_Script : MonoBehaviour
{

    public List<RuntimeAnimatorController> gunControllers;
    public Animator animator;
    public int gunIndex;

    void Start()
    {
        gunIndex = 0;
    }

    public void SwitchGun(int gunNumber)
    {
        switch (gunNumber)
        {
            case 0:
                if (gunIndex != 0)
                    gunIndex = 0;
                break;

            case 1:
                if (gunIndex != 1)
                    gunIndex = 1;
                break;

            case 2:
                if (gunIndex != 2)
                    gunIndex = 2;
                break;
        }

        animator.runtimeAnimatorController = gunControllers[gunIndex] as RuntimeAnimatorController;
    }
}
