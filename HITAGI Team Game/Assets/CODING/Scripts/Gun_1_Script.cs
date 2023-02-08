using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_1_Script : MonoBehaviour
{

    public GameObject player;
    public Player_Gun_Script gun;
    public Shooting shootScript;
    public int whichToSwitch;
    public float firerate;
    //Maybe random damage? between minDamage and maxDamage (like 3-6 dmg)
    public float maxDamage;
    public float maxAmmo;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Shooting_Object");
        gun = GameObject.FindGameObjectWithTag("Selected_Gun").GetComponent<Player_Gun_Script>();

        shootScript = player.GetComponent<Shooting>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<WeaponSwap>().WeaponPickup(whichToSwitch);
            gun.SwitchGun(whichToSwitch);
            shootScript.timeBetweenFiring = firerate;
            shootScript.DamageSwitch(maxDamage);
            Destroy(transform.parent.gameObject);
        }
    }
    
}
