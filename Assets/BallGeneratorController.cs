using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneratorController : MonoBehaviour
{
  [SerializeField]
  GameObject ballPrefab;

  float timer = 3;

  [SerializeField]
  float timerMax = 3;

  // Update is called once per frame
  void Update()
  {
    timer -= Time.deltaTime;

    if (timer < 0)
    {
      timer = timerMax;

      Vector3 littleJitter = new(
        Random.Range(-0.2f, 0.2f),
        0,
        Random.Range(-0.2f, 0.2f)
      );

      Instantiate(ballPrefab, transform.position + littleJitter, Quaternion.identity);
    }
  }
}
