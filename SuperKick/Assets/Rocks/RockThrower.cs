using UnityEngine;
using System.Collections;

public class RockThrower : MonoBehaviour {

	public Transform rockPrefab;
	private float time;

	private Vector2 nextPos;

	private ArrayList rocks = new ArrayList();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		meteorThrower();
		time += Time.deltaTime;
		if (time > 10f) {
			GameObject.Destroy( ((Transform) rocks[0]).gameObject);
			rocks.RemoveAt(0);
			time = 0f;
		}

	}

	private void meteorThrower() {
		if(rocks.Count < 3) {
			Transform temp = (Transform) Instantiate(rockPrefab);
			rocks.Add(temp);
			nextPos.x = Random.Range(-10, 10);
			nextPos.y = (float) (Random.Range(10, 20) + ((int) AlienScript.currentHeight));
			temp.localPosition = nextPos;
		}
	}
	


}
