using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Zombie_Attack : MonoBehaviour
{
    public GameObject player;
    public GameObject parentObject;
    private Camera mainCam;
    private Vector3 playerPos;
    public GameObject meleeVfx;
    public Transform bulletTransform;
    [FormerlySerializedAs("muzzleFlash")] public SpriteRenderer zombieAttack;
    [FormerlySerializedAs("canFire")] public bool canAttack;
    private float timer;

    public float timeBetweenFiring;

    public float mousePosX;
    public float mousePosY;

    public UnityEvent onShoot;

    public AudioSource _audioSource;
    public bool notRolling;

    public float maxDmg;
    public float maxDmg2;
    public int maxAmmo;
    public float ammo;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parentObject = gameObject.transform.parent.gameObject;

        zombieAttack = gameObject.transform.Find("Attack_Vfx").GetComponent<SpriteRenderer>();
        zombieAttack.enabled = false;

        _audioSource = gameObject.GetComponent<AudioSource>();
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
            if (!canAttack)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canAttack = true;
                    timer = 0;
                }
            }
            
            maxDmg2 = maxDmg;
    }

    public IEnumerator MuzzleFlash()
    {
        zombieAttack.enabled = true;
        yield return new WaitForSeconds(0.1f);
        zombieAttack.enabled = false;
        
    }

    public void DamageSwitch(float x)
    {
        maxDmg = x;
    }
}
