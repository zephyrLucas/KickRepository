using UnityEngine;
using System.Collections;

public class Player2 : Player {

	// Use this for initialization
	public override void initialization () {

		xStart = 5f;
		yStart = 8f;
	}
	public override void death ()
	{

		TextManager.winnerIsOne = true;
		GameManager.triggerGameEnd ();
		//uncomment that so the game ends when one dies
	}
	protected override bool isMovingRight() {
		if(Input.GetKey(KeyCode.L)) {
		//if(Input.GetKey(KeyCode.L) || OuyaExampleCommon.GetAxis(OuyaSDK.AXIS_LSTICK_X, OuyaSDK.OuyaPlayer.player2) > .01f) {
			return true;
		}
		return false;
	}
	
	protected override bool isMovingLeft() {
		if(Input.GetKey(KeyCode.J)) {
		//if(Input.GetKey(KeyCode.J) || OuyaExampleCommon.GetAxis(OuyaSDK.AXIS_LSTICK_X, OuyaSDK.OuyaPlayer.player2) < -.01f) {
			return true;
		}
		return false;
	}
	
	protected override bool isJumping() {
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
		//if(Input.GetKeyDown(KeyCode.DownArrow) || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_O, OuyaSDK.OuyaPlayer.player2)) {
			return true;
		}
		return false;
	}

	protected override bool isKicking() {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
		//if(Input.GetKeyDown(KeyCode.RightArrow) || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_A, OuyaSDK.OuyaPlayer.player2)) {
			return true;
		}
		return false;
	}

	protected override bool isUsingBoost1() {
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
		//if(Input.GetKeyDown(KeyCode.UpArrow) || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_Y, OuyaSDK.OuyaPlayer.player2)) {
			return true;
		}
		return false;
	}
	
	protected override bool isUsingBoost2() {
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
		//if(Input.GetKeyDown(KeyCode.LeftArrow) || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_U, OuyaSDK.OuyaPlayer.player2)) {
			return true;
		}
		return false;
	}


	// Update is called once per frame

}
