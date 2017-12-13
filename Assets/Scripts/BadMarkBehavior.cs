using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMarkBehavior : MonoBehaviour {


    public AudioClip Destroy_sound;
    private AudioSource soundSource;

    public float fallingSpeed = 0.1f;

    void FixedUpdate()
    {
            transform.Translate(new Vector3(0f, -fallingSpeed));
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soundSource = collision.GetComponent<AudioSource>();
            soundSource.PlayOneShot(Destroy_sound, .5f);
        }

        Destroy(gameObject);
    }

}
