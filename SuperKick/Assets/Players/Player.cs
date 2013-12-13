using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {
	public CharacterController controller;
	public Vector2 startPos;
	public Vector2 newPos;
	public Vector2 downCast;
	public Vector2 kickCast;
	public float xStart;
	public float yStart;
	// Use this for initialization
	
	void Start () {
		initialization ();
		startPos.x = xStart;
		startPos.y = yStart;
		transform.localPosition=startPos;

		

	}
	public abstract void initialization();

	// Update is called once per frame
	void Update () {
		//RaycastHit2D groundCheck = Physics2D.Raycast (newPos, downCast);
	//	if (groundCheck != null) {

	//	}


	}
	

}
