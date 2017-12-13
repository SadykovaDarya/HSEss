using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour {

    public string abilityButtonAxisName = "Fire1";
    public Image Mask;
    public Text CoolDownText;
    [SerializeField] private Ability ability;
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    private GameObject obj;

    public void Start()
    {
        Initialize(ability);
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
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        coolDownDuration = ability.aCoolDown;
        ability.Initialize();
        AbilityReady();

    }

    public void AbilityReady()
    {
        CoolDownText.enabled = false;
        Mask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float cd = Mathf.Round(coolDownTimeLeft);
        CoolDownText.text = cd.ToString();
        Mask.fillAmount = (coolDownTimeLeft / coolDownDuration);

    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        Mask.enabled = true;
        abilitySource.clip = ability.aSound;
        abilitySource.Play();
        ability.TriggerAbility();


    }

}
