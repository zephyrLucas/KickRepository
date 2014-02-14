using UnityEngine;
using System.Collections;

public class PlatfromGenorationScript : MonoBehaviour {

	public Transform platformPrefab;
	public Transform wallPrefab;
	public Transform boostPrefab;
	private ArrayList platforms = new ArrayList();
	private ArrayList walls=new ArrayList();
	public Vector2 nextPos;
	public Vector2 wallPosLeft;
	public Vector2 wallPosRight;
	public Vector2 boostPos;
	private GameManager GameManager;

	public bool extraBoost = false;
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		GameManager.gameStarter += gameStart;
		GameManager.gameEnder += gameEnd;
		enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		createTheGround();
		boostGenerate ();
		destroyTheGround();
	}
	void gameStart(){
		enabled = true;

		platformPrefab.renderer.material = Resources.LoadAssetAtPath("Assets/Resources/ForceFieldy.mat", typeof(Material)) as Material;

		wallPosLeft.x = -10;
		wallPosLeft.y = 5;
		wallPosRight.y = 5;
		wallPosRight.x = 10;
		for(int i = 0; i < 14; i++) {
			innitialcreate();
		}
		Transform init1 = (Transform)Instantiate (wallPrefab);
		Transform init2 = (Transform)Instantiate (wallPrefab);
		init1.localPosition = wallPosLeft;
		init2.localPosition = wallPosRight;
		walls.Add (init1);
		walls.Add (init2);
		}
	void gameEnd(){
		enabled = false;
	}
	private void innitialcreate() {
		Transform temp = (Transform) Instantiate(platformPrefab);
		platforms.Add(temp);
		nextPos.x = Random.Range(-10, 10);
		nextPos.y = (float) (Random.Range(0, 10) + ((int) AlienScript.currentHeight));
		temp.localPosition = nextPos;
	}
	public void boostGenerate(){
		boostPos = nextPos;
		float chance = 0;
		if (extraBoost) {
			chance = Random.Range (1, 81);
		} else {
			chance = Random.Range (1, 729);//place holder, 1 in x chance of generating a boost
		}

		if (chance == 3) {
			Transform newBoost=(Transform)Instantiate(boostPrefab);
			boostPos.y+=1;
			newBoost.localPosition=boostPos;

		}
	}
	private void createTheGround() {
		if(platforms.Count < 14) {
			Transform temp = (Transform) Instantiate(platformPrefab);
			platforms.Add(temp);
			nextPos.x = Random.Range(-10, 10);
			nextPos.y = (float) (Random.Range(10, 20) + ((int) AlienScript.currentHeight));
			temp.localPosition = nextPos;

		}
		while(walls.Count < 20) {
			Transform tempL=(Transform) Instantiate(wallPrefab);
			Transform tempR=(Transform) Instantiate (wallPrefab);
			tempR.localPosition=wallPosRight;
			tempL.localPosition=wallPosLeft;
			walls.Add(tempL);
			walls.Add (tempR);
			wallPosLeft.y+=10;
			wallPosRight.y+=10;
		}

	}

	private void destroyTheGround() {
				int lowestP = lowestPlatform ();
				if (((Transform)platforms [lowestP]).localPosition.y < AlienScript.currentHeight) {
						GameObject.Destroy (((Transform)platforms [lowestP]).gameObject);
						platforms.RemoveAt (lowestP);
				}
				if (walls[0] != null) {
						if (((Transform)walls [0]).localPosition.y < AlienScript.currentHeight-5) {
								GameObject.Destroy (((Transform)walls [0]).gameObject);
								walls.RemoveAt (0);
								GameObject.Destroy (((Transform)walls [0]).gameObject);
								walls.RemoveAt (0);
						}
				}
		}

	private int lowestPlatform() {
		int x = 0;
		float min = ((Transform) platforms[0]).localPosition.y;
		for(int i = 0; i < platforms.Count; i++) {
			if(((Transform) platforms[i]).localPosition.y < min) {
				min = ((Transform) platforms[i]).localPosition.y;
				x = i;
			}
		}
		return x;
	}

}
