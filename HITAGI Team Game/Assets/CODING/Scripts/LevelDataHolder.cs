using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDataHolder : MonoBehaviour
{
    public int portalCount = 0;
    public int elitesKilled = 0;
    public GameObject bigDaddyPrefab;
    public Transform bigDaddySpot;

    public bool alreadyDone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (portalCount == 2)
        {
            if (alreadyDone != true)
            {
                MakeBigDaddy();
            }
        }
    }

    void MakeBigDaddy()
    {
        Instantiate(bigDaddyPrefab, bigDaddySpot.position, Quaternion.identity);
        alreadyDone = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
