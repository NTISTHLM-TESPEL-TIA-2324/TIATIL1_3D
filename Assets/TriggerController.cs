using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerController : MonoBehaviour
{
  ActionBasedController controller;
  XRBaseInteractor interactor;

  void Awake()
  {
    controller = GetComponent<ActionBasedController>();
    interactor = GetComponentInChildren<XRDirectInteractor>();

    controller.activateAction.action.started += OnTrigger;
  }

  void OnTrigger(InputAction.CallbackContext context)
  {
    foreach(IXRSelectInteractable thing in interactor.interactablesSelected)
    {
      GunController gun = thing.transform.gameObject.GetComponent<GunController>();

      if (gun != null)
      {
        gun.PullTrigger();
      }
    }
    // print(interactor.interactablesSelected.Count);

    // print("Bang!");
  }
}
