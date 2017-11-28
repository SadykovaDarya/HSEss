using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMarks : MonoBehaviour {

    public AudioClip Destroy_sound;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        source.PlayOneShot(Destroy_sound, .5f);
    }

}
