using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public SpriteRenderer muzzleFlash;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public float mousePosX;
    public float mousePosY;
    public UnityEvent onShoot;

    public AudioSource _audioSource;
    


    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        muzzleFlash = GameObject.FindGameObjectWithTag("Muzzle_Flash").GetComponent<SpriteRenderer>();
        muzzleFlash.enabled = false;

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
        if (Input.GetMouseButton(0) && canFire)
        {
            onShoot.Invoke();
            StartCoroutine(MuzzleFlash());
            _audioSource.PlayOneShot(_audioSource.clip, 1f);
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }


    }

    public IEnumerator MuzzleFlash()
    {
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        muzzleFlash.enabled = false;
        
    }

}
