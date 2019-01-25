using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{
  private Vector3 newPos = new Vector3();
  public float smoothTime = 0.2f;
  private Vector3 currentVelocity = Vector3.zero;

  // Use this for initialization
  void Start () 
  {
    newPos = transform.position;
  }

  private void LateUpdate()
  {
    transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothTime);
  }

  public void ChangeRooms(Vector3 position)
  {
    newPos = position;
  }
}

