﻿using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {
	public Transform lazerPrefab;
	public static float currentHeight;
	public AudioClip laserNoise;
	private float speedCurrent = 2f;
	private float speedTarget = 2f;
	private float maxTimeChange = 10f;
	private float timed = 0f;
	private Vector2 lazerStart;
	private Vector2 newPos;

	public bool playtestmode = false;
	private GameManager GameManager;

	// Use this for initialization
	void Start () {

		GameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
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
			if (playtestmode) {
				speedTarget = Mathf.Pow(2f, -3f);
			}
		}

		speedCurrent = speedCurrent + (speedTarget - speedCurrent) * Time.deltaTime;
		if (speedCurrent < 2f) {
			lazers ();
				}
		float increase = Time.deltaTime * speedCurrent;
		currentHeight += increase;
		newPos.y = currentHeight;
		transform.localPosition = newPos;
	}
	void lazers(){
		//print ("IM A FIRIN MAH LAZAR"); makes sure the method is called
		float chance = Random.Range (1f, 60f);
		if (chance < 6f) {
			audio.PlayOneShot(laserNoise);
						//print ("laser!");
			Transform temp=(Transform)Instantiate(lazerPrefab);
			lazerStart=newPos;
			lazerStart.y+=2.5f;
			temp.localPosition=lazerStart;

				}
		}
	void gameStart(){
		if(this!=null)
		enabled = true;
		currentHeight = 0f;
		newPos = new Vector2(0f, 0f);
		}
	void gameEnd(){
		enabled = false;
		}

}
