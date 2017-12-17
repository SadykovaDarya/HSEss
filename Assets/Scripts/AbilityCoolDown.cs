using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour {

    public string abilityButtonAxisName = "Fire1";
    private Image myButtonImage;

    public Image MyButtonImage
    {
        get { return myButtonImage; }
        set { myButtonImage = value; }
    }
    private Image mask;

    public Image Mask
    {
        get { return mask; }
        set { mask = value; }
    }

    public Text CoolDownText;
    private Sprite coolDownSprite;
    private Sprite coolDownMaskSprite;
    private AudioSource abilitySource;
    private float coolDownDuration=10f;
    private float nextReadyTime;
    private float coolDownTimeLeft=10f;
    private bool coolDownCompleted;

    public bool CoolDownCompleted
    {
        get { return coolDownCompleted; }
        set { coolDownCompleted = value; }
    }
    private Ability ability;

    public Ability Ability
    {
        get { return ability; }
        set { ability = value; }
    }
    public void Start()
    {
        
    }
    public void FixedUpdate()
    {
        myButtonImage.sprite = coolDownSprite;
        mask.sprite = coolDownMaskSprite;
        mask.fillAmount = (coolDownTimeLeft / coolDownDuration);

        coolDownCompleted = (Time.time > nextReadyTime);
        CoolDown();
    }

    public void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
         if (Input.GetButtonDown(abilityButtonAxisName))
            {
                ButtonTriggered();
            }
            else
            {
                CoolDown();
            }
        }
    }
    public void Initialize(Ability selectedAbility)
    {
        ability = selectedAbility;
        var sounds = GetComponents<AudioSource>();
        abilitySource = sounds[0];
       coolDownSprite = ability.aSprite;
        coolDownMaskSprite = ability.aMaskSprite;
        //coolDownDuration = ability.aCoolDown;
        ability.Initialize();
        //AbilityReady();

    }

    public void AbilityReady()
    {
        CoolDownText.enabled = false;
        Mask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        //float cd = Mathf.Round(coolDownTimeLeft);
        //CoolDownText.text = cd.ToString();
        mask.fillAmount = (coolDownTimeLeft / coolDownDuration);
        

    }


  public void ButtonTriggered()
    {
        abilitySource.PlayOneShot(ability.aSound, .5f);
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        mask.fillAmount = (coolDownTimeLeft / coolDownDuration);


    }

}
