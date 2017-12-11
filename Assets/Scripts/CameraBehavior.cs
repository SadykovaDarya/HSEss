using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
	
	public GameObject player;
	Transform target;

	// Use this for initialization
	void Start () {
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
	}
}
