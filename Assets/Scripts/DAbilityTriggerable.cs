using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DAbilityTriggerable : MonoBehaviour {
    private float fallingSpeed = 5f;
    private bool check;
    public void Initialize()
    {

    }


    void FixedUpdate()
    {
        if (check)
        {
            transform.Translate(new Vector3(0f, -fallingSpeed));
        }

    }

    public void AlterTrigger()
    {
        check = true;
        FixedUpdate();
    }
}
