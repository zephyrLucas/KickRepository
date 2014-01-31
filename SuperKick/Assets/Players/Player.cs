﻿using UnityEngine;
using UnityEditor;
using System.Collections;
//Chris made changes at line 108 for death
public abstract class Player : PhysicsObject {

	public static float isCold = 0f;

	public CharacterController controller;
	public Vector2 startPos;
	private Vector2 newPos;

	public Vector2 kickCast;
	public float xStart;
	public float yStart;

	private int doubleJump = 0;
		
	private string boost1 = "none";
	private string boost2 = "none";

	private float raycastModifier = .36f;
//i like turtles

	private Animator animator;

	private float gravity = -9.8f;
	//private float GravSpeed;

	//private float horizontalSp;
	private bool dirIsR = true;

	// Use this for initialization
	
	public override void Start () {
		GameManager.gameEnder += gameEnd;
		GameManager.gameStarter += gameStart;
		animator = this.gameObject.GetComponent<Animator>();

		enabled = false;

	}
	void gameEnd(){
		enabled = false;
		}
	void gameStart(){
		enabled = true;
		initialization ();
		
		startPos.x = xStart;
		startPos.y = yStart;
		newPos = startPos;
		transform.localPosition=startPos;
		enabled = true;
		}
	public abstract void initialization();
	public abstract void death();//called when the player hits the bottom of the screen
	// Update is called once per frame
	public override void Update () {

		if(isCold > 0f) {
			horizontalSp *= Mathf.Pow(.999f, Time.deltaTime);
			isCold -= (Time.deltaTime / 2f);

			if(isCold <= 0f) {
				GameObject[] plats = GameObject.FindGameObjectsWithTag("platform");
			
				foreach (GameObject plat in plats) {
					plat.transform.renderer.material = AssetDatabase.LoadAssetAtPath("Assets/PlatformGenorator/ForceFieldy.mat", typeof(Material)) as Material;
				}
				GameObject.Find("PlatformGenerator").GetComponent<PlatfromGenorationScript>().platformPrefab.renderer.material = AssetDatabase.LoadAssetAtPath("Assets/PlatformGenorator/ForceFieldy.mat", typeof(Material)) as Material;
			}
		} else {
			horizontalSp *= Mathf.Pow(.001f, Time.deltaTime);
		}

		if (isMovingRight()) {
			horizontalSp += 75f * Time.deltaTime;
			dirIsR = true;
			animator.SetBool("IsRunning", true);
			transform.localScale = (new  Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1));

		} else if (isMovingLeft()) {
			horizontalSp += -75f * Time.deltaTime;
			dirIsR = false;
			animator.SetBool("IsRunning", true);
			transform.localScale = (new  Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, 1));
		} else {
			animator.SetBool("IsRunning", false);
		}

		GravSpeed += gravity * Time.deltaTime;

		if(isJumping() && doubleJump < 2) {
			GravSpeed += 9f;
			doubleJump++;
		}



		Vector2 down = transform.TransformDirection(-Vector2.up);
		Vector2 left = transform.TransformDirection(-Vector2.right);
		Vector2 right = transform.TransformDirection(Vector2.right);

		RaycastHit hit;

		if (Physics.Raycast(transform.position, down, transform.localScale.y / 2 * raycastModifier)) {
			if( GravSpeed < 0f){
				GravSpeed = 0f;
				doubleJump = 0;
			}
		}

		if(!dirIsR && horizontalSp <= 0) {
			if (Physics.Raycast(transform.position, left, 5 * transform.localScale.y / 8 * raycastModifier)) {
				horizontalSp = 0;
				if(isKicking()) {
					horizontalSp += 45f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, left, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToHSpeed(-45f);
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToVSpeed(-9f);
					}
					if (anyIsBoost(hit.collider.GetComponents<MonoBehaviour>())) {
						boost1 = getBoostO(hit.collider.GetComponents<MonoBehaviour>()).setPow();
					}

				}
			}
		}

		if(!dirIsR && horizontalSp > 0) {
			if (Physics.Raycast(transform.position, right, 5 * transform.localScale.y / 8 * raycastModifier)) {
				horizontalSp = 0;
			}
		}

		if(dirIsR && horizontalSp >= 0) {
			if (Physics.Raycast(transform.position, right, 5 * transform.localScale.y / 8 * raycastModifier)) {
				horizontalSp = 0;
				if(isKicking()) {
					horizontalSp += -45f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, right, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToHSpeed(45f);
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToVSpeed(-9f);
					}
					if (anyIsBoost(hit.collider.GetComponents<MonoBehaviour>())) {
						boost2 = getBoostO(hit.collider.GetComponents<MonoBehaviour>()).setPow();
					}
				}
			}
		}

		if(dirIsR && horizontalSp < 0) {
			if (Physics.Raycast(transform.position, left, 5 * transform.localScale.y / 8 * raycastModifier)) {
				horizontalSp = 0;
			}
		}


		if (isUsingBoost1()) {
			Boost.executePow(boost1, this);
			boost1 = "none";
		}
		if (isUsingBoost2()) {
			Boost.executePow(boost2, this);
			boost2 = "none";
		}

		newPos.x += horizontalSp * Time.deltaTime;
		newPos.y += GravSpeed * Time.deltaTime;
		
		transform.localPosition = newPos;
		if (transform.localPosition.y - transform.localScale.y <= AlienScript.currentHeight) {
			//death();
		}

		if(Mathf.Abs(transform.localPosition.x) >= 10) {
			death();
		}


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


	private bool anyIsBoost(MonoBehaviour[] stuff) {
		bool any = false;
		if(stuff.Length != 0) {
			foreach (MonoBehaviour script in stuff) {
				any = any || (script is Boost);
			}
		}
		return any;
	}
	
	private Boost getBoostO(MonoBehaviour[] morestuff) {
		foreach (MonoBehaviour script in morestuff) {
			if(script is Boost) {
				return ((Boost) script);
			}
		}
		return null;
	}

	public void superJump() {
		GravSpeed += 30;
	}

	public void makeRock() {
		Transform temp = (Transform) Instantiate(GameObject.Find("RockGenerator").GetComponent<RockThrower>().rockPrefab);

		temp.GetComponent<RockCode>().setSpeed(horizontalSp * 4, 0);
		temp.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
	}

	public void makeCold() {
		isCold += 8f;

		GameObject[] plats = GameObject.FindGameObjectsWithTag("platform");
		foreach (GameObject plat in plats) {
			plat.transform.renderer.material = AssetDatabase.LoadAssetAtPath("Assets/PlatformGenorator/IceyForce.mat", typeof(Material)) as Material;
		}
		GameObject.Find("PlatformGenerator").GetComponent<PlatfromGenorationScript>().platformPrefab.renderer.material = AssetDatabase.LoadAssetAtPath("Assets/PlatformGenorator/IceyForce.mat", typeof(Material)) as Material;
	}

		protected abstract bool isMovingRight();
		protected abstract bool isMovingLeft();
		protected abstract bool isJumping();
		protected abstract bool isKicking();
		protected abstract bool isUsingBoost1();
		protected abstract bool isUsingBoost2();


	

}
