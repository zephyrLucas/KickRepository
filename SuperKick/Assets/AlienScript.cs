using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {

	public static float currentHeight;

	private Vector2 newPos;

	// Use this for initialization
	void Start () {
		currentHeight = 0f;
		newPos = new Vector2(0f, 0f);
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
		float increase = Time.deltaTime * 2f;
		currentHeight += increase;
		newPos.y = currentHeight;
		transform.localPosition = newPos;
	}
}
