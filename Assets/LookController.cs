using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
  GameObject head;

  float xCameraRotation = 0;

  [SerializeField]
  Vector2 sensitivity = Vector2.one;

  private void Awake()
  {
    head = GetComponentInChildren<Camera>().gameObject;

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  void OnLook(InputValue value)
  {
    Vector2 lookVector = value.Get<Vector2>();

    // Horizontal
    float degreesX = lookVector.x * sensitivity.x * Time.smoothDeltaTime;
    transform.Rotate(Vector3.up, degreesX);

    // Vertical
    float degreesY = -lookVector.y * sensitivity.y * Time.smoothDeltaTime;
    xCameraRotation += degreesY;
    head.transform.localEulerAngles = new(xCameraRotation, 0, 0);
  }

}
