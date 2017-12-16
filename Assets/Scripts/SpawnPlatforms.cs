using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {
    //meme
    public GameObject platform;
    public Vector3 position;
    float maxWidth;
    List<GameObject> platforms;

    void Start () {
        platform = GameObject.FindWithTag("Platform");
        platforms = new List<GameObject>() { platform };
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = Camera.main.ScreenToWorldPoint(upperCorner);
        maxWidth = targetWidth.x - platform.GetComponent<SpriteRenderer>().bounds.extents.x;
        position = new Vector3(Random.Range(-maxWidth, maxWidth), platform.transform.position.y, 0f);    
	    for(int i=0; i<5; i++) {
            UpdatePosition();
            platforms.Add(Instantiate(platform, position, new Quaternion()));
        }
	}

    void Update() {
        foreach(var plat in platforms) {
            if (plat.transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
                plat.transform.position = UpdatePosition();
        }
    }

    Vector3 UpdatePosition(){
        return position = new Vector3(Random.Range(-maxWidth, maxWidth), position.y + Random.Range(.8f, 1.2f), 0f);
    }
}
