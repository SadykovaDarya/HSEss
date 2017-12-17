using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour {

    GameObject player;
    GameObject bg1;
    GameObject bg2;
    bool firstIsLower = true;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        bg1 = GameObject.Find("background1");
        bg2 = GameObject.Find("background2");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player == null)
			try{
            player = GameObject.FindWithTag("Player");
		} catch {}
        if (firstIsLower) {
            if(player.transform.position.y >= bg2.transform.position.y){
                bg1.transform.position = new Vector3(bg1.transform.position.x,
                                        bg1.transform.position.y + bg1.GetComponent<SpriteRenderer>().bounds.extents.y);
                firstIsLower = false;
            }
        }
        else {
            if (player.transform.position.y >= bg1.transform.position.y) {
                bg2.transform.position = new Vector3(bg2.transform.position.x,
                	bg2.transform.position.y + bg2.GetComponent<SpriteRenderer>().bounds.extents.y);
                firstIsLower = true;
            }
        }
	}
}
