using UnityEngine;
using System.Collections;

public class AlienScript : MonoBehaviour {

	public static float currentHeight;

	private Vector2 newPos;

	// Use this for initialization
	void Start () {
		currentHeight = 0f;
		newPos = new Vector2(0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		float increase = Time.deltaTime * 2f;
		currentHeight += increase;
		newPos.y = currentHeight;
		transform.localPosition = newPos;
	}
}
