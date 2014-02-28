using UnityEngine;
using System.Collections;

public class laserCode : MonoBehaviour {
	public Vector2 current;
	public Vector2 directiono;
	public Vector2 forLaser;
	private bool exploded;
	private float moment1;
	// Use this for initialization
	private Animator animator;
	void Start () {
		exploded = false;
		current = transform.localPosition;
		directiono.y = 4;
		float angle = Random.Range (-3f, 3f);
		directiono.x = angle;
		animator = this.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		current += directiono*Time.deltaTime;
		transform.localPosition = current;
		Ray angled = new Ray (transform.localPosition, directiono);

		if (Mathf.Abs (transform.localPosition.x) > 24)
						GameObject.Destroy (this.gameObject);
				else if (transform.localPosition.y > AlienScript.currentHeight + 20)
						GameObject.Destroy (this.gameObject);
		RaycastHit contact;
		if (Physics.Raycast (angled, out contact,transform.localScale.x)&&!exploded&&(contact.collider.tag=="Player"||contact.collider.tag=="Wall")) {
			print (contact.collider);
			moment1=Time.time;
			if(collider.tag=="Player")
				collider.frozen();
			exploded=true;
			animator.SetTrigger("boomTrig");//DONT GET ORIGINS CONFUSED

			//GameObject.Destroy(this.gameObject); probably make a method outside update
				}
		if (exploded && Time.time >= moment1 + .25) {
			GameObject.Destroy(this.gameObject);
				}
	}
}
