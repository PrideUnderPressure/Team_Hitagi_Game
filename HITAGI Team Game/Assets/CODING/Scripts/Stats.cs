using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Animator animator;
    public int speed;
    public bool alreadyHit;

    public float damage;
    public NavMeshAgent navMesh;

    
    //FOR BLOOD
    public List<GameObject> bloodTypes;
    public int bloodIndex;
    




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
        else if (health - x <= 0)
        {
            Destroy(gameObject.GetComponent<CapsuleCollider2D>());
            animator.SetTrigger("IsDead");
        }
    }

    public void Death()
    {
        navMesh.speed = 0;
        navMesh.velocity = Vector3.zero;
        ShedBlood();

        
    }
    
    public void NotHit()
    {
        alreadyHit = false;
    }

    public void ShedBlood()
    {
        //I HAVE NO TIME OK?
        int number = Random.Range(0, 8);
        var position = gameObject.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        Instantiate(bloodTypes[number], position, Quaternion.identity);

        number = Random.Range(0, 8);
        position = gameObject.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        Instantiate(bloodTypes[number], position, Quaternion.identity);

        number = Random.Range(0, 8);
        position = gameObject.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        Instantiate(bloodTypes[number], position, Quaternion.identity);
        
        number = Random.Range(0, 8);
        position = gameObject.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        Instantiate(bloodTypes[number], position, Quaternion.identity);
        
        number = Random.Range(0, 8);
        position = gameObject.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
        Instantiate(bloodTypes[number], position, Quaternion.identity);
        
        Destroy(this.gameObject);
  
    }
    
}
