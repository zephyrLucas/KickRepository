using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {
	public CharacterController controller;
	public Vector2 startPos;
	public Vector2 newPos;

	public Vector2 kickCast;
	public float xStart;
	public float yStart;
	public float distance;
	// Use this for initialization
	
	void Start () {
		initialization ();

		startPos.x = xStart;
		startPos.y = yStart;
		newPos = startPos;
		transform.localPosition=startPos;



	}
	public abstract void initialization();

	// Update is called once per frame
	void Update () {
		newPos.y += 5 * Time.deltaTime;
		newPos.x += 5 * Time.deltaTime;
		transform.localPosition = newPos;
		RaycastHit2D groundCheck = Physics2D.Raycast (newPos, -Vector2.up);
		if (groundCheck != null) {
			distance = Mathf.Abs(groundCheck.point.y-newPos.y);



		}

		print(distance.ToString());
	}
	

}
