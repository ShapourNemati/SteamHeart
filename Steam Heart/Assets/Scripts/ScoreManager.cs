using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int targetHeartBeats;
	public int currentHeartBeats;

	public float MAX_DURATION = 120;
	public float currentDuration;

	public int totalImpulses, correctImpulses;

	public GameObject textScore;

	// Number of hits in a single round
	[HideInInspector]
	public int[] hits;

	private int n;

	void Start () {
		currentHeartBeats = 15;
		currentDuration = 0;
		totalImpulses = 0;
		correctImpulses = 0;
		textScore.GetComponent<Text> ().text = "Score: " + currentHeartBeats + "/" + targetHeartBeats;
		n = GameObject.Find ("ECGScreen").GetComponent<ScreenProperties> ().maxImpulsesOnScreen;
		hits = new int[n];
		for (int i = 0; i < n; i++) {
			hits [i] = 0;
		}
	}

	void Update () {
		currentDuration += Time.deltaTime;
		if (currentDuration >= MAX_DURATION) {
			//Losing routine
			Debug.Log("The end.");
		}
	}

	// Da togliere? TODO
	public void IncreaseScore()
	{
		currentHeartBeats++;
		totalImpulses++;
		correctImpulses++;
		textScore.GetComponent<Text> ().text = "Score: " + currentHeartBeats + "/" + targetHeartBeats;
		if (currentHeartBeats == targetHeartBeats) {
			//Winning routine
			Debug.Log("BRAVOH.");
		}
	}

	// Da togliere? TODO
	public void DecreaseScore()
	{
		currentHeartBeats--;
		totalImpulses++;
		textScore.GetComponent<Text> ().text = "Score: " + currentHeartBeats + "/" + targetHeartBeats;
	}

	public void IncreaseHits(int round) {
		hits [round]++;
		//Debug.Log ("hits (round" + round + ") = " + hits[round]);
	}

	public void resetHits(int round) {
		hits [round] = 0;
	}

	public float getAccuracy(int round) {
		int battute = GameObject.Find ("ECGScreen").GetComponent<WaveManager> ().battutePerTrack [round];
		//Debug.Log ("Success is " + ((float) hits [round] / (battute * (round + 1))*100) + "%");
		return (float) hits [round] / (battute * (round + 1));
	}
}
