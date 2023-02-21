using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public Rigidbody2D rb;
    public bool canDamage;
    public bool damageCd;
    public AudioSource audioSource;
    void Start()
    {
        damageCd = false;
        health = maxHealth;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void IsHit(float damage)
    {
        if (damageCd == false)
        {
            if (canDamage && health - damage >= 0)
            {
                audioSource.PlayOneShot(audioSource.clip, 1f);
                gameObject.GetComponent<Player_Controller>().Blink();
                Debug.Log("@HITTTTTTT");
                health -= damage;
                rb.velocity = Vector2.zero;
                damageCd = true;
                StartCoroutine(DamageCD());
            }
            else if (canDamage && health - damage < 0)
            {
                PlayerDeath();
            }
        }
    }

    public void PlayerDeath()
    {
        Debug.Log("U DEAD YO");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    IEnumerator DamageCD()
    {
        yield return new WaitForSeconds(0.5f);
        damageCd = false;
    }


}
