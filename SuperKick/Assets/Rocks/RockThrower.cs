using UnityEngine;
using System.Collections;

public class RockThrower : MonoBehaviour {

	public Transform rockPrefab;
	private float time;

	private Vector2 nextPos;

	public bool SUPERROCK = false;

	private ArrayList rocks = new ArrayList();
	private GameManager GameManager;
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		GameManager.gameStarter += gameStart;
		GameManager.gameEnder += gameEnd;
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		meteorThrower();
		time += Time.deltaTime;
		if ((time > 7f && !SUPERROCK) || (time > 1f && SUPERROCK)) {
			GameObject.Destroy( ((Transform) rocks[0]).gameObject);
			rocks.RemoveAt(0);
			time = 0f;
		}

	}
	void gameStart(){
		enabled = true;
		for(int i = 0; i < 12; i++) {
			Transform temp = (Transform) Instantiate(rockPrefab);
			rocks.Add(temp);
			nextPos.x = Random.Range(-10, 10);
			nextPos.y = -10f;
			temp.localPosition = nextPos;
		}
	}
	void gameEnd(){
		enabled = false;
		GameManager.gameStarter -= gameStart;
	}
	private void meteorThrower() {
		if((rocks.Count < 4 && !SUPERROCK) || (rocks.Count < 15 && SUPERROCK)) {
			createMeteor();
		}
	}

	private void createMeteor(){
		Transform temp = (Transform) Instantiate(rockPrefab);
		rocks.Add(temp);
		nextPos.x = Random.Range(-10, 10);
		nextPos.y = (float) (Random.Range(12, 20) + ((int) AlienScript.currentHeight));
		temp.localPosition = nextPos;
		temp.GetComponent<RockCode>().setSpeed(Random.Range(-3, 3), Random.Range(-4, 1));
	}
	


}
