using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {


	private bool isPlaying = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (audio.isPlaying) {
			isPlaying = true;
		} else {
			isPlaying = false;
		}
	}

	public void StartPlay() {
		audio.PlayOneShot(audio.clip);
	}

	public AudioSource getAudio() {
		return audio;
	}

	public bool currentlyActive() {
		return isPlaying;
	}
}
