using UnityEngine;
using System.Collections;

public class Player1 : Player {
	
	void Start () {
		controller = GetComponent<CharacterController> ();
		startPos.x=-5;
		startPos.y=6;
		transform.localPosition = startPos;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
