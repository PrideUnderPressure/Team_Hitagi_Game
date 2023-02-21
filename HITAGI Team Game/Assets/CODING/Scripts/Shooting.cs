using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public GameObject bulletShotgun;

    public GameObject activeBullet;
    
    public Transform bulletTransform;
    public SpriteRenderer muzzleFlash;
    public bool canFire;
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
    public bool fireLocked;
    
    public List<AudioClip> gunSounds;

    void Start()
    {
        
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        muzzleFlash = GameObject.FindGameObjectWithTag("Muzzle_Flash").GetComponent<SpriteRenderer>();
        muzzleFlash.enabled = false;
        notRolling = true;

        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        mousePosX = mousePos.x;
        mousePosY = mousePos.y;

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        if (notRolling)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenFiring)
                {
                    canFire = true;
                    timer = 0;
                }
            }

            if (Input.GetMouseButton(0) && canFire && fireLocked != true) 
            {
                onShoot.Invoke();
                StartCoroutine(MuzzleFlash());
                if (_audioSource.clip == gunSounds[2])
                {
                    _audioSource.pitch = Random.Range(0.9f, 1f);
                }
                _audioSource.PlayOneShot(_audioSource.clip, 1f);
                
                canFire = false;
                Instantiate(activeBullet, bulletTransform.position, Quaternion.identity);
            }
        }

        maxDmg2 = maxDmg;
    }

    public IEnumerator MuzzleFlash()
    {
        if (fireLocked != true)
        {
            muzzleFlash.enabled = true;
            yield return new WaitForSeconds(0.1f);
            muzzleFlash.enabled = false;
        }

    }

    public void DamageSwitch(float x)
    {
        maxDmg = x;
    }
    
    
    public void SwitchSound(int x)
    {
        _audioSource.clip = gunSounds[x];
        _audioSource.pitch = 1;

    }
}
