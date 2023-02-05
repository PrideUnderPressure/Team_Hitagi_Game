using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private Animator animator;
    public float deathTimer;

    public bool alreadyHit;

    public Shooting shootingScript;
    public float damage;
    void Start()
    {
        shootingScript = GameObject.FindGameObjectWithTag("Shooting_Object").GetComponent<Shooting>();
        damage = shootingScript.maxDmg2;
        
        animator = gameObject.GetComponent<Animator>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        alreadyHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (alreadyHit == false)
        {
            if (other.gameObject.tag == "Zombie")
            {
                rb.velocity = new Vector2(0, 0).normalized * force;
                animator.SetTrigger("IsHit");
                GameObject zombie = other.gameObject;
                zombie.GetComponent<Agent>().Hit();
                zombie.GetComponent<Stats>().Damage(damage);
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

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
