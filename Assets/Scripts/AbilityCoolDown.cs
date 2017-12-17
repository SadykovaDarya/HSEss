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
      
        mask.fillAmount = (coolDownTimeLeft / coolDownDuration);
        coolDownCompleted = (Time.time > nextReadyTime);
        CoolDown();
    }
    private void Update()
    {
        myButtonImage.sprite = coolDownSprite;
        mask.sprite = coolDownMaskSprite;
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
        mask.fillAmount = (coolDownTimeLeft / coolDownDuration);

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
