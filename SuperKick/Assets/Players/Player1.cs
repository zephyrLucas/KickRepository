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
		if(Input.GetKey(KeyCode.D)) {
			return true;
		}
		return false;
	}

	protected override bool isMovingLeft() {
		if(Input.GetKey(KeyCode.A)) {
			return true;
		}
		return false;
	}

	protected override bool isJumping() {
		if(Input.GetKeyDown(KeyCode.C)) {
			return true;
		}
		return false;
	}

	protected override bool isKicking() {
		if(Input.GetKeyDown(KeyCode.V)) {
			return true;
		}
		return false;
	}

	protected override bool isUsingBoost1() {
		if(Input.GetKeyDown(KeyCode.B)) {
			return true;
		}
		return false;
	}

	protected override bool isUsingBoost2() {
		if(Input.GetKeyDown(KeyCode.N)) {
			return true;
		}
		return false;
	}



	
	// Update is called once per frame

}
