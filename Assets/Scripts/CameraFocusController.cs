using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusController : MonoBehaviour
{
  [SerializeField]
  GameObject target;

  void Update()
  {
    transform.LookAt(target.transform);
  }
}
