using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text ScoreText;
    public int ballValue;
    private int score;
    private AbilityCoolDown coolDown;

    private void Start()
    {
        score = 0;
        UpdateScore();
    }

   public void UpdateScore()
    {
      ScoreText.text = "Score:\n" + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coolDown = GetComponent<AbilityCoolDown>();

        if (collision.gameObject.tag == "BadMark")
        {
            if (coolDown.CoolDownCompleted && coolDown.Ability.name == "SkipBadMark")
            {
                coolDown.ButtonTriggered();
                UpdateScore();
            }
            else
            {
                score -= ballValue;
                UpdateScore();
            }

        }
        else
        {
            score += ballValue;
            UpdateScore();
        }

    }


}
