using UnityEngine;
using System.Collections;

public class RockCode : PhysicsObject {


	Vector2 currentVelocity;
	Vector2 nextPos;
	// Use this for initialization
	public override void Start () {
		nextPos = this.transform.localPosition;
	}

	public void setSpeed(float x, float y) {
		horizontalSp = x;
		GravSpeed = y;
	}
	
	// Update is called once per frame
	public override void Update () {
		currentVelocity.y = GravSpeed;
		currentVelocity.x = horizontalSp;
		nextPos = nextPos + (Time.deltaTime * currentVelocity);
		this.transform.localPosition = nextPos;

		Vector2 down = transform.TransformDirection(-Vector2.up);
		Vector2 up = transform.TransformDirection(Vector2.up);
		Vector2 left = transform.TransformDirection(-Vector2.right);
		Vector2 right = transform.TransformDirection(Vector2.right);
		Vector2 Uleft = transform.TransformDirection(-Vector2.right + Vector2.up);
		Vector2 Uright = transform.TransformDirection(Vector2.right + Vector2.up);
		Vector2 Dleft = transform.TransformDirection(-Vector2.right - Vector2.up);
		Vector2 Dright = transform.TransformDirection(Vector2.right - Vector2.up);
		
		RaycastHit hit;
		float x = 0f;
		float y = 0f;


		if (Physics.Raycast(transform.position, down, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, down, out hit);
			x = 0f;
			y = -1f;
			smash (hit, y, x);
		}
		if (Physics.Raycast(transform.position, up, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, up, out hit);
			x = 0f;
			y = 1f;
			smash (hit, y, x);
		}
		if (Physics.Raycast(transform.position, left, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, left, out hit);
			x = -1f;
			y = 0f;
			smash (hit, y, x);
		}
		if (Physics.Raycast(transform.position, right, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, right, out hit);
			x = 1f;
			y = 0f;
			smash (hit, y, x);
		}
		if (Physics.Raycast(transform.position, Uleft, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, Uleft, out hit);
			x = -1f;
			y = 1f;
			smash (hit, y, x);
		}
		if (Physics.Raycast(transform.position, Uright, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, Uright, out hit);
			x = 1;
			y = 1;
			smash (hit, y, x);
		}
		if (Physics.Raycast(transform.position, Dleft, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, Dleft, out hit);
			x = -1f;
			y = -1f;
			smash (hit, y, x);
		}
		if (Physics.Raycast(transform.position, Dright, 9 * transform.localScale.y / 16)) {
			Physics.Raycast(transform.position, Dright, out hit);
			x = 1f;
			y = -1f;
			smash (hit, y, x);
		}

	}

	private void smash(RaycastHit hit, float y, float x) {
		if(y!=0f || x!=0f) {
			MonoBehaviour[] stuff = hit.collider.GetComponents<MonoBehaviour>();
			bool any = false;
			if(stuff.Length != 0) {
				foreach (MonoBehaviour script in stuff) {
					if((script is PhysicsObject) && (!any)) {
						((PhysicsObject) script).setHSpeed(x * Mathf.Abs(horizontalSp) * 6f);
						((PhysicsObject) script).setVSpeed(y * Mathf.Abs(GravSpeed) * 6f);
						any = true;
					}
				}
			}
		}
		

	}


}
