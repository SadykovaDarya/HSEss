using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoodleJumpScore : MonoBehaviour {

    // Use this for initialization
    private int score;
    float DistanceTravelled = -10f;
    Vector3 lastPosition;

   public  Text ScoreText;

    //public Text Text
    //{
    //    get { return ScoreText; }
    //    set { ScoreText = value; }
    //}
    void Start () {

        score = 0;
        UpdateScore();

    }
	
	// Update is called once per frame

    public void UpdateScore()
    {

        ScoreText.text = "Score:\n" +  Mathf.RoundToInt(DistanceTravelled).ToString();
    }

    private void Update()
    {
        DistanceTravelled +=(Vector3.Distance(transform.position, lastPosition));
        lastPosition = transform.position;
        UpdateScore();
    }
}
