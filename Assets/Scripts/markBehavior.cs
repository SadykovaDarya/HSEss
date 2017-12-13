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
        if(Check)
        {
            transform.Translate(new Vector3(0f, -1f));

        }
        else 
        transform.Translate(new Vector3(0f, -fallingSpeed));
	}


    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            soundSource = collision.GetComponent<AudioSource>();
            soundSource.PlayOneShot(Destroy_sound, .5f);
        }

        Destroy(gameObject);
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Slow");
        }
    }
    IEnumerator Slow()
    {
        var coolDownTimeLeft = 10f;
        while ( (coolDownTimeLeft-= Time.deltaTime)>0) {
            Check = true;
            FixedUpdate();
            yield return null;
        }
    }



}
