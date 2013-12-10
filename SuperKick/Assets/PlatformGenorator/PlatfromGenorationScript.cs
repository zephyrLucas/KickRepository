using UnityEngine;
using System.Collections;

public class PlatfromGenorationScript : MonoBehaviour {

	public Transform platformPrefab;

	private ArrayList platforms = new ArrayList();

	public Vector2 currentCamPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void creatTheGround() {
		if(platforms.Count < 14) {
			Transform temp = (Transform) Instantiate(platformPrefab);
			platforms.Add(temp);

		}
	}

}
