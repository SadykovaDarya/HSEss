using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour {

    public string abilityButtonAxisName = "Fire1";
    public Image Mask;
    public Text CoolDownText;
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration=10;
    private float nextReadyTime;
    private float coolDownTimeLeft;
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
        //myButtonImage = GetComponent<Image>();
        //abilitySource = GetComponent<AudioSource>();
        //myButtonImage.sprite = ability.aSprite;
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
        //Mask.fillAmount = (coolDownTimeLeft / coolDownDuration);

    }


  public void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;


    }

}
