using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunController : MonoBehaviour
{
  private XRGrabInteractable grab;

  void Awake()
  {
    grab = GetComponent<XRGrabInteractable>();

    grab.hoverEntered.AddListener(OnHover);
    grab.hoverExited.AddListener(OnHoverExit);
  }

  private void OnHover(HoverEnterEventArgs args)
  {
    print("Sluta titta på mig!");
  }

  private void OnHoverExit(HoverExitEventArgs args)
  {
    print("Puuuh, tack!");
  }

  public void PullTrigger()
  {
    print("Shoot bullet bang dead");
  }
}
