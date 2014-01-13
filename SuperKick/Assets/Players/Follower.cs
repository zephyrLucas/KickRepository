using UnityEngine;
using System.Collections;
//not working!!!
public class Follower : MonoBehaviour {
	public Transform target;
	public Vector2 positionyo;
	// Use this for initialization
	void Start () {
		positionyo.y = 5;
		positionyo.x = target.localPosition.x; 
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (target.localPosition.y > 5) {
				renderer.enabled = true;
			} 
		else
			renderer.enabled = false;
		transform.localPosition = positionyo;
	}
}
