using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Gun_Script : MonoBehaviour
{

    public List<RuntimeAnimatorController> gunControllers;
    public Shooting sScript;
    public Animator animator;
    public int gunIndex;
    
    public float maxDamage;
    public float maxAmmo;
    void Start()
    {
        gunIndex = 0;
        sScript = GameObject.FindGameObjectWithTag("Shooting_Object").GetComponent<Shooting>();
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
                sScript.activeBullet = sScript.bullet;
                break;

            case 2:
                if (gunIndex != 2)
                    gunIndex = 2;
                sScript.activeBullet = sScript.bullet;
                break;
            case 3:
                if (gunIndex != 3)
                    gunIndex = 3;
                sScript.activeBullet = sScript.bulletShotgun;
                break;
        }

        animator.runtimeAnimatorController = gunControllers[gunIndex] as RuntimeAnimatorController;
    }
}
