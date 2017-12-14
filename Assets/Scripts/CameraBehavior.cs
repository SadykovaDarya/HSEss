using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehavior : MonoBehaviour {

    public float offset;
	public GameObject player;
    public Transform target;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject backButton;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            backButton.SetActive(true);
        }
            

    }
}
