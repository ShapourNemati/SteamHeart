using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class WaveManager : MonoBehaviour {

	public ScoreManager scoremng;

	private Impulse[] impulseSequence;
	/* Number of patterns = maxImpulsesOnScreen.
	 * Patterns composed by '1' and '0' only.
	 * Number of symbols per pattern = maxImpulsesOnScreen */
	public string[] patterns;

	private int maxImpulsesOnScreen;
	private int currentPattern;
	private int currentPatternIndex;
	private int nextPattern;
	private Impulse currentImpulse;

	// Use this for initialization
	void Start () {
		scoremng = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
		maxImpulsesOnScreen = GameObject.Find ("ECGScreen").GetComponent<ScreenProperties> ().maxImpulsesOnScreen;
		if (patterns.GetLength () != maxImpulsesOnScreen) {
			Debug.Log ("NUMERO DI PATTERN ERRATO!");
		}
		// Riempie lo screen di maxImpulsesOnScreen impulsi vuoti TODO
		// inizializza currentImpulse con il primo dei vuoti.
		currentPattern = 0;
		nextPattern = 0;
		currentPatternIndex = 0;
	}
	
	// TODO serve una coroutine per generare i primi maxImpulsesOnScreen impulsi.
	// il resto viene generato da ImpulseDeathNotice.
		
	private void generateImpulse() {
		// in base allo score attuale e al pattern, genero robe. Se noto di dover cambiare pattern,
		// prima termino quello corrente

		// individuo il pattern successivo
		int cbmp = scoremng.currentHeartBeats;
		int tbmp = scoremng.targetHeartBeats;
		float ratio = cbmp / tbmp * 1.0f;
		for (int i = 0; i<maxImpulsesOnScreen; i++) {
			float lowerbound = i / maxImpulsesOnScreen;
			float upperbound = (i + 1) / maxImpulsesOnScreen;
			if (lowerbound <= ratio <= upperbound) {
				nextPattern = i;
			}
		}

		// se il pattern precedente è finito, switcho, altrimenti attendo
		if (currentPatternIndex == maxImpulsesOnScreen - 1) {
			currentImpulse = 0;
			currentImpulse = nextPattern;
		}

		// quindi genero il prossimo impulso

	}

	private ImpulseType randomImpulseType() {
		return ImpulseType.TYPE1; // TODO randomize
	}

	// se non serve la togliamo
	public void ImpulseDeathNotice() {
		// aggiorna currentImpulse TODO
		generateImpulse ();
	}

	public void OrganClickNotice(ImpulseType clickedType) {
	
	}
}
