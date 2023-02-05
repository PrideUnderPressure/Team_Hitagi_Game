using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Animator animator;
    public int speed;
    public bool alreadyHit;

    public float damage;
    public NavMeshAgent navMesh;

    private void Start()
    {
        health = maxHealth;
        animator = gameObject.GetComponent<Animator>();
        alreadyHit = false;
        navMesh = gameObject.GetComponent<NavMeshAgent>();
    }

    public void Damage(float x)
    {
        if (health - x > 0)
        {
            health -= x;
            if (alreadyHit != true)
            {
                animator.SetBool("IsRunning", false);
                animator.ResetTrigger("IsHit");
                animator.SetTrigger("IsHit");
                animator.SetBool("IsRunning", true);
            }
        }
        else if (health - x < 0)
        {
            
            animator.SetTrigger("IsDead");
        }
    }

    public void Death()
    {
        navMesh.speed = 0;
        navMesh.velocity = Vector3.zero;
        Destroy(this.gameObject);
    }
    
    public void NotHit()
    {
        alreadyHit = false;
    }
}
