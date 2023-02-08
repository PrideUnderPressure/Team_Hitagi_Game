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

    //Activated by the Player Script Input.1
    void Start()
    {
        scriptShooting = objectShooting.GetComponent<Shooting>();
    }
    private void FixedUpdate()
    {
        whereToSpawn = gameObject.transform.position;
        if (usedWeapon == 1 && weaponSlot1 == 0)
        {
            scriptShooting.fireLocked = true;
        }
        if (usedWeapon == 2 && weaponSlot2 == 0)
        {
            scriptShooting.fireLocked = true;
        }
        
    }

    public void CarriedWeapon1()
    {
        if (usedWeapon != 1)
        {
            Instantiate(gunPrefabsToSpawn[weaponSlot1], whereToSpawn, Quaternion.identity);
            usedWeapon = 1;

        }
    }
    //Activated by the Player Script Input.2
    public void CarriedWeapon2()
    {
        if (usedWeapon != 2)
        {
            Instantiate(gunPrefabsToSpawn[weaponSlot2], whereToSpawn, Quaternion.identity);
            usedWeapon = 2;
        }
    }
    //Activated by the WEAPON PREFAB upon picking up
    public void WeaponPickup(int x)
    {
        //x is the gun number, set when the player activates a gun on the ground (picks it up)
        if (x != weaponSlot1 && weaponSlot1 == 5)
        {
            weaponSlot1 = x;

            if (weaponSlot1 != 0)
            {
                scriptShooting.fireLocked = false;
            }
        }
        else if (x != weaponSlot2 && x != weaponSlot1)
        {
            weaponSlot2 = x;
            
            if (weaponSlot2 != 0)
            {
                scriptShooting.fireLocked = false;
            }
        }
    }

    public void WeaponSwaping()
    {
        
    }
}
