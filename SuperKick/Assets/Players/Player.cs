using UnityEngine;
using System.Collections;

public abstract class Player : PhysicsObject {
	public CharacterController controller;
	public Vector2 startPos;
	private Vector2 newPos;

	public Vector2 kickCast;
	public float xStart;
	public float yStart;
	
//i like turtles
	

	private float gravity = -9.8f;
	//private float GravSpeed;

	//private float horizontalSp;
	private bool dirIsR = true;

	// Use this for initialization
	
	public override void Start () {
		initialization ();

		startPos.x = xStart;
		startPos.y = yStart;
		newPos = startPos;
		transform.localPosition=startPos;



	}

	public abstract void initialization();

	// Update is called once per frame
	public override void Update () {

		if (isMovingRight()) {
			horizontalSp += 3f * Time.deltaTime;
			dirIsR = true;
		} else if (isMovingLeft()) {
			horizontalSp += -3f * Time.deltaTime;
			dirIsR = false;
		} else {
			horizontalSp *= Mathf.Pow(.00001f, Time.deltaTime);
		}

		GravSpeed += gravity * Time.deltaTime;

		if(isJumping()) {
			GravSpeed += 9f;
		}



		Vector2 down = transform.TransformDirection(-Vector2.up);
		Vector2 left = transform.TransformDirection(-Vector2.right);
		Vector2 right = transform.TransformDirection(Vector2.right);

		RaycastHit hit;

		if (Physics.Raycast(transform.position, down, transform.localScale.y / 2)) {
			if( GravSpeed < 0f){
				GravSpeed = 0f;
			}
		}

		if(!dirIsR) {
			if (Physics.Raycast(transform.position, left, transform.localScale.y / 2)) {
				horizontalSp = 0;
				if(isKicking()) {
					horizontalSp += 25f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, left, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						print ("dskjhgj dfsf g");
					}
				}
			}
		}
		if(dirIsR) {
			if (Physics.Raycast(transform.position, right, transform.localScale.y / 2)) {
				horizontalSp = 0;
				if(isKicking()) {
					horizontalSp += -25f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, right, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						print ("dskjav rjfbg");
					}
				}
			}
		}

		newPos.x += horizontalSp * Time.deltaTime;
		newPos.y += GravSpeed * Time.deltaTime;
		
		transform.localPosition = newPos;

	}


	private bool anyIsPhysics(MonoBehaviour[] stuff) {
		bool any = false;
		if(stuff.Length != 0) {
			foreach (MonoBehaviour script in stuff) {
				any = any || (script is PhysicsObject);
			}
		}
		return any;
	}

		protected abstract bool isMovingRight();
		protected abstract bool isMovingLeft();
		protected abstract bool isJumping();
		protected abstract bool isKicking();


	

}
