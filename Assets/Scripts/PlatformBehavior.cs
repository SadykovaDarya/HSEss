using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour {

	public GameObject player;
	public float radius;

	void Start () {
		player = GameObject.FindWithTag("Player");
        radius = player.GetComponent<CapsuleCollider2D>().size.y / 2;
	}

	void FixedUpdate () {
		if (player.GetComponent<CapsuleCollider2D>().transform.position.y -
			 radius >
			GetComponent<Collider2D> ().transform.position.y) {
			GetComponent<Collider2D> ().enabled = true;
		} else
			GetComponent<Collider2D> ().enabled = false;
	}
}