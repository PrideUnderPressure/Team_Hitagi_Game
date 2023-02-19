using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUi : MonoBehaviour
{
    public GameObject player;
    public Player_Stats statsScript;
    
    public float maxHealth;
    public float currentHealth;

    [SerializeField] Slider healthSlider = null;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        statsScript = player.GetComponent<Player_Stats>();
        maxHealth = statsScript.maxHealth;
    }

    private void Update()
    {
        Mathf.Clamp(currentHealth, 0f, 100f);
        healthSlider.value = (float)currentHealth / maxHealth;
    }

    private void FixedUpdate()
    {
        currentHealth = statsScript.health;
    }
}
