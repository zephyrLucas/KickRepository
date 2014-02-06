using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private bool isRunning;
	private bool hasRun;
	public delegate void GameEvent();
	public event GameEvent gameStarter, gameEnder;
	void Start(){
		isRunning = false;
		hasRun = false;
	}
	public void triggerGameStart(){
		isRunning = true;
		if(gameStarter!=null){
			gameStarter();
		}
	}
	public void triggerGameEnd(){
		isRunning = false;
		hasRun = true;
		if(gameEnder!=null){
			gameEnder();
		}
	}
	void Update(){
		if (Input.GetKeyUp ("space") && !isRunning&&!hasRun) {
						//	print ("space was hit");
			print ("first condition");
						triggerGameStart ();
						isRunning = true;
				}
		if (Input.GetKeyUp ("space") && !isRunning && hasRun) {
			print ("hit space");
			Application.LoadLevel("MenuScene");
		}
	}
}
