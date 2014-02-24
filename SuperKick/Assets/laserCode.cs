using UnityEngine;
using System.Collections;

public class laserCode : MonoBehaviour {
	public Vector2 current;
	public Vector2 direction;
	// Use this for initialization
	void Start () {
		current = transform.localPosition;
		direction.y = 4;
		float angle = Random.Range (-3f, 3f);
		direction.x = angle;
	}
	
	// Update is called once per frame
	void Update () {
		current += direction*Time.deltaTime;
		transform.localPosition = current;

		if (Mathf.Abs (transform.localPosition.x) > 24)
						GameObject.Destroy (this.gameObject);
				else if (transform.localPosition.y > AlienScript.currentHeight + 20)
						GameObject.Destroy (this.gameObject);

	}
}
