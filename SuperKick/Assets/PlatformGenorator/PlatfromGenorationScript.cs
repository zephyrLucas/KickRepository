using UnityEngine;
using System.Collections;

public class PlatfromGenorationScript : MonoBehaviour {

	public Transform platformPrefab;

	private ArrayList platforms = new ArrayList();

	public Vector2 nextPos;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 14; i++) {
			innitialcreate();
		}
	}
	
	// Update is called once per frame
	void Update () {
		createTheGround();
		destroyTheGround();
	}

	private void innitialcreate() {
		Transform temp = (Transform) Instantiate(platformPrefab);
		platforms.Add(temp);
		nextPos.x = Random.Range(-10, 10);
		nextPos.y = (float) (Random.Range(0, 10) + ((int) AlienScript.currentHeight));
		temp.localPosition = nextPos;
	}

	private void createTheGround() {
		if(platforms.Count < 14) {
			Transform temp = (Transform) Instantiate(platformPrefab);
			platforms.Add(temp);
			nextPos.x = Random.Range(-10, 10);
			nextPos.y = (float) (Random.Range(10, 20) + ((int) AlienScript.currentHeight));
			temp.localPosition = nextPos;

		}
	}

	private void destroyTheGround() {
		if(((Transform) platforms[0]).localPosition.y < AlienScript.currentHeight) {
			GameObject.Destroy( ((Transform) platforms[0]).gameObject);
			platforms.RemoveAt(0);
		}
	}

}
