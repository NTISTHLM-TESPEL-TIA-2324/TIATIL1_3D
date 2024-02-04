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
    GameObject oldGazeTarget = gazeTarget;

    UpdateGaze();
    
    if (oldGazeTarget != gazeTarget)
    {
      oldGazeTarget?.SendMessage("OnGazeExit", SendMessageOptions.DontRequireReceiver);
      gazeTarget?.SendMessage("OnGazeEnter", SendMessageOptions.DontRequireReceiver);
    }
  }

  private void UpdateGaze()
  {
    RaycastHit hit;
    Physics.Raycast(
      cameraObject.transform.position,
      cameraObject.transform.forward,
      out hit,
      3f
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
    if (gazeTarget != null)
    {
      gazeTarget.SendMessage(
        "OnInteract",
        SendMessageOptions.DontRequireReceiver
      );
    }
  }
}
