using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour {

    private Image myButtonImage;
    private Image mask;
    private Ability ability;
    private Sprite coolDownSprite;
    private Sprite coolDownMaskSprite;
    private AudioSource abilitySource;
    private float coolDownDuration = 10f;
    private float nextReadyTime;
    private float coolDownTimeLeft = 10f;
    private bool coolDownCompleted;


    public Sprite CoolDownSprite
    {
        get { return coolDownSprite; }
        set { coolDownSprite = value; }
    }


    public Sprite CoolDownMaskSprite
    {
        get { return coolDownMaskSprite; }
        set { coolDownMaskSprite = value; }
    }


    public float CoolDownTimeLeft
    {
        get { return coolDownTimeLeft; }
        set { coolDownTimeLeft = value; }
    }

    public float CoolDownDuration
    {
        get { return coolDownDuration; }
        set { coolDownDuration = value; }
    }






    public Image MyButtonImage
    {
        get { return myButtonImage; }
        set { myButtonImage = value; }
    }
 
    public Image Mask
    {
        get { return mask; }
        set { mask = value; }
    }



    public bool CoolDownCompleted
    {
        get { return coolDownCompleted; }
        set { coolDownCompleted = value; }
    }


    public Ability Ability
    {
        get { return ability; }
        set { ability = value; }
    }

    public void FixedUpdate()
    {

        coolDownCompleted = (Time.time > nextReadyTime);
        CoolDown();
    }



    public void Initialize(Ability selectedAbility)
    {
        ability = selectedAbility;
        var sounds = GetComponents<AudioSource>();
        abilitySource = sounds[0];
       coolDownSprite = ability.aSprite;
        coolDownMaskSprite = ability.aMaskSprite;
        ability.Initialize();


    }


    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;

    }


  public void ButtonTriggered()
    {
        mask.enabled = true;
        abilitySource.PlayOneShot(ability.aSound, .5f);
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        mask.fillAmount = (coolDownTimeLeft / coolDownDuration);


    }

}
