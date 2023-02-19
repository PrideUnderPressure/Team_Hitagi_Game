using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSound : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.8f, 1.0f);
        audioSource.PlayOneShot(audioSource.clip, 1f);
        StartCoroutine(WaitToDie());
    }

    private IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
