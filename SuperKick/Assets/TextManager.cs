﻿using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {
	public GUIText startInfo;
	public GUIText victorOne;
	public GUIText victorTwo;
	public static bool winnerIsOne;
	// Use this for initialization
	void Start () {
		GameManager.gameEnder += gameEnd;
		GameManager.gameStarter += gameStart;
		startInfo.enabled = true;
		victorOne.enabled = false;
		victorTwo.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void gameStart(){
		startInfo.enabled = false;
		}
	void gameEnd(){
			if (winnerIsOne) {
				victorOne.enabled = true;
					} 
			else
				victorTwo.enabled = true;
			}
	}
