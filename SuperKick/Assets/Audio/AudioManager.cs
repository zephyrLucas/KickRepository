using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public GameObject positiveVibe;
	public GameObject doubleSided;
	public GameObject chronoAura;
	public GameObject fireAura;
	public GameObject highestHorizon;
	public GameObject hyperBounce;
	public GameObject rippinRave;
	public GameObject tishtariRain;
	public GameObject winterAura;


	private ArrayList audioFiles = new ArrayList();

	private int activeSong = 1;

	private float timeElapsed = 0f;
	private float timeTillChange = 0f; 
	// Use this for initialization
	void Start () {
		audioFiles.Add(positiveVibe);
		audioFiles.Add(doubleSided);
		audioFiles.Add(chronoAura);
		audioFiles.Add(fireAura);
		audioFiles.Add(highestHorizon);
		audioFiles.Add(hyperBounce);
		audioFiles.Add(rippinRave);
		audioFiles.Add(tishtariRain);
		audioFiles.Add(winterAura);


		//activeSong = 1;
		//((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).StartPlay();
	}
	
	// Update is called once per frame
	void Update () { 
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= timeTillChange) {
			print ("change");
			activeSong = Random.Range(0, 9);
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).StartPlay();
			timeTillChange += ((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().clip.length;
		}
 /*

		if ((((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).currentlyActive())) {
			activeSong = 0;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).StartPlay();
			print(((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).currentlyActive());
		} */
	}
}
