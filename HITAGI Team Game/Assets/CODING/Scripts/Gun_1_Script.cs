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
    public float maxDamage;
    public float maxAmmo;
    public GameObject text;

    public MeshRenderer textRenderer;

    void Start()
    {
        textRenderer.enabled = false;
        textRenderer.sortingOrder = 50;
        player = GameObject.FindGameObjectWithTag("Shooting_Object");
        gun = GameObject.FindGameObjectWithTag("Selected_Gun").GetComponent<Player_Gun_Script>();

        shootScript = player.GetComponent<Shooting>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textRenderer.enabled = true;
            if (Input.GetKey(KeyCode.F))
            {
                other.GetComponent<WeaponSwap>().WeaponPickup(whichToSwitch, firerate, maxDamage);
                Destroy(transform.parent.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textRenderer.enabled = false;
        }
    }

}
