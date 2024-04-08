using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    Vector2 inputVector = Vector2.zero;

    [SerializeField]
    float speed = 2;

    // Update is called once per frame
    void Update()
    {

        Vector3 movment = Camera.main.transform.right * inputVector.x 
        + Camera.main.transform.forward * inputVector.y;

        if (movment.magnitude > 0)
        {
            movment.y = 0;
            movment.Normalize();

            transform.forward = movment;
        }

        movment = movment * speed * Time.deltaTime;

        if (movment.magnitude > 0)
        {
            GetComponent<Animator>().SetBool("Walk", true);
        }

        else
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }

        GetComponent<CharacterController>().Move(movment);

    }
    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }
}
