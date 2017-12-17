using System;
using System.Collections;
using UnityEditor.VersionControl;
using UnityEngine;

public class markBehavior : MonoBehaviour {


    public AudioClip Destroy_sound;
    private AudioSource soundSource;

    public bool Check { get; private set; }


    public float fallingSpeed = 0.1f;

    void FixedUpdate () {

        transform.Translate(new Vector3(0f, -fallingSpeed));
	}


    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            soundSource = collision.GetComponent<AudioSource>();
            soundSource.PlayOneShot(Destroy_sound, .5f);
        }

        Destroy(gameObject);
    }



}
