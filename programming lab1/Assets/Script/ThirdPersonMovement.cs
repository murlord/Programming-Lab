using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public float Speed = 6f;




    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direction * Speed * Time.deltaTime);
        }


        LinkedList<string> collectibles = new LinkedList<string>();
        collectibles.AddFirst("SizePotion");
        collectibles.AddFirst("ColorPotion");
       collectibles.AddFirst("SpeedPotion");


        if (Time.timeScale != 0)
        {
            if (Input.GetButtonDown("Fire1") && (collectibles.Contains("SpeedPotion")))
            {

                Run();
            }
        }



    }

    void Run()
    {
        Speed = 100f;

    }
}

