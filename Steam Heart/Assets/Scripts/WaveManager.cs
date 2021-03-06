﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class WaveManager : MonoBehaviour {

	private ScoreManager scoremng;

//	private Impulse[] impulseSequence;
	/* Number of patterns = maxImpulsesOnScreen.
	 * Patterns composed by '1' and '0' only.
	 * Number of symbols per pattern = maxImpulsesOnScreen */
//	public string[] patterns;

	public GameObject[] impulses;
//	public GameObject[] impulsesQueue;
//	public int[] battutePerTrack; // Non posso usare Beat, o non capiamo più nulla çAç

	private int maxImpulsesOnScreen;
	private Vector3 spawnPoint;
	// indice del pattern corrente
//	[HideInInspector]
//	public int currentPattern;
	// indice del simbolo del pattern corrente
	private int nextImpulseIndex;
//	private int currentBattuta;
//
//	public float successThreshold = 0;
//	public int voidBeforeHeart = 4;
//	private int voidCounter;
//	private bool heartSpawned;

	public int MusicHeartBeats;
	// Distanza in tempo tra gli impulsi
	private float delta;
	private float deltaCounter;

	public string pattern;

	void Start () {
		scoremng = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		maxImpulsesOnScreen = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().maxImpulsesOnScreen;
		spawnPoint = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().getInpulseSpawnPoint();
		// Debug.Log ("spawnPoint: " + spawnPoint);
//		if (patterns.Length != maxImpulsesOnScreen) {
//			Debug.Log ("NUMERO DI PATTERN ERRATO!");
//		}
		if (impulses.Length != Enum.GetNames (typeof(ImpulseType)).Length) {
			Debug.Log ("MANCANO DEGLI IMPULSI!");
		}
//		if (impulsesQueue.Length != maxImpulsesOnScreen+1) {
//			Debug.Log ("CODA INZIALE FORMATA MALE!");
//		}
//		if (battutePerTrack.Length != maxImpulsesOnScreen) {
//			Debug.Log ("MANCANO DEI DATI SUI SOUNDTRACK!");
//		}
//		currentPattern = 0;
//		currentBattuta = 0;
		nextImpulseIndex = 0;
//		voidCounter = 0;
//		heartSpawned = false;
		delta = 60.0f / ((float) MusicHeartBeats);
		deltaCounter = 0;
		Debug.Log (delta);
	}
		
	private void generateNextImpulse() {
//		// conto le battute, quando arrivo al numero giusto, cambio pattern
//		if (nextImpulseIndex == maxImpulsesOnScreen && currentPattern < maxImpulsesOnScreen) {
//			currentBattuta++;
//			nextImpulseIndex = 0;
//			//Debug.Log ("CurrentBattuta: " + currentBattuta + " battutePerTrack[CurrentPattern]: " + battutePerTrack[currentPattern] + " accuracy: " + scoremng.getAccuracy(currentPattern));
//			if (currentBattuta == battutePerTrack [currentPattern] && scoremng.getAccuracy (currentPattern) >= successThreshold) {
//				currentPattern++;
//
//				GameObject.Find ("MusicManager").GetComponent<MusicManager> ().ChangeTrack (currentPattern);
//				//StartCoroutine ("ChangeTrack",3f);
//				// Debug.Log ("Cambio pattern. Nuovo pattern: " + patterns[currentPattern]);
//				currentBattuta = 0;
//			} else if (currentBattuta == battutePerTrack [currentPattern] && scoremng.getAccuracy (currentPattern) < successThreshold) {
//				scoremng.resetHits (currentPattern);
//				currentBattuta = 0;
//			}
//		}
//		Debug.Log("impulso " + (nextImpulseIndex+1) + ", battuta " + (currentBattuta+1) + " del pattern " + currentPattern + " (" + battutePerTrack[currentPattern] + " battute)");
//
//		GameObject o;
//		if (currentPattern == maxImpulsesOnScreen) {
//			// genero X impulsi vuoti, poi il cuore.
//			Debug.Log("voidCounter = " + voidCounter + ", total: " + voidBeforeHeart);
//			if (voidCounter >= voidBeforeHeart && !heartSpawned) {
//				Debug.Log ("Spawn heart");
//				o = GameObject.Instantiate (impulses [impulses.Length - 2], spawnPoint, Quaternion.Euler (new Vector3 (90, 0, 0)));
//				heartSpawned = true;
//			} else {
//				Debug.Log ("Spawn void");
//				o = GameObject.Instantiate (impulses [impulses.Length - 1], spawnPoint, Quaternion.Euler (new Vector3 (90, 0, 0)));
//				voidCounter++;
//			}
//		} else {
//			// quindi genero il prossimo impulso
//			if (patterns [currentPattern].Substring (nextImpulseIndex).StartsWith ("0")) {
//				o = GameObject.Instantiate (impulses [impulses.Length - 1], spawnPoint, Quaternion.Euler (new Vector3 (90, 0, 0)));
//			} else {
//				o = GameObject.Instantiate (impulses [randomInt ()], spawnPoint, Quaternion.Euler (new Vector3 (90, 0, 0)));
//			}
//			nextImpulseIndex++;
//
//			// Aggiorno la coda
//			for (int i = 0; i < impulsesQueue.Length - 1; i++) {
//				impulsesQueue [i] = impulsesQueue [i + 1];
//			}
//			impulsesQueue [impulsesQueue.Length - 1] = o;
//		}

		// Nuova meccanica: seguo un pattern predefinito fino alla fine dei tempi.
		if (nextImpulseIndex < pattern.Length) {
			GameObject.Instantiate (impulses [int.Parse (pattern.Substring (nextImpulseIndex, 1))], spawnPoint, Quaternion.Euler (90, 0, 0));
		} else {
			GameObject.Instantiate (impulses [0], spawnPoint, Quaternion.Euler (90, 0, 0));
		}
		nextImpulseIndex++;
	}

	void Update() {
		deltaCounter += Time.deltaTime;
		if (deltaCounter >= delta) {
			generateNextImpulse ();
			deltaCounter = 0;
		}
	}

	// Esclude void e cuore
//	private int randomInt() {
//		return UnityEngine.Random.Range (0, Enum.GetNames (typeof(ImpulseType)).Length - 2);
//	}

//	public void ImpulseDeathNotice() {
//		generateNextImpulse ();
//	}

	public void OrganClickNotice(ImpulseType clickedType) {
		GameObject.Find("Index").GetComponent<Index>().getCurrentImpulse().resolveImpulse(clickedType);
	}
}
