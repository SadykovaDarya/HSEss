using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {

    public string aName = "New Ability";
    public Sprite aSprite;
    public AudioClip aSound;
    public float aCoolDown = 1f;


    public abstract void Initialize();
    public abstract void TriggerAbility();
}
