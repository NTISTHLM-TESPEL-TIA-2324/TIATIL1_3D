using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
  [SerializeField]
  GameObject objectToActivate;

  private void OnInteract()
  {
    objectToActivate?.SendMessage(
      "OnActivate",
      SendMessageOptions.DontRequireReceiver
    );
  }

  private void OnGazeEnter()
  {
    GetComponent<Renderer>().material.color = Color.green;
  }

  private void OnGazeExit()
  {
    GetComponent<Renderer>().material.color = Color.white;
  }
}
