using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedpackScript : MonoBehaviour
{
    public bool canPickup = false;
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickup = true;
            var pStats = other.GetComponent<Player_Stats>();
            if (pStats.health != 100 )
            {
                pStats.health += 30;
                if (pStats.health > 100)
                    pStats.health = 100;
                Destroy(transform.parent.gameObject);
            }
            else if (pStats.health >= 100)
            {
                Debug.Log("DoNothing");
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickup = false;
        }
    }

}
