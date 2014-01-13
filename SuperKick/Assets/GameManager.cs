using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private static bool isRunning=false;

	public delegate void GameEvent();
	public static event GameEvent gameStarter, gameEnder;

	public static void triggerGameStart(){
		if(gameStarter!=null){
			gameStarter();
		}
	}
	public static void triggerGameEnd(){
		if(gameEnder!=null){
			gameEnder();
		}


	}
	void Update(){
		if (Input.GetKeyUp ("space") && !isRunning) {
						//	print ("space was hit");
						triggerGameStart ();
						isRunning = true;
				}
	}

}
