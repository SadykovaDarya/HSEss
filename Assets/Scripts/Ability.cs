using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : ScriptableObject {

    public string aName = "New Ability";
    public Sprite aSprite;
    public Sprite aMaskSprite;
    public AudioClip aSound;
    public float aCoolDown = 1f;
    public Image aImage;


    public abstract void Initialize();
  
}
