using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
  [SerializeField]
  float speed = 5;

  [SerializeField]
  float jumpForce = 20;

  [SerializeField]
  float gravityMultiplier = 4;

  Vector2 inputVector = Vector2.zero;
  CharacterController characterController;

  float velocityY = 0;
  bool jumpPressed = false;

  void Awake()
  {
    characterController = GetComponent<CharacterController>();
  }

  void Update()
  {
    Vector3 movement = transform.right * inputVector.x +
                      transform.forward * inputVector.y;
    movement *= speed;

    if (characterController.isGrounded)
    {
      velocityY = -1f;
      if (jumpPressed)
      {
        velocityY = jumpForce;
      }
    }

    velocityY += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
    movement.y = velocityY;

    characterController.Move(movement * Time.deltaTime);
    jumpPressed = false;
  }

  void OnMove(InputValue value) => inputVector = value.Get<Vector2>();
  void OnJump(InputValue value) => jumpPressed = true;

}
