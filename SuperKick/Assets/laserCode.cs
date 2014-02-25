using UnityEngine;
using System.Collections;

public class laserCode : MonoBehaviour {
	public Vector2 current;
	public Vector2 directiono;
	// Use this for initialization
	private Animator animator;
	void Start () {
		current = transform.localPosition;
		directiono.y = 4;
		float angle = Random.Range (-3f, 3f);
		directiono.x = angle;
		animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		current += directiono*Time.deltaTime;
		transform.localPosition = current;

		if (Mathf.Abs (transform.localPosition.x) > 24)
						GameObject.Destroy (this.gameObject);
				else if (transform.localPosition.y > AlienScript.currentHeight + 20)
						GameObject.Destroy (this.gameObject);
		RaycastHit contact;
		if (Physics.Raycast (transform.localPosition, directiono, out contact,1f)) {
			print (contact.collider);
			Animator.setTrigger(boomTrig);
				}
	}
}
