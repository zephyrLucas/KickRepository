using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {
	public GUIText startInfo;
	// Use this for initialization
	void Start () {
		GameManager.gameEnder += gameEnd;
		GameManager.gameStarter += gameStart;
		startInfo.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void gameStart(){
		startInfo.enabled = false;
		}
	void gameEnd(){
		}
}
