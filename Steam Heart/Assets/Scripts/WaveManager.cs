using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class WaveManager : MonoBehaviour {

	private ScoreManager scoremng;

	private Impulse[] impulseSequence;
	/* Number of patterns = maxImpulsesOnScreen.
	 * Patterns composed by '1' and '0' only.
	 * Number of symbols per pattern = maxImpulsesOnScreen */
	public string[] patterns;

	public GameObject[] impulses;

	private int maxImpulsesOnScreen;
	private Vector3 spawnPoint;
	private float impulseWidth;
	// indice del pattern corrente
	private int currentPattern;
	// indice del simbolo del pattern corrente
	private int nextImpulseIndex;
	// indice del prossimo pattern
	private int nextPattern;
	private Impulse currentImpulse;

	// Use this for initialization
	void Start () {
		scoremng = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		maxImpulsesOnScreen = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().maxImpulsesOnScreen;
		spawnPoint = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().getInpulseSpawnPoint();
		impulseWidth = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().impulseWidth;
		Debug.Log ("spawnPoint: " + spawnPoint);
		if (patterns.Length != maxImpulsesOnScreen) {
			Debug.Log ("NUMERO DI PATTERN ERRATO!");
		}
		if (impulses.Length != Enum.GetNames (typeof(ImpulseType)).Length) {
			Debug.Log ("MANCANO DEGLI IMPULSI!");
		}
		currentPattern = 0;
		nextPattern = 0;
		nextImpulseIndex = 0;
		// SpawnStartingImpulses (); TODO cancella
	}

//	private void SpawnStartingImpulses()
//	{
//		for (int i = 0; i < maxImpulsesOnScreen + 1; i++) {
//			GameObject o = GameObject.Instantiate (impulses[impulses.Length-1],spawnPoint,Quaternion.Euler(new Vector3(90,0,0)));
//			o.transform.position = o.transform.position + i * impulseWidth * Vector3.left;
//			Debug.Log("prima =" +o.GetComponent<Impulse> ().lifeSpan);
//			o.GetComponent<Impulse> ().lifeSpan = o.GetComponent<Impulse> ().lifeSpan * (maxImpulsesOnScreen - i + 1) / (maxImpulsesOnScreen + 1);
//			Debug.Log("dopo = "+ o.GetComponent<Impulse> ().lifeSpan); 
//			// TODO resize impulse
//		}
//	}

	// TODO serve una coroutine per generare i primi maxImpulsesOnScreen impulsi.
	// il resto viene generato da ImpulseDeathNotice.
		
	private void generateImpulse() {
		// individuo il pattern successivo
		int cbmp = scoremng.currentHeartBeats;
		int tbmp = scoremng.targetHeartBeats;
		float ratio = cbmp / tbmp * 1.0f;
		for (int i = 0; i<maxImpulsesOnScreen; i++) {
			float lowerbound = i / maxImpulsesOnScreen;
			float upperbound = (i + 1) / maxImpulsesOnScreen;
			if (lowerbound <= ratio && ratio <= upperbound) {
				nextPattern = i;
				break;
			}
		}

		// se il pattern precedente è finito, switcho, altrimenti attendo
		if (nextImpulseIndex == maxImpulsesOnScreen - 1) {
			nextImpulseIndex = 0;
			nextImpulseIndex = nextPattern;
		}

		// quindi genero il prossimo impulso
		if (patterns [currentPattern].Substring (nextImpulseIndex).StartsWith ("0")) {
			GameObject o = GameObject.Instantiate (impulses [randomInt ()], spawnPoint, Quaternion.Euler (new Vector3 (90, 0, 0)));
		} else {
			// genera impulso casuale TODO serve il prefab
			GameObject o = GameObject.Instantiate (impulses[impulses.Length-1],spawnPoint,Quaternion.Euler(new Vector3(90,0,0)));
		}
	}

	private int randomInt() {
		return UnityEngine.Random.Range (1, Enum.GetNames (typeof(ImpulseType)).Length - 1);
	}

	// se non serve la togliamo
	public void ImpulseDeathNotice() {
		// aggiorna currentImpulse TODO
		generateImpulse ();
	}

	public void OrganClickNotice(ImpulseType clickedType) {
	
	}
}
