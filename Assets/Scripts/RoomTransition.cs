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
  private Camera camera;
  private GameObject player;
  public float playerDisplacement;

	// Use this for initialization
	void Start () 
  {
    doorTrigger = gameObject.GetComponent<BoxCollider2D>();
    doorTrigger.isTrigger = true;
    camera = FindObjectOfType<Camera>();
    player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
  {
		
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
    switch (doorType)
    {
      case DoorType.up:
        newPos = new Vector3(camera.transform.position.x, camera.transform.position.y + gridSize.y,
          camera.transform.position.z);
        newPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y + playerDisplacement, player.transform.position.z);
        break;
      case DoorType.down:
        newPos = new Vector3(camera.transform.position.x, camera.transform.position.y - gridSize.y,
          camera.transform.position.z);
        newPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y - playerDisplacement, player.transform.position.z);

        break;
      case DoorType.left:
        newPos = new Vector3(camera.transform.position.x - gridSize.x, camera.transform.position.y,
          camera.transform.position.z);
        newPlayerPos = new Vector3(player.transform.position.x - playerDisplacement, player.transform.position.y, player.transform.position.z);

        break;
      case DoorType.right:
        newPos = new Vector3(camera.transform.position.x + gridSize.x, camera.transform.position.y,
          camera.transform.position.z);
        newPlayerPos = new Vector3(player.transform.position.x + playerDisplacement, player.transform.position.y, player.transform.position.z);

        break;
      default:
        break;
    }
    camera.transform.position = newPos;
    player.transform.position = newPlayerPos;
  }
}
