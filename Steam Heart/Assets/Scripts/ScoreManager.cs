﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public int targetHeartBeats;
	public int currentHeartBeats;
	public int lossTreshHold = 15;

	//TODO: find a number, 2 minutes so far
	public float MAX_DURATION = 120;
	public float currentDuration;

	// Use this for initialization
	void Start () {
		currentDuration = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentDuration += Time.deltaTime;
		if (currentDuration >= MAX_DURATION) {
			//Losing routine
		}
	}


	public void IncreaseScore()
	{
		currentHeartBeats++;
		if (currentHeartBeats == targetHeartBeats) {
			//Winning routine
		}
	}

	public void DecreaseScore()
	{
		currentHeartBeats--;
		if (currentHeartBeats == lossTreshHold) {
			//Losing routine
			Debug.Log("MORTO.");
		}
	}
}
