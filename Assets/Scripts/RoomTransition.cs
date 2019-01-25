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
  private Vector3 newPos = new Vector3();
  private CameraControl cameraScript;

  // Use this for initialization
  void Start () 
  {
    doorTrigger = gameObject.GetComponent<BoxCollider2D>();
    doorTrigger.isTrigger = true;
    cameraTransform = Camera.main.transform;
    player = GameObject.FindGameObjectWithTag("Player");
    newPos = cameraTransform.position;
    cameraScript = Camera.main.GetComponent<CameraControl>();
	}

  private void OnTriggerEnter2D(Collider2D collision)
  {
    ChangeRooms();
  }

  /*pauses the game time and moves the camera 
   to the correct adjacent room*/
  private void ChangeRooms()
  {

    Vector3 newPlayerPos = new Vector3();
    float camX = cameraTransform.position.x;
    float camY = cameraTransform.position.y;
    float camZ = cameraTransform.position.z;
    float playerX = player.transform.position.x;
    float playerY = player.transform.position.y;
    float playerZ = player.transform.position.z;




    /* depending on which way the door is facing, 
     * we set target positions for the move*/
    switch (doorType)
    {
      case DoorType.up:
        newPos = new Vector3(camX, camY + gridSize.y, camZ);
        newPlayerPos = new Vector3(playerX, playerY + playerDisplacement, playerZ);
        break;

      case DoorType.down:
        newPos = new Vector3(camX, camY - gridSize.y, camZ);
        newPlayerPos = new Vector3(playerX, playerY - playerDisplacement, playerZ);

        break;
      case DoorType.left:
        newPos = new Vector3(camX - gridSize.x, camY, camZ);
        newPlayerPos = new Vector3(playerX - playerDisplacement, playerY, playerZ);

        break;
      case DoorType.right:
        newPos = new Vector3(camX + gridSize.x, camY, camZ);
        newPlayerPos = new Vector3(playerX + playerDisplacement, playerY, playerZ);
        break;

      default:
        break;
    }
    player.transform.position = newPlayerPos;
    cameraScript.ChangeRooms(newPos);
  }

}
