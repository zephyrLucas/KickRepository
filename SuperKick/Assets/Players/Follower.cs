using UnityEngine;
using System.Collections;
//not working!!!
public class Follower : MonoBehaviour {
	public Transform target;
	public Vector2 positionyo;
	// Use this for initialization
	void Start () {
		positionyo.x = target.localPosition.x;
		positionyo.y = AlienScript.currentHeight+7;

		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		positionyo.y = AlienScript.currentHeight+10;
		positionyo.x = target.localPosition.x; 
		if (target.localPosition.y > AlienScript.currentHeight+10) {
				renderer.enabled = true;
			} 
		else
			renderer.enabled = false;
		transform.localPosition = positionyo;
	}
}
