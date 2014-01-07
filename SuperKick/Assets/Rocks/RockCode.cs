﻿using UnityEngine;
using System.Collections;

public class RockCode : PhysicsObject {


	Vector2 currentVelocity;
	Vector2 nextPos;
	// Use this for initialization
	public override void Start () {
		nextPos = this.transform.localPosition;
		horizontalSp = Random.Range(-3, 3);
		GravSpeed = Random.Range(-4, 1);
	}
	
	// Update is called once per frame
	public override void Update () {
		currentVelocity.y = GravSpeed;
		currentVelocity.x = horizontalSp;
		nextPos = nextPos + (Time.deltaTime * currentVelocity);
		this.transform.localPosition = nextPos;
	}
}
