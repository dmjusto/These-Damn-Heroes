using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerControlsBasic : MonoBehaviour 
{
  private Vector2 direction;
  public Rigidbody2D _rigidBody;
  [SerializeField]
  private float playerSpeed;
  public bool isControllable = true;

  // Use this for initialization
  void Start () 
  {
    _rigidBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
  {
    GetPlayerDirectionInput();
  }

  private void FixedUpdate()
  {
    if (isControllable)
    {
      _rigidBody.velocity = direction;
    }
  }


  //gets player input and assigns a direction and magnitude to direction variable
  private void GetPlayerDirectionInput()
  {
    direction.x = Input.GetAxisRaw("Horizontal");
    direction.x *= playerSpeed;
    direction.y = Input.GetAxisRaw("Vertical");
    direction.y *= playerSpeed;
  }
}
