using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Abilities/SlowMode")]
public class AddTimeAbility : Ability {

    private SlowModeTriggerable timer;
    private float fallingSpeed = 0.01f;
    public override void Initialize(GameObject obj)
    {
        timer = obj.GetComponent<SlowModeTriggerable>();
        timer.Initialize();
      //  timer.mark = obj.Mark; тут как то надо передать оценочку мммм
        timer.fallingSpeed = fallingSpeed;
    }
    public override void TriggerAbility()
    {
        timer.Slow();
    }

    }
