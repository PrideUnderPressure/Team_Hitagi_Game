using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScript : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(audioSource.clip, 1f);
        StartCoroutine(WaitToDie());
    }

    private IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
