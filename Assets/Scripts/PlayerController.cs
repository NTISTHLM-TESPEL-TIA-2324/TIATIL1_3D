using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  Vector2 inputVector = Vector2.zero;

  [SerializeField]
  float speed = 2;

  void Update()
  {
    // Make a movement vector based on input & the camera's rotation
    Vector3 movement = Camera.main.transform.right * inputVector.x
      + Camera.main.transform.forward * inputVector.y;

    // Zero the y-value and normalize movement vector
    if (movement.magnitude > 0)
    {
      movement.y = 0;
      movement.Normalize();

      transform.forward = movement;
    }

    // Apply speed & deltatime
    movement = movement * speed * Time.deltaTime;

    // Set animation states
    if (movement.magnitude > 0)
    {
      GetComponent<Animator>().SetBool("Walking", true);
    }
    else
    {
      GetComponent<Animator>().SetBool("Walking", false);
    }

    // Do the actual movement
    GetComponent<CharacterController>().Move(movement);
  }

  void OnMove(InputValue value)
  {
    inputVector = value.Get<Vector2>();
  }
}
