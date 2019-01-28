using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{
  private Vector3 newPos = new Vector3();
  private float[] orthographicSizes = new float[] { 5.0f, 30.0f };
  private int orthoSizeIndex = 0;
  public float smoothTime = 0.2f;
  private Vector3 currentVelocity = Vector3.zero;
  private float currentConstructionVel = 0.0f;

  // Use this for initialization
  void Start () 
  {
    newPos = transform.position;
  }

  private void LateUpdate()
  {
    transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothTime);
    Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, orthographicSizes[orthoSizeIndex], 
                                                    ref currentConstructionVel, smoothTime);
  }

  public void ChangeRooms(Vector3 position)
  {
    newPos = position;
  }

  public void ToConstructionView()
  {
    if(orthoSizeIndex >= 1)
    {
      orthoSizeIndex = 0;
    }
    else
    {
      orthoSizeIndex++;
    }
    Debug.Log("index = " + orthoSizeIndex);
  }
}


