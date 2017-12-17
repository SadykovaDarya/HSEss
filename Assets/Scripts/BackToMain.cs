using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour {

	public void BacktoMain()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        Destroy(character);
    }

    public void Restart()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        character.transform.position = new Vector3(0, -0.1f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
