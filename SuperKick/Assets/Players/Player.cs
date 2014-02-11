using UnityEngine;
using UnityEditor;
using System.Collections;
//Chris made changes at line 108 for death
public abstract class Player : PhysicsObject {

	public static float isCold = 0f;
	public static float mindBend = 1f;
	public static float darkness = 0f;
	public static float alpha = 0f;

	public CharacterController controller;
	public Vector2 startPos;
	private Vector2 newPos;

	public GUIText boost1Txt;
	public GUIText boost2Txt;

	public Vector2 kickCast;
	public float xStart;
	public float yStart;

	private bool grounded = true;

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

	protected GameManager GameManager;

	// Use this for initialization
	
	public override void Start () {
		GameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		GameManager.gameEnder += gameEnd;
		GameManager.gameStarter += gameStart;
		animator = this.gameObject.GetComponent<Animator>();

		boost1Txt.guiText.text = boost1;
		boost2Txt.guiText.text = boost2;

		enabled = false;

	}
	void gameEnd(){
		enabled = false;
		//GameManager.gameStarter -= gameStart;
		}
	void gameStart(){
		enabled = true;
		initialization ();
		
		startPos.x = xStart;
		startPos.y = yStart;
		newPos = startPos;
		transform.localPosition=startPos;
		//enabled = true;
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

		if (mindBend < 1f) {
			mindBend += Time.deltaTime;
		}

		if (darkness > 0f) {
			darkness -= Time.deltaTime;
			alpha = Mathf.Min(Time.deltaTime / 2 + alpha, 1);
			//GameObject.Find("OtherBlackScreenOfDeath").GetComponent<Transform>().renderer.material.SetColor("_Color", new Color(0, 0, 0, alpha));
			if( darkness <= 0) {
				alpha = 0;
			}
		} else {
			alpha = Mathf.Max(Time.deltaTime / 2 - alpha, 0);
			//GameObject.Find("OtherBlackScreenOfDeath").GetComponent<Transform>().renderer.material.SetColor("_Color", new Color(0, 0, 0, alpha));
		}

		if (isMovingRight()) {
			horizontalSp += 75f * Time.deltaTime * mindBend;
			dirIsR = true;
			animator.SetBool("IsRunning", true);
			transform.localScale = (new  Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1));

		} else if (isMovingLeft()) {
			horizontalSp += -75f * Time.deltaTime * mindBend;
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
			animator.SetTrigger("jumpTrig");
		}



		Vector2 down = transform.TransformDirection(-Vector2.up);
		Vector2 left = transform.TransformDirection(-Vector2.right);
		Vector2 right = transform.TransformDirection(Vector2.right);

		RaycastHit hit;

		if (Physics.Raycast(transform.position, down, transform.localScale.y / 2 * raycastModifier)) {
			if( GravSpeed < 0f){
				GravSpeed = 0f;
				doubleJump = 0;
				animator.SetBool("isFalling", false);
				if(!grounded) {
					animator.SetTrigger("hitGround");
				}
				grounded = true;
			} else {
				animator.SetBool("isFalling", true);
				grounded = false;
			}
		}

		if(!dirIsR && horizontalSp <= 0) {
			if (Physics.Raycast(transform.position, left, 5 * transform.localScale.y / 8 * raycastModifier)) {
				horizontalSp = 0;
				if(isKicking()) {
					animator.SetTrigger("KickTrig");
					horizontalSp += 45f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, left, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToHSpeed(-45f);
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToVSpeed(-9f);
					}
					if (anyIsBoost(hit.collider.GetComponents<MonoBehaviour>())) {
						boost1 = getBoostO(hit.collider.GetComponents<MonoBehaviour>()).setPow();
						boost1Txt.guiText.text = boost1;
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
					animator.SetTrigger("KickTrig");
					horizontalSp += -45f;
					GravSpeed = 8f;
					Physics.Raycast(transform.position, right, out hit);
					if (anyIsPhysics(hit.collider.GetComponents<MonoBehaviour>())) {
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToHSpeed(45f);
						getPhysicsO(hit.collider.GetComponents<MonoBehaviour>()).addToVSpeed(-9f);
					}
					if (anyIsBoost(hit.collider.GetComponents<MonoBehaviour>())) {
						boost2 = getBoostO(hit.collider.GetComponents<MonoBehaviour>()).setPow();
						boost2Txt.guiText.text = boost2;
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
			boost1Txt.guiText.text = boost1;
		}
		if (isUsingBoost2()) {
			Boost.executePow(boost2, this);
			boost2 = "none";
			boost2Txt.guiText.text = boost2;
		}

		newPos.x += horizontalSp * Time.deltaTime;
		newPos.y += GravSpeed * Time.deltaTime;
		
		transform.localPosition = newPos;
		if (transform.localPosition.y - transform.localScale.y * raycastModifier <= AlienScript.currentHeight) {
			death();
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

	public void makePlatform() {
		doubleJump = 0;
		Transform temp = (Transform) Instantiate(GameObject.Find("PlatformGenerator").GetComponent<PlatfromGenorationScript>().platformPrefab);

		temp.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - transform.localScale.y / 2 * raycastModifier);
	}

	public void makeCold() {
		isCold += 5f;

		GameObject[] plats = GameObject.FindGameObjectsWithTag("platform");
		foreach (GameObject plat in plats) {
			plat.transform.renderer.material = AssetDatabase.LoadAssetAtPath("Assets/PlatformGenorator/IceyForce.mat", typeof(Material)) as Material;
		}
		GameObject.Find("PlatformGenerator").GetComponent<PlatfromGenorationScript>().platformPrefab.renderer.material = AssetDatabase.LoadAssetAtPath("Assets/PlatformGenorator/IceyForce.mat", typeof(Material)) as Material;
	}

	public void bendYourMind() {
		mindBend -= 4f;
	}

	public void stealLight() {
		darkness += 3f;
		alpha = 0;
	}

		protected abstract bool isMovingRight();
		protected abstract bool isMovingLeft();
		protected abstract bool isJumping();
		protected abstract bool isKicking();
		protected abstract bool isUsingBoost1();
		protected abstract bool isUsingBoost2();


	

}
