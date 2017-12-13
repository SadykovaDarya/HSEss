using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour {

	public GameObject player;
	public float radius;

	void Start () {
		player = GameObject.FindWithTag("Player");
        radius = player.GetComponent<CircleCollider2D>().radius;
	}

	void FixedUpdate () {
		if (player.GetComponent<CircleCollider2D>().transform.position.y -
			 player.GetComponent<SpriteRenderer>().bounds.extents.y / 2 - radius >
			GetComponent<Collider2D> ().transform.position.y) {
			GetComponent<Collider2D> ().enabled = true;
		} else
			GetComponent<Collider2D> ().enabled = false;
	}
}