using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Abilities/AddTime")]
public class AddTimeAbility : Ability {

    private AddTimeTriggerable timer;
    public override void Initialize(GameObject obj)
    {
        timer = obj.GetComponent<AddTimeTriggerable>();
        timer.Initialize();
    }
    public override void TriggerAbility()
    {
        timer.Add();
    }
}
