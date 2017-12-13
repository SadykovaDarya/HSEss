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
        SceneManager.LoadScene("Main");
    }

}
