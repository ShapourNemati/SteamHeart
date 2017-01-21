using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeHeartBeat : MonoBehaviour {

	public int NUMBER_OF_BEATS = 5;
	private int currentBeats;

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
		if (Input.GetButtonDown ("Beat")) {
			times [currentBeats] = beatDuration;
			beatDuration = 0;
			currentBeats++;
			if (currentBeats == NUMBER_OF_BEATS) {
				//Calcolo il tempo medio fra un battito e l'altro
				int HeartBeatsRate = GetMean(times);
				//THE END
			}
		}	
	}

	private int GetMean(int [] array)
	{
		int total = 0;
		for (int i = 0; i < array.Length; i++) {
			total += array [i];
		}
		return total / array.Length;
	}
}
