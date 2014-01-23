using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {

	public static float currentHeight;

	private float speedCurrent = 2f;
	private float speedTarget = 2f;
	private float maxTimeChange = 10f;
	private float timed = 0f;

	private Vector2 newPos;

	// Use this for initialization
	void Start () {
		GameManager.gameStarter += gameStart;
		GameManager.gameEnder += gameEnd;
		enabled = false;
	}
//	void onTriggerEnter(Collider lander){
//				//declare a winner, find out which player it is using tags
//				if (lander.CompareTag ("BlueGuy")) {
//						//red wins
//						print ("blue fell");
//
//				}
//				if (lander.CompareTag ("RedGuy")) {
//						//blue wins
//						print ("red fell");
//				}
//		}
	// Update is called once per frame


	void Update () {

		timed += Time.deltaTime;
		if (timed >= maxTimeChange) {
			timed = 0;
			speedTarget = Mathf.Pow(2f, Random.Range(-2f, 2.7f));
		}

		speedCurrent = speedCurrent + (speedTarget - speedCurrent) * Time.deltaTime;

		float increase = Time.deltaTime * speedCurrent;
		currentHeight += increase;
		newPos.y = currentHeight;
		transform.localPosition = newPos;
	}
	void gameStart(){
		enabled = true;
		currentHeight = 0f;
		newPos = new Vector2(0f, 0f);
		}
	void gameEnd(){
		enabled = false;
		}

}
