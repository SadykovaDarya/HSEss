using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StudentController : MonoBehaviour {
    
    public float force = 200f;
    float objectSpeed = 0f;

    void UpdateSpeed() {
        
            objectSpeed = GetComponent<Rigidbody2D>().velocity.x;
    }


    void PushLeft() {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(-force, 0f));
        UpdateSpeed();
    }

    void PushRight() {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(force, 0f));
        UpdateSpeed();
    }



    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            GameObject character = GameObject.FindGameObjectWithTag("Player");
            AbilityCoolDown cool = character.GetComponent<AbilityCoolDown>();
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (objectSpeed > 0)
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                if (cool.CoolDownCompleted && cool.Ability.name == "FastMode" && cool.CoolDownCompleted)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(-400f, 0f));

                    UpdateSpeed();
                }
                else
                    PushLeft();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (objectSpeed < 0)
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                if (cool.CoolDownCompleted && cool.Ability.name == "FastMode" && cool.CoolDownCompleted)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(400f, 0f));

                    UpdateSpeed();
                }
                else
                    PushRight();
            }
        }
    }

    void FixedUpdate() { 
        UpdateSpeed();
    }

}
