using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private static bool isRunning;
	private static bool hasRun;
	public delegate void GameEvent();
	public static event GameEvent gameStarter, gameEnder;
	void Start(){
		isRunning = false;
		hasRun = false;
		}
	public static void triggerGameStart(){
		isRunning = true;
		if(gameStarter!=null){
			gameStarter();
		}
	}
	public static void triggerGameEnd(){
		isRunning = false;
		hasRun = true;
		if(gameEnder!=null){
			gameEnder();
		}


	}
	void Update(){
		if (Input.GetKeyUp ("space") && !isRunning&&!hasRun) {
						//	print ("space was hit");
						triggerGameStart ();
						isRunning = true;
				}
		if (Input.GetKeyUp ("space") && !isRunning && hasRun) {
			Application.LoadLevel(Application.loadedLevel);
				}
	}

}
