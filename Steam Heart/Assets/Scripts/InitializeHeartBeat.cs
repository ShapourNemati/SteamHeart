﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeHeartBeat : MonoBehaviour {

	public GameObject GamePhase, InitPhase, GamePhaseUI, InitPhaseUI ;
	public int NUMBER_OF_BEATS = 5;
	private int currentBeats;

	public GameObject heartBeat;

	private float[] times;
	private float beatDuration;

	// Use this for initialization
	void Start () {
		currentBeats = 0;	
		times = new float[NUMBER_OF_BEATS];
		beatDuration = 0;
	}
	
	// Update is called once per frame
	void Update () {
		beatDuration += Time.deltaTime;
		if ( (Input.GetButtonDown ("Beat") || (Input.GetMouseButtonDown (0)))&& (currentBeats < NUMBER_OF_BEATS) ) {
			GameObject.Instantiate (heartBeat);
			times [currentBeats] = beatDuration;
			beatDuration = 0;
			currentBeats++;
			if (currentBeats == NUMBER_OF_BEATS) {
				//Calcolo il tempo medio fra un battito e l'altro
				int HeartBeatsRate = (int) (60 / GetMean(times));
				//THE END
				GamePhase.SetActive(true);
				GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().playerImpulses = HeartBeatsRate;
				GamePhaseUI.SetActive(true);
				InitPhaseUI.SetActive(false);
				InitPhase.SetActive(false);
			}
		}	
	}

	private float GetMean(float [] array)
	{
		float total = 0;
		for (int i = 1; i < array.Length; i++) {
			total += array [i];
		}
		return total / array.Length;
	}
}
