using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RoomTransition : MonoBehaviour 
{
  public Vector2 gridSize;
  public enum DoorType
  {
    up,
    down,
    left,
    right
  }
  public DoorType doorType;
  private BoxCollider2D doorTrigger;
  private Transform cameraTransform;
  private GameObject player;
  public float playerDisplacement;

	// Use this for initialization
	void Start () 
  {
    doorTrigger = gameObject.GetComponent<BoxCollider2D>();
    doorTrigger.isTrigger = true;
    cameraTransform = FindObjectOfType<Camera>().transform;
    player = GameObject.FindGameObjectWithTag("Player");
	}

  private void OnTriggerEnter2D(Collider2D collision)
  {
    ChangeRooms();
  }

  /*pauses the game time and moves the camera 
   to the correct adjacent room*/
  private void ChangeRooms()
  {
    Vector3 newPos = new Vector3();
    Vector3 newPlayerPos = new Vector3();
    float camX = cameraTransform.position.x;
    float camY = cameraTransform.position.y;
    float camZ = cameraTransform.position.z;

    switch (doorType)
    {
      case DoorType.up:
        newPos = new Vector3(camX, camY + gridSize.y, camZ);
        newPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y + playerDisplacement, player.transform.position.z);
        break;

      case DoorType.down:
        newPos = new Vector3(camX, camY - gridSize.y, camZ);
        newPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y - playerDisplacement, player.transform.position.z);

        break;
      case DoorType.left:
        newPos = new Vector3(camX - gridSize.x, camY, camZ);
        newPlayerPos = new Vector3(player.transform.position.x - playerDisplacement, player.transform.position.y, player.transform.position.z);

        break;
      case DoorType.right:
        newPos = new Vector3(camX + gridSize.x, camY, camZ);
        newPlayerPos = new Vector3(player.transform.position.x + playerDisplacement, player.transform.position.y, player.transform.position.z);
        break;

      default:
        break;
    }
    camera.transform.position = newPos;
    player.transform.position = newPlayerPos;
  }
}
