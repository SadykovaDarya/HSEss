using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject {
    public string characterName = "Default";
    public Sprite cSprite;
    public Ability[] characterAbilities;
}
