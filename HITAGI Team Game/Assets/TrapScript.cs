using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapScript : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public bool canDamage;
    public float trapDamage;
    public float timeToActivate = 1f;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        canDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            canDamage = true;
            StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(timeToActivate);
        animator.ResetTrigger("IsActive");
        animator.SetTrigger("IsActive");
    }

    public void DealDamage()
    {
        if (canDamage)
        {
            player.GetComponent<Player_Stats>().canDamage = true;
            player.GetComponent<Player_Stats>().IsHit(trapDamage);
            Debug.Log("HIT PLAYER");
            canDamage = false;
        }
    }
    
    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            player.GetComponent<Player_Stats>().canDamage = false;
            canDamage = false;
        }
    }
}
