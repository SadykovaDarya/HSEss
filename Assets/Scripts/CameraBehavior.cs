using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehavior : MonoBehaviour {

    public float offset;
    public Transform target;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject backButton;
    float prevtarget;

    private void Start()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        GameObject charactersbase = GameObject.FindGameObjectWithTag("Base");
        character.transform.position = new Vector3(0, -0.1f, 0);
        charactersbase.transform.parent = character.transform;
        character.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0);
        character.GetComponent<Rigidbody2D>().gravityScale = 1;

    }

    void Awake() {
		target = GameObject.FindWithTag("Player").transform;
        prevtarget = target.position.y - offset / 100;
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
	
	void Update ()
    {
		if (target == null) {	
			try { 
            	target = GameObject.FindWithTag("Player").transform;
			}catch {
				GameOver ();
			}
        }
        if (prevtarget <= target.position.y - offset / 100) {
            transform.position = new Vector3(transform.position.x, target.position.y - offset / 100, transform.position.z);
            prevtarget = target.position.y - offset / 100;
        }
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player"){
			GameOver ();
        }
    }

	void GameOver(){
		gameOverText.SetActive (true);
		restartButton.SetActive (true);
		backButton.SetActive (true);
	}
}
