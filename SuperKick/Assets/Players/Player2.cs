using UnityEngine;
using System.Collections;

public class Player2 : Player {

	// Use this for initialization
	public override void initialization () {

		xStart = 5f;
		yStart = 8f;
	}

	protected override bool isMovingRight() {
		if(Input.GetKey(KeyCode.L)) {
			return true;
		}
		return false;
	}
	
	protected override bool isMovingLeft() {
		if(Input.GetKey(KeyCode.J)) {
			return true;
		}
		return false;
	}
	
	protected override bool isJumping() {
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
			return true;
		}
		return false;
	}

	protected override bool isKicking() {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			return true;
		}
		return false;
	}
	// Update is called once per frame

}
