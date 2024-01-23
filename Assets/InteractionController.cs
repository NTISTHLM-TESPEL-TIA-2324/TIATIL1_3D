using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
  GameObject cameraObject;

  GameObject gazeTarget;

  void Awake()
  {
    cameraObject = GetComponentInChildren<Camera>().gameObject;
  }

  void Update()
  {
    RaycastHit hit;
    Physics.Raycast(
      cameraObject.transform.position,
      cameraObject.transform.forward,
      out hit,
      1.5f
    );

    if (hit.collider != null)
    {
      gazeTarget = hit.collider.gameObject;
    }
    else
    {
      gazeTarget = null;
    }
  }

  void OnFire()
  {
    gazeTarget?.SendMessage("OnInteract");
  }
}
