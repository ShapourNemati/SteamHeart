using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int totalImpulses, correctImpulses;

	public GameObject textScore;

	void Start () {
		currentDuration = 0;
		totalImpulses = 0;
		correctImpulses = 0;
		textScore.GetComponent<Text> ().text = "Score: " + currentHeartBeats + "/" + targetHeartBeats;
	}

	public void Hit()
	{
		totalImpulses++;
		correctImpulses++;
		textScore.GetComponent<Text> ().text = "Accuracy: " + correctImpulses/totalImpulses;
	}

	public void Miss()
	{
		totalImpulses++;
		textScore.GetComponent<Text> ().text = "Accuracy: " + correctImpulses/totalImpulses;
	}

	public float getAccuracy(int round) {
		return correctImpulses / totalImpulses;
	}
}
