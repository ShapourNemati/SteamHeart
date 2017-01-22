using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public float MIN_ACCURACY = 0.5f;
	public int MIN_IMPULSES = 12;
	public int totalImpulses, correctImpulses;

	public GameObject textScore;

	void Start () {
		totalImpulses = 0;
		correctImpulses = 0;
		UpdateText ();
	}

	public void Hit()
	{
		totalImpulses++;
		correctImpulses++;
		UpdateText ();
	}

	public void Miss()
	{
		totalImpulses++;
		UpdateText ();
	}

	public float getAccuracy() {
		return correctImpulses / totalImpulses;
	}

	void Update()
	{
		if ( (getAccuracy () < MIN_ACCURACY) &&
			(totalImpulses > MIN_IMPULSES))
			{
			Application.Quit ();
			//TODO: animazione finale
		}
	}

	void UpdateText ()
	{
		textScore.GetComponent<Text> ().text = "Accuracy: " + correctImpulses / totalImpulses;
	}
}
