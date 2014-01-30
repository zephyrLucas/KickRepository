using UnityEngine;
using System.Collections;

public abstract class PhysicsObject : MonoBehaviour {
	
	protected float GravSpeed;
	protected float horizontalSp;

	// Use this for initialization
	public abstract void Start ();
	
	// Update is called once per frame
	public abstract void Update ();

	public void addToHSpeed(float x) {
		horizontalSp += x;
	}

	public void addToVSpeed(float x) {
		GravSpeed += x;
	}

	public void setHSpeed(float x) {
		horizontalSp = x;
	}
	
	public void setVSpeed(float x) {
		GravSpeed = x;
	}
}
