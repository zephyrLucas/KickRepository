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

	private int command = -1;

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
		getCommand();
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= timeTillChange) {
			print ("change" + activeSong);
			if(command >= 0) {
				activeSong = command;
				command = -1;
			} else {
				activeSong = Random.Range(0, 9);
			}
			print ("change" + activeSong);
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).StartPlay();
			timeTillChange = ((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().clip.length;
			timeElapsed = 0f;
		}
 /*

		if ((((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).currentlyActive())) {
			activeSong = 0;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).StartPlay();
			print(((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).currentlyActive());
		} */
	}

	private void getCommand() {
		if(Input.GetKey(KeyCode.Alpha1)) {
			command = 0;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha2)) {
			command = 1;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha3)) {
			command = 2;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha4)) {
			command = 3;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha5)) {
			command = 4;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha6)) {
			command = 5;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha7)) {
			command = 6;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha8)) {
			command = 7;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		} else if(Input.GetKey(KeyCode.Alpha9)) {
			command = 8;
			timeElapsed = 9000f;
			((audioFiles[activeSong] as GameObject).GetComponent<MonoBehaviour>() as AudioScript).getAudio().Stop();
		}
	}


}
