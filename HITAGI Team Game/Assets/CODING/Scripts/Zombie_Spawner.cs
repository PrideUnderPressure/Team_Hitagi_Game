using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawner : MonoBehaviour
{
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
        whereVector3 = where.transform.position;
    }
    
    public void Spawn1()
    {
        for(int i = 0; i < howMany1; i++)
        {
            Instantiate(whatToSpawn1);

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
