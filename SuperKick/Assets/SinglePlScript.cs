using UnityEngine;
using System.Collections;

public class SinglePlScript : MonoBehaviour {

	public bool ACTIVE = true;

	private float time = 0f;
	private float timeMax = 10f;

	// Use this for initialization
	void Start () {
	

		if (ACTIVE) {
			GameObject.Find("RockGenerator").GetComponent<PlatfromGenorationScript>().boostActive = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (ACTIVE) {
			time += Time.deltaTime;
			if (time >= timeMax) {
				timeMax *= .97f;
				time = 0f;
				string type = Boost.Total.GetValue(Random.Range(0, 7)) as string;
				Boost.executePow(type, findPlayer());
			}
		}

	}

	private Player findPlayer() {
		GameObject[] guys = GameObject.FindGameObjectsWithTag("Player");
		return guys[0].GetComponent<MonoBehaviour>() as Player;
	}
}
