using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour {

    public float activePlayers;
    public float backGroundWidth;
    public float playerspos;
    public float targetspos;
    GameObject clone;
	// Update is called once per frame
    void Start() {
        backGroundWidth = GameObject.Find("background1").GetComponent<SpriteRenderer>().bounds.extents.x * 2;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        activePlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (activePlayers == 1) {
            if (gameObject.transform.position.x > Camera.main.transform.position.x)
                clone = Instantiate(gameObject, new Vector3(transform.position.x - backGroundWidth, transform.position.y), new Quaternion());
            else
                clone = Instantiate(gameObject, new Vector3(transform.position.x + backGroundWidth, transform.position.y), new Quaternion());
            activePlayers++;
        }
    }

    void FixedUpdate() {
		if(clone != null){
			clone.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            clone.transform.position = new Vector3(clone.transform.position.x, transform.position.y);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (activePlayers == 2) {
            if (transform.position.x < Camera.main.transform.position.x - backGroundWidth / 2 || 
                transform.position.x > Camera.main.transform.position.x + backGroundWidth / 2) {
                Destroy(gameObject);
                activePlayers--;
            }
        }
    }
}
