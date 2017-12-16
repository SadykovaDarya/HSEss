using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour {

    public GameObject playersbase;

	void Start () {
		playersbase = GameObject.FindWithTag("Base");
	}

	void FixedUpdate () {
        if(playersbase == null)
            playersbase = GameObject.FindWithTag("Base");
        if (playersbase.transform.position.y >
			transform.position.y + GetComponent<SpriteRenderer>().bounds.extents.y / 2) {
			GetComponent<Collider2D> ().enabled = true;
		} else
			GetComponent<Collider2D> ().enabled = false;
	}
}