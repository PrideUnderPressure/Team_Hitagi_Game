using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public GameObject script;

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("NOOOO");
            transform.parent.GetComponent<Agent>().Chase();
        }
    }
}
