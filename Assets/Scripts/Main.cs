using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public int amount = 128; //itterations

	int spacing = 120;

	//Audio
	public AudioSource audio;
	GameObject[] roofs;
	GameObject[] bases;
	float[] spectrum;
	public int frequency;


	void Start () {
		audio = GetComponent<AudioSource>();
		roofs = GameObject.FindGameObjectsWithTag("Roof");
		bases = GameObject.FindGameObjectsWithTag("Base");
	}
	
	// Update is called once per frame
	void Update () {
		spectrum = audio.GetSpectrumData(64, 0, FFTWindow.BlackmanHarris);
		doAudio ();
	}

	void doAudio(){
		foreach (GameObject roof in roofs) {
			roof.transform.localScale = new Vector3 (1f, 0.3f + spectrum [frequency] * 2f, 1f);
		}
		foreach (GameObject bottom in bases) {
			bottom.transform.localScale = new Vector3 (1f +spectrum [20] * 70f,  1f,1f + spectrum [20] * 70f);
		}
	}
}