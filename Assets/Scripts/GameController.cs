using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject[] balls;
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
        float ballWidth = balls[0].GetComponent<SpriteRenderer>().bounds.extents.x;
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
        Score score = character.GetComponent<Score>();
        AbilityCoolDown coolDown = character.GetComponent<AbilityCoolDown>();
        foreach (var obj in FindObjectsOfType<Text>())
        {
            if (obj.tag == "ScoreText") 
            score.Text = obj;
        }
        foreach (var obj in FindObjectsOfType<Image>())
        {
            if (obj.tag == "CoolDownIcon")
                coolDown.MyButtonImage = obj;
            if (obj.tag == "CoolDownMask")
            {
                coolDown.Mask = obj;
               // obj.fillAmount = coolDown.Mask.fillAmount;
            }

        }


    }

    void UpdateText()
    {
        timerText.text = "Time   left: " + Mathf.RoundToInt(timeleft).ToString();
    }

    public IEnumerator Spawn() {
       yield return new WaitForSeconds(2.0f);
        while (timeleft>0) {
            GameObject ball = balls[Random.Range(0, balls.Length)];
            Vector3 spawnPosition = new Vector3(
               Random.Range(-maxWidth, maxWidth),
                transform.position.y, 0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
           
            yield return new WaitForSeconds(Random.Range(1.0f,2.0f));
        }
        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        backToMainButton.SetActive(true);
    }
}
