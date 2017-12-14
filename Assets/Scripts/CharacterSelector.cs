using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{

    public GameObject player;
    public Vector3 playerSpawnPosition = new Vector3(520, 400, 0);
    public Character[] characters;
    public GameObject characterSelectPanel;
    public GameObject gameSelectPanel;
    


    public void StartGame(int characterChoise)
    {
       
        characterSelectPanel.SetActive(false);
        gameSelectPanel.SetActive(true);

        player.GetComponent<SpriteRenderer>().sprite = characters[characterChoise].cSprite;
        GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject;

       
        Character selectedCharacter = characters[characterChoise];
        AbilityCoolDown coolDown = spawnedPlayer.GetComponent<AbilityCoolDown>();
        coolDown.Initialize(selectedCharacter.characterAbilities[0]);


    }

    public void GoToCatch()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToDoodle()
    {
        SceneManager.LoadScene("DoodleJump");
    }
}

