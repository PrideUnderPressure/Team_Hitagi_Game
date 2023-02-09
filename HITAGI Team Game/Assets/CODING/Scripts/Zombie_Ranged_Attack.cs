using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Zombie_Ranged_Attack : MonoBehaviour
{
    public GameObject player;
    public GameObject parentObject;
    public GameObject rangedBullet;
    private Camera mainCam;
    private Vector3 playerPos;
    public Transform bulletTransform;
    [FormerlySerializedAs("muzzleFlash")] public SpriteRenderer zombieAttack;
    [FormerlySerializedAs("canFire")] public bool canAttack;
    private float timer;

    public SpriteRenderer muzzleSprite;

    public float timeBetweenFiring;

    public float mousePosX;
    public float mousePosY;

    public UnityEvent onShoot;



    public float maxDmg;



    void Start()
    {
        muzzleSprite.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        parentObject = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        mousePosX = playerPos.x;
        mousePosY = playerPos.y;

        Vector3 rotation = playerPos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void DamageSwitch(float x)
    {
        maxDmg = x;
    }

    public void RangedAttacking()
    {
        Instantiate(rangedBullet, bulletTransform.position, Quaternion.identity);
    }
    
}
