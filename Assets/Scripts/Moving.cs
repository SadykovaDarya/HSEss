using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    public float speed = 4;
    Camera cam;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
	}

    // Update is called once per frame
    void FixedUpdate() {
        float step = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            transform.position = new Vector3(transform.position.x - step, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            transform.position = new Vector3(transform.position.x + step, transform.position.y);
        }   
    }
}
