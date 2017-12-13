﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject mark;
    private float maxWidth;
    public float timeleft;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject backToMainButton;

    void Start() {
        if (cam == null) {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = mark.GetComponent<SpriteRenderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        StartCoroutine(Spawn());
        UpdateText();
    }

    void FixedUpdate() {
        timeleft -= Time.deltaTime;
        if (timeleft < 0)
        {
            timeleft = 0;
        }
        UpdateText();
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        character.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void UpdateText()
    {
        timerText.text = "Time left: " + Mathf.RoundToInt(timeleft).ToString();
    }

    public IEnumerator Spawn() {
       yield return new WaitForSeconds(2.0f);
        while (timeleft>0) { 
            Vector3 spawnPosition = new Vector3(
               Random.Range(-maxWidth, maxWidth),
                transform.position.y, 0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(mark, spawnPosition, spawnRotation);
           
            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
        }
        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        backToMainButton.SetActive(true);
    }
}
