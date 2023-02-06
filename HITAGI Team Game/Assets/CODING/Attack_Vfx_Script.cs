using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Attack_Vfx_Script : MonoBehaviour
{
    public Animator animator;
    public bool attacked;
    public NavMeshAgent agents;

    public void Attacking()
    {
            agents.velocity = Vector3.zero;
            if (attacked != true)
            {
                animator.ResetTrigger("IsAttacking");
                animator.SetTrigger("IsAttacking");
                attacked = true;
            }
    }


}
    

