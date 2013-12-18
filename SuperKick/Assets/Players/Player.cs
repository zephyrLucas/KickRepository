using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour {
	public CharacterController controller;
	public Vector2 startPos;
	private Vector2 newPos;

	public Vector2 kickCast;
	public float xStart;
	public float yStart;
	
//i like turtles
	

	private float gravity = -9.8f;
	private float GravSpeed;

	private float horizontalSp;

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

		if (isMovingRight()) {
			horizontalSp = 3f;
		} else if (isMovingLeft()) {
			horizontalSp = -3f;
		} else {
			horizontalSp = 0f;
		}

		GravSpeed += gravity * Time.deltaTime;

		if(isJumping()) {
			GravSpeed += 9f;
		}



		Vector2 down = transform.TransformDirection(-Vector2.up);

		if (Physics.Raycast(transform.position, down, transform.localScale.y / 2)) {
			if( GravSpeed < 0f){
				GravSpeed = 0f;
			}

		}

		newPos.x += horizontalSp * Time.deltaTime;
		newPos.y += GravSpeed * Time.deltaTime;
		
		transform.localPosition = newPos;

	}

		protected abstract bool isMovingRight();
		protected abstract bool isMovingLeft();
		protected abstract bool isJumping();


	

}
