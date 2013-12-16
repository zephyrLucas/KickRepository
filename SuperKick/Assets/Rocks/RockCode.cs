using UnityEngine;
using System.Collections;

public class RockCode : MonoBehaviour {


	Vector2 currentVelocity;
	Vector2 nextPos;
	// Use this for initialization
	void Start () {
		nextPos = this.transform.localPosition;
		currentVelocity.x = Random.Range(-3, 3);
		currentVelocity.y = Random.Range(-4, 1);
	}
	
	// Update is called once per frame
	void Update () {
		nextPos = nextPos + (Time.deltaTime * currentVelocity);
		this.transform.localPosition = nextPos;
	}
}
