using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlayersPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject character = GameObject.FindGameObjectWithTag("Player");
		character.transform.position = new Vector3(0, -0.1f, 0);
		character.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0);
		character.GetComponent<Rigidbody2D>().gravityScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
