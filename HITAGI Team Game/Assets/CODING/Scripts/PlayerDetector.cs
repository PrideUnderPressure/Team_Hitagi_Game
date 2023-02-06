using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public GameObject script;
    public bool alarm;

    void Start()
    {
        alarm = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("NOOOO");
            transform.parent.GetComponent<Agent>().Chase();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (alarm == true && other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<Agent>().Chase();
            alarm = false;
        }
    }
}
