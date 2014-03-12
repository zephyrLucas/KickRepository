using UnityEngine;
using System.Collections;

public class SinglePlScript : MonoBehaviour {

	public bool ACTIVE = true;

	private float time = 0f;
	private float timeMax = 10f;

	// Use this for initialization
	void Start () {
		if(ACTIVE) {
			GameObject.Find("PlatformGenerator").GetComponent<PlatfromGenorationScript>().boostActive = false;
			//(GameObject.Find("Sprite1_426 1").GetComponent<MonoBehaviour>() as Player).deathEnabled = false;
			GameObject.Destroy(GameObject.Find("Sprite1_426 1"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (ACTIVE) {
			time += Time.deltaTime;
			if (time >= timeMax) {
				timeMax *= .97f;
				time = 0f;
				int choose = Random.Range(0, 4);

				if (choose == 0) {
					Boost.executePow("FROSTBREATHER", findPlayer());
				} else if (choose == 1) {
					Boost.executePow("MINDBENDER", findPlayer());
				} else if (choose == 2) {
					Boost.executePow("LIGHTSTEALER", findPlayer());
				} else if (choose == 3) {
					Boost.executePow("BLOODFREEZER", findPlayer());
				}
				//string type = Boost.Total.GetValue(Random.Range(0, 7)) as string;
				//Boost.executePow(type, findPlayer());
			}
		}

	}

	private Player findPlayer() {
		GameObject[] guys = GameObject.FindGameObjectsWithTag("Player");
		return guys[0].GetComponent<MonoBehaviour>() as Player;
	}
}
