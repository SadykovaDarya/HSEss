using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

	Transform target;
	public float force;
	public Collider2D platform;
	public bool isTouching;

	void FixedUpdate () {
		if (platform != null) {
			if (isTouching = GetComponent<CapsuleCollider2D> ().IsTouching (platform) &&
			    GetComponent<Rigidbody2D> ().velocity.y <= 0f) {
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, force));
			} else
				platform = null;
		}
    }

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Platform")
			platform = collision.collider;

	}
}