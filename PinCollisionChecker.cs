using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollisionChecker : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pinAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ball"))
        {
            audioSource.PlayOneShot(pinAudioClip);
        }
    }
}
