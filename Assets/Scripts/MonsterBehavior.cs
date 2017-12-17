using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour {

	public float movingSpeedX = 2f;
	public float movingSpeedY = .03f;
	bool goingRight = true;
	float maxWidth;
	public float offset = 1f;

	void Start () {
		movingSpeedX = movingSpeedX * Time.deltaTime;
		Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = Camera.main.ScreenToWorldPoint(upperCorner);
		maxWidth = targetWidth.x - GetComponent<SpriteRenderer>().bounds.extents.x / 2;
	}

	void Update() {
		if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 2)
			Destroy (gameObject);
	}

	void FixedUpdate () {
		if (goingRight == true) {
			if (transform.position.x <= maxWidth) {
				transform.position = new Vector3 (transform.position.x + movingSpeedX, transform.position.y);
			} else {
				if(tag == "suboch")
					GetComponent<SpriteRenderer> ().flipX = true;
				goingRight = false;
			}
		} else {
			if (transform.position.x >= -maxWidth) {
				transform.position = new Vector3 (transform.position.x - movingSpeedX, transform.position.y);
			} else {
				if (tag == "suboch")
					GetComponent<SpriteRenderer> ().flipX = false;
				goingRight = true;
			}
		}
	}
}
