using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour {

	public GameObject[] monsters;
	public float spawningTime=0;
	int meme = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (spawningTime > 0) {
			spawningTime -= Time.deltaTime;
		} else {
			meme += 1;
			Instantiate (monsters [meme % 2], new Vector3 (Camera.main.transform.position.x,
				Camera.main.transform.position.y + 2 * Camera.main.orthographicSize), new Quaternion ());
			spawningTime = 15f;
		}
	}
}
