using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coursor_Logic : MonoBehaviour {

    Camera cam;

    float maxWidth;
    float maxHeight;
    // Use this for initialization
    void Start () {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetPosition = cam.ScreenToWorldPoint(upperCorner);
        float coursorWidth = GetComponent<Renderer>().bounds.extents.x;
        float coursorHeight = GetComponent<Renderer>().bounds.extents.y;
        maxWidth = targetPosition.x - coursorWidth / 2;
        maxHeight = targetPosition.y - coursorHeight / 2;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, rawPosition.y, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        float targetHeight = Mathf.Clamp(targetPosition.y, -maxHeight, maxHeight);
        targetPosition = new Vector3(targetWidth, targetHeight, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }
}
