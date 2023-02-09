using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private Animator animator;
    public float deathTimer = 1f;

    public bool alreadyHit;
    
    public float damage;

    public bool isShotgun;
    public Vector3 playerPos;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = playerPos - transform.position;
        Vector3 rotation = transform.position - playerPos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        alreadyHit = false;
        StartCoroutine(TimerDestroy());
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (alreadyHit == false)
        {
                if (other.gameObject.tag == "Player")
                {
                    rb.velocity = new Vector2(0, 0).normalized * force;
                    animator.SetTrigger("IsHit");
                    GameObject player = other.gameObject;
                    player.GetComponent<Player_Stats>().canDamage = true;
                    player.GetComponent<Player_Stats>().IsHit(damage);
                    player.GetComponent<Player_Stats>().canDamage = false;
                    alreadyHit = true;

                }
                else if (other.gameObject.tag == "Walls")
                {
                    rb.velocity = new Vector2(0, 0).normalized * force;
                    animator.SetTrigger("IsHit");
                    alreadyHit = true;
                }
        }
    }
    
    IEnumerator TimerDestroy()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(this.gameObject);
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
