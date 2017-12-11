using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour {

	public GameObject player;
	public float diameter;

	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	void FixedUpdate () {
		if (player.GetComponent<CircleCollider2D>().transform.position.y -
			(diameter = 2 * player.GetComponent<CircleCollider2D>().radius) -
			diameter / 2 >
			GetComponent<Collider2D> ().transform.position.y) {
			GetComponent<Collider2D> ().enabled = true;
		} else
			GetComponent<Collider2D> ().enabled = false;
	}
}