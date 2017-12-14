using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public float offset;
	public GameObject player;
    public Transform target;
    float prevtarget;

    
    void Awake() {
		target = player.transform;
        prevtarget = target.position.y - offset / 100;
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
	
	void Update () {
        if (prevtarget <= target.position.y - offset / 100) {
            transform.position = new Vector3(transform.position.x, target.position.y - offset / 100, transform.position.z);
            prevtarget = target.position.y - offset / 100;
        }
	}
}
