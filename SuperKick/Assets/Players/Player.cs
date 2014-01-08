using UnityEngine;
using System.Collections;

public abstract class Player : PhysicsObject {
	public CharacterController controller;
	public Vector2 startPos;
	private Vector2 newPos;

	public Vector2 kickCast;
	public float xStart;
	public float yStart;

	//public Boost[] = new Boost[2]();
	
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

		horizontalSp *= Mathf.Pow(.001f, Time.deltaTime);

		if (isMovingRight()) {
			horizontalSp += .75f;
			dirIsR = true;
		} else if (isMovingLeft()) {
			horizontalSp += -.75f;
			dirIsR = false;
		} else {

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
					horizontalSp += 45f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, left, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToHSpeed(-5f);
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToVSpeed(-3f);
					}
				}
			}
		}
		if(dirIsR) {
			if (Physics.Raycast(transform.position, right, transform.localScale.y / 2)) {
				horizontalSp = 0;
				if(isKicking()) {
					horizontalSp += -45f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, right, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToHSpeed(5f);
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToVSpeed(-3f);
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

	private PhysicsObject getPhysicsO(MonoBehaviour[] morestuff) {
		foreach (MonoBehaviour script in morestuff) {
			if(script is PhysicsObject) {
				return ((PhysicsObject) script);
			}
		}
		return null;
	}

		protected abstract bool isMovingRight();
		protected abstract bool isMovingLeft();
		protected abstract bool isJumping();
		protected abstract bool isKicking();
		protected abstract bool isUsingBoost1();
		protected abstract bool isUsingBoost2();


	

}
