using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/DAbility")]
public class DAbility : Ability {

    private DAbilityTriggerable dAtrigger;

    public override void Initialize(GameObject obj)
    {
        dAtrigger = obj.GetComponent<DAbilityTriggerable>();
        dAtrigger.Initialize();


    }
    public override void TriggerAbility()
    {
        dAtrigger.Skip();
    } 

}
