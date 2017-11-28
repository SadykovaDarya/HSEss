﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject mark;
    private float maxWidth;
    public float timeleft;
  


    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = mark.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        StartCoroutine(Spawn());
    }

    void FixedUpdate()
    {
       
            timeleft -= Time.deltaTime;
           
    }

    public IEnumerator Spawn()
    {
       yield return new WaitForSeconds(2.0f);
        while (timeleft>0)
        {
            Vector3 spawnPosition = new Vector3(
               Random.Range(-maxWidth, maxWidth),
                transform.position.y, 0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(mark, spawnPosition, spawnRotation);
           
            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
        }

        
    }
}
