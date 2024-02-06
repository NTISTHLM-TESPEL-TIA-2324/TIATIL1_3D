using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      Physics.Raycast(mouseRay, out RaycastHit hit);
      transform.position = hit.point;
    }
  }
}
