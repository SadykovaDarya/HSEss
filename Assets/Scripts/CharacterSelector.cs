using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {

    public GameObject player;
    public Vector3 playerSpawnPosition = new Vector3(520, 400, 0);
    public Character[] characters;
    public GameObject characterSelectPanel;
    public GameObject abilityPanel;

	public void StartGame(int characterChoise)
    {
        characterSelectPanel.SetActive(false);
        abilityPanel.SetActive(true);
        player.GetComponent<SpriteRenderer>().sprite = characters[characterChoise].cSprite;
        GameObject spawnedPlayer = Instantiate(player, playerSpawnPosition, Quaternion.identity) as GameObject;
        
        AbilityCoolDown[] coolDownButtons = GetComponentsInChildren<AbilityCoolDown> ();
        Character selectedCharacter = characters[characterChoise];

        for (int i = 0; i < coolDownButtons.Length; i++)
        {
            coolDownButtons[i].Initialize(selectedCharacter.characterAbilities[i]);

        }


    }
}
