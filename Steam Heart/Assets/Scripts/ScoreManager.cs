using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int targetHeartBeats;
	public int currentHeartBeats;

	//TODO: find a number, 2 minutes so far
	public float MAX_DURATION = 120;
	public float currentDuration;

	public int totalImpulses, correctImpulses;

	public GameObject textScore;

	// Use this for initialization
	void Start () {
		currentHeartBeats = 15;
		currentDuration = 0;
		totalImpulses = 0;
		correctImpulses = 0;
		textScore.GetComponent<Text> ().text = "Score: " + currentHeartBeats + "/" + targetHeartBeats;
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
		totalImpulses++;
		correctImpulses++;
		textScore.GetComponent<Text> ().text = "Score: " + currentHeartBeats + "/" + targetHeartBeats;
		//Debug.Log ("Increased score. " + currentHeartBeats);
		if (currentHeartBeats == targetHeartBeats) {
			//Winning routine
			Debug.Log("BRAVOH.");
		}
	}

	public void DecreaseScore()
	{
		currentHeartBeats--;
		totalImpulses++;
		textScore.GetComponent<Text> ().text = "Score: " + currentHeartBeats + "/" + targetHeartBeats;
		//Debug.Log ("Decreased score. " + currentHeartBeats);
	}
}
