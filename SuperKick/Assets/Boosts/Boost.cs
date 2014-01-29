using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	public string type;

	// Use this for initialization
	void Start () {
		type = "FROSTBREATHER";
		//type = "ROCKTHROWER";
		//type = "AIRJUMPER";
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.y < AlienScript.currentHeight) {
			GameObject.Destroy (transform.gameObject);
		}
	}

	public string setPow() {
		GameObject.Destroy (transform.gameObject);
		return type;
	}

	public static void executePow(string useType, Player pl) {
		if (useType == "AIRJUMPER") {
			pl.superJump();
		}
		if (useType == "ROCKTHROWER") {
			pl.makeRock();
		}
		if (useType == "FROSTBREATHER") {
			pl.makeCold();
		}
	}
}
