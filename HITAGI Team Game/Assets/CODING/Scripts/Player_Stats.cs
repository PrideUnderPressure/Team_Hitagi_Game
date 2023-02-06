using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Rigidbody2D rb;
    public bool canDamage;

    void Start()
    {
        health = maxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void IsHit(float damage)
    {
        if (canDamage && health - damage >= 0)
        {
            Debug.Log("@HITTTTTTT");
            health -= damage;
            rb.velocity = Vector2.zero;
        }
        else if (canDamage && health - damage < 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        Debug.Log("U DEAD YO");
        
    }
}
