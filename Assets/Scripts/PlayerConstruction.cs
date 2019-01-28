using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstruction : MonoBehaviour 
{
  private CameraControl cameraScript;
  private PlayerControlsBasic controllerScript;

  // Use this for initialization
  void Start () 
  {
    controllerScript = gameObject.GetComponent<PlayerControlsBasic>();
    cameraScript = Camera.main.GetComponent<CameraControl>();
  }
	
	// Update is called once per frame
	void Update () 
  {

    if (Input.GetButtonDown("Start"))
    {
      controllerScript.isControllable = !controllerScript.isControllable;
      controllerScript._rigidBody.velocity = Vector2.zero;
      cameraScript.ToConstructionView();
    }
  }
}
