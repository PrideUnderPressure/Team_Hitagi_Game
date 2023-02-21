using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndScript : MonoBehaviour
{
    public GameObject endScreen;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            endScreen.SetActive(true);
            endScreen.GetComponent<EndScreen>().EndScreenOn();
        }
    }
}
