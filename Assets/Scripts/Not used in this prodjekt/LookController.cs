using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
    GameObject head;

    float yCameraRotation = 0;

    [SerializeField]
    Vector2 sensitivity = Vector2.one;

    [SerializeField]
    float viewAngleLimit = 80;

    private void Awake(){
        head = GetComponentInChildren<Camera>().gameObject;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void OnLook(InputValue value)
    {
        Vector2 lookVector = value.Get<Vector2>();

        float degreesX = lookVector.x * sensitivity.x;

        transform.Rotate(Vector3.up, degreesX);
        float degreesY = -lookVector.y * sensitivity.y;
        yCameraRotation += degreesY;

        head.transform.localEulerAngles = new(yCameraRotation,0,0);
        yCameraRotation = Mathf.Clamp(yCameraRotation, -viewAngleLimit, viewAngleLimit);

    }
}
