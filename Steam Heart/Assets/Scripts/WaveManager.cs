﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class WaveManager : MonoBehaviour {

	public ScoreManager scoremng;

	private Impulse[] impulseSequence;
	/* Number of patterns = maxImpulsesOnScreen.
	 * Patterns composed by '1' and '0' only.
	 * Number of symbols per pattern = maxImpulsesOnScreen */
	public string[] patterns;

	private int maxImpulsesOnScreen;
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
		maxImpulsesOnScreen = ScreenProperties.maxImpulsesOnScreen;
		if (patterns.Length != maxImpulsesOnScreen) {
			Debug.Log ("NUMERO DI PATTERN ERRATO!");
		}
		// Riempie lo screen di maxImpulsesOnScreen impulsi vuoti TODO
		// inizializza currentImpulse con il primo dei vuoti.
		currentPattern = 0;
		nextPattern = 0;
		nextImpulseIndex = 0;
	}
	
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
			// genera impulso vuoto. TODO serve il prefab
		} else {
			// genera impulso casuale TODO serve il prefab
		}
	}

	private ImpulseType randomImpulseType() {
		int r = UnityEngine.Random.Range (1, Enum.GetNames (typeof(ImpulseType)).Length - 1);
		return ImpulseType.VOID; // TODO
	}

	// se non serve la togliamo
	public void ImpulseDeathNotice() {
		// aggiorna currentImpulse TODO
		generateImpulse ();
	}

	public void OrganClickNotice(ImpulseType clickedType) {
	
	}
}
