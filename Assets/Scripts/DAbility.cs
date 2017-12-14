using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/DAbility")]
public class DAbility : Ability {

    private markBehavior dAtrigger;
    [SerializeField] private GameObject fallingMarks;

    public override void Initialize()
    {
        dAtrigger = fallingMarks.GetComponent<markBehavior>();


    }


}
