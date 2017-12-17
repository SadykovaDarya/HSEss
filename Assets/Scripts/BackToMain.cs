using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMain : MonoBehaviour {

	public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        Destroy(character);
    }

    public void Restart()
    {
        Text score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        score.text = "SCORE: 0";
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        character.transform.position = new Vector3(0, -0.1f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
