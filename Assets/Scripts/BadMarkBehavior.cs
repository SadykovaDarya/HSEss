using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMarkBehavior : MonoBehaviour {


    public AudioClip Destroy_sound;
    private AudioSource soundSource;

    public bool Check { get; private set; }


    public float fallingSpeed = 0.1f;

    void FixedUpdate()
    {
        if (Check)
        {
            transform.Translate(new Vector3(0f, -0.001f));

        }
        else
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


    void Update()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        AbilityCoolDown cool = character.GetComponent<AbilityCoolDown>();
        if (cool.CoolDownCompleted && cool.Ability.name == "SlowMode") { StartCoroutine("Slow"); }
    }
    IEnumerator Slow()
    {
        var coolDownTimeLeft = 5f;
        while ((coolDownTimeLeft -= Time.deltaTime) > 0)
        {
            Check = true;
            FixedUpdate();
            yield return null;
        }
    }

}
