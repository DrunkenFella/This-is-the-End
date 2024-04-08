using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    Vector2 inputVector = Vector2.zero;
    CharacterController characterController;
    [SerializeField]
    int speed = 5;

    float velocity = 0;

    bool jumpPressed = false;

    [SerializeField]
    int jumpPower = 100;
    [SerializeField]
    float gravityMultiplier = 4;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 movment = transform.right * inputVector.x + transform.forward * inputVector.y;
        movment *= speed;

        velocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        movment.y = velocity;

        if (characterController.isGrounded)
        {
            velocity = -1f;

            if (jumpPressed)
            {
                velocity = jumpPower;
            }
        }

        characterController.Move(movment * Time.deltaTime);
    }
    void OnMove(InputValue value) => inputVector = value.Get<Vector2>();
    void OnJump(InputValue value) => jumpPressed = true;
}
