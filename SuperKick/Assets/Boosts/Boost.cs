using UnityEngine;
using UnityEditor;
using System.Collections;

public class Boost : MonoBehaviour {

	public string type;

	private static string[] Total = {"FROSTBREATHER", "ROCKTHROWER", "AIRJUMPER", "MINDBENDER", "EARTHSHAPER", "LIGHTSTEALER"};

	// Use this for initialization
	void Start () {
		type = Total.GetValue(Random.Range(0, 5)) as string;

		string path = "Assets/Boosts/" + type + ".mat";
		transform.renderer.material = AssetDatabase.LoadAssetAtPath(path, typeof(Material)) as Material;
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
		if (useType == "MINDBENDER") {
			pl.bendYourMind();
		}
		if (useType == "EARTHSHAPER") {
			pl.makePlatform();
		}
		if (useType == "LIGHTSTEALER") {
			//pl.stealLight();
		}
	}
}
