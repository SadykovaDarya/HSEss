using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
	
	public GameObject player;
    public Transform target;
    public float prevtarget;

	// Use this for initialization
	void Start () {
		target = player.transform;
        prevtarget = target.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (prevtarget <= target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
            prevtarget = target.position.y;
        }
	}
}
