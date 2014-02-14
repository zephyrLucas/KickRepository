using UnityEngine;
using System.Collections;

public class Player1 : Player {
	

	public override void initialization(){
		xStart = -5f;
		yStart = 8f;
	}
	public override void death(){

		TextManager.winnerIsOne = false;
		GameManager.triggerGameEnd ();
		//uncomment that to make the game end when he dies.
		}
	protected override bool isMovingRight() {
		if(Input.GetKey(KeyCode.D) || OuyaExampleCommon.GetAxis(OuyaSDK.AXIS_LSTICK_X, OuyaSDK.OuyaPlayer.player1) > .01f) {
			return true;
		}
		return false;
	}

	protected override bool isMovingLeft() {
		if(Input.GetKey(KeyCode.A || OuyaExampleCommon.GetAxis(OuyaSDK.AXIS_LSTICK_X, OuyaSDK.OuyaPlayer.player1) < -.01f)) {
			return true;
		}
		return false;
	}

	protected override bool isJumping() {
		if(Input.GetKeyDown(KeyCode.C || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_O, OuyaSDK.OuyaPlayer.player1)) {
			return true;
		}
		return false;
	}

	protected override bool isKicking() {
		if(Input.GetKeyDown(KeyCode.V || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_A, OuyaSDK.OuyaPlayer.player1))) {
			return true;
		}
		return false;
	}

	protected override bool isUsingBoost1() {
		if(Input.GetKeyDown(KeyCode.B) || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_Y, OuyaSDK.OuyaPlayer.player1)) {
			return true;
		}
		return false;
	}

	protected override bool isUsingBoost2() {
			if(Input.GetKeyDown(KeyCode.N) || OuyaExampleCommon.GetButton(OuyaSDK.BUTTON_U, OuyaSDK.OuyaPlayer.player1)) {
			return true;
		}
		return false;
	}



	
	// Update is called once per frame

}
