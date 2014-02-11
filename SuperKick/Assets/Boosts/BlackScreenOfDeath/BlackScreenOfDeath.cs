using UnityEngine;
using System.Collections;

public class BlackScreenOfDeath : MonoBehaviour {

	private Vector3 newPos = new Vector3(0, 0, -6);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		newPos.y = AlienScript.currentHeight;
		transform.localPosition = newPos;
	}
}
