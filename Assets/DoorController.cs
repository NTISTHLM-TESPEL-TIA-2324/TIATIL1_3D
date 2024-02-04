using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  bool open = false;

  void OnActivate()
  {
    open = !open;
    GetComponent<Animator>().SetBool("open", open);
  }
}
