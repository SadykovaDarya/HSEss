﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/SAbility")]
public class SAbility : Ability
{

    private Score dAtrigger;
    [SerializeField] private GameObject player;

    public override void Initialize()
    {
        aName = "Skip";
        dAtrigger = player.GetComponent<Score>();


    }
}
