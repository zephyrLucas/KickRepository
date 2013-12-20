using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.y < AlienScript.currentHeight)
						GameObject.Destroy (transform.gameObject);
	}
}
