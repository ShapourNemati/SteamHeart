using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour {

	// tipo di impulso. Enum?
	ImpulseType type;

	// Configura pls
	// immagine
	// BPM da raggiungere. Influenza velocità dell'impulso
	public int bpm;
	// Punto di origine dell'onda. Dipende dalle dimensioni dell'immagine
	public Transform origin;

	private Vector3 velocity;
	private float lifeSpan;
	private float lifeCounter;

	// Use this for initialization
	void Start () {
		// Normalizzare in base alla dimensione dello schermo
		GameObject screen = GameObject.FindGameObjectWithTag("Screen");
		float screenWidth; // estrapola screen width
		int maxImpulsesOnScreen; // estrapola massimi impulsi visualizzati a schermo
		velocity = Vector3.left * screenWidth / maxImpulsesOnScreen * bpm / 60;
		lifeSpan = (maxImpulsesOnScreen + 1) * 60 / bpm;
		lifeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform += velocity*Time.deltaTime;
		if (lifeCounter >= lifeSpan) {
			// Notify WaveManager TODO
			GameObject.Destroy(this);
		} else {
			lifeCounter += Time.deltaTime;
		}
	}
}
