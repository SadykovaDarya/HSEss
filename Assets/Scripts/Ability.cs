using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {
    public string aName = "New ability";
    public float aBaseCoolDown = 1f;
    public Sprite aSprite;
    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();

	
}
