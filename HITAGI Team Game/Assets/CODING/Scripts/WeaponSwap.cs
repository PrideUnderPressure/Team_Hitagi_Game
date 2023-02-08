using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public List<GameObject> gunPrefabsToSpawn;
    //Initialize an invisible gun object on the player on click
    //The weapon must save in a Weapon Slot. If Slot 1 is occupied, it takes Slot 2
    public int weaponSlot1 = 0;
    public int weaponSlot2 = 0;
    //When a weapon is picked up, the int must change to it's corresponding number.
    //When a second weapon is picked up, it must check for both ints. First, the first slot, then second.
    //PICKS UP ONLY IF: 1. First Slot is empty. 2. Second Slot is empty, and first slot DOES NOT equal to the picked up gun number.
    //DOESN'T PICK UP IF: 1. Second slot is empty, but first slot has the same number as the picked up gun. 
    public int usedWeapon = 0;
    private new Vector3 whereToSpawn;
    public GameObject objectShooting;
    public Shooting scriptShooting;

    public float pickupFirepower;
    public float pickupMaxDamage;
    public float fireRate1 = 0;
    public float maxDamage1;
    public float fireRate2 = 0;
    public float maxDamage2;
    
    public Player_Gun_Script gun;

    public bool canSwap = true;
    //Activated by the Player Script Input.1
    void Start()
    {
        scriptShooting = objectShooting.GetComponent<Shooting>();
        gun = GameObject.FindGameObjectWithTag("Selected_Gun").GetComponent<Player_Gun_Script>();
        gun.SwitchGun(weaponSlot1);
        WeaponPickup(0, 0, 0);

    }
    private void FixedUpdate()
    {
        if (usedWeapon == 1 && weaponSlot1 == 0 && scriptShooting.fireLocked != true)
        {
            scriptShooting.fireLocked = true;
        }
        if (usedWeapon == 2 && weaponSlot2 == 0 && scriptShooting.fireLocked != true)
        {
            scriptShooting.fireLocked = true;
        }
        if (weaponSlot1 != 0 && usedWeapon == 1 && scriptShooting.fireLocked != false)
        {
            scriptShooting.fireLocked = false;
        }

        if (weaponSlot2 != 0 && usedWeapon == 2 && scriptShooting.fireLocked != false)
        {
            scriptShooting.fireLocked = false;
        }
    }

    public void CarriedWeapon1(bool pickup)
    {
        if (usedWeapon != 1 && canSwap || pickup)
        {
                usedWeapon = 1;
                scriptShooting.timeBetweenFiring = fireRate1;
                scriptShooting.DamageSwitch(maxDamage1);
                scriptShooting.canFire = true;
                gun.SwitchGun(weaponSlot1);
                canSwap = false;
                StartCoroutine(SwapCd());
        }
    }
    //Activated by the Player Script Input.2
    public void CarriedWeapon2(bool pickup)
    {
        if (usedWeapon != 2 && canSwap || pickup)
        {
                usedWeapon = 2;
                scriptShooting.timeBetweenFiring = fireRate2;
                scriptShooting.DamageSwitch(maxDamage2);
                gun.SwitchGun(weaponSlot2);
                scriptShooting.canFire = true;
                canSwap = false;
                StartCoroutine(SwapCd());

        }
    }
    //Activated by the WEAPON PREFAB upon picking up
    public void WeaponPickup(int x, float fireRate, float maxDamage)
    {
        //x is the gun number, set when the player activates a gun on the ground (picks it up)
        if (usedWeapon == 1)
        {
            if (x != weaponSlot1)
            {
                weaponSlot1 = x;
                fireRate1 = fireRate;
                maxDamage1 = maxDamage;
                CarriedWeapon1(true);
            }

        }
        if (usedWeapon == 2)
        {
            if (x != weaponSlot2)
            {
                weaponSlot2 = x;
                fireRate2 = fireRate;
                maxDamage2 = maxDamage;
                CarriedWeapon2(true);
            }
        }
    }

    IEnumerator SwapCd()
    {
        yield return new WaitForSeconds(0.1f);
        canSwap = true;
    }
}
