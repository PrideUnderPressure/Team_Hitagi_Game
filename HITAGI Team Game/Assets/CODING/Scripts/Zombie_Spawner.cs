using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Spawner : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject whatToSpawn1;
    public int howMany1;
    public GameObject whatToSpawn2;
    public int howMany2;
    public GameObject whatToSpawn3;
    public int howMany3;

    public GameObject where;
    public Vector3 whereVector3;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        whereVector3 = where.transform.position;
    }
    
    public void Spawn1()
    {
        for(int i = 0; i < howMany1; i++)
        {
            GameObject spawned = Instantiate(whatToSpawn1);
            spawned.GetComponent<NavMeshAgent>().Warp(whereVector3);

        }
    }
    public void Spawn2()
    {
        for(int i = 0; i < howMany2; i++)
        {
            Instantiate(whatToSpawn1);
        }
    }
    public void Spawn3()
    {
        for(int i = 0; i < howMany3; i++)
        {
            Instantiate(whatToSpawn1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Spawn1();
            //Spawn2();
            //Spawn3();
            Destroy(this.gameObject);
        }
    }
}
