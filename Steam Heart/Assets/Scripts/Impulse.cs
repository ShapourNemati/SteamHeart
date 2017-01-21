using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Impulse : MonoBehaviour {

	// tipo di impulso. Enum?
	ImpulseType type;

	// Configura pls
	// immagine
	// BPM da raggiungere. Influenza velocità dell'impulso
	public int bpm;
	// Punto di origine dell'onda. Dipende dalle dimensioni dell'immagine

	private GameObject ecgscreen;
	private Vector3 velocity;
	private float lifeSpan;
	private float lifeCounter;

	private bool isConsumed;

	// Use this for initialization
	void Start () {
		ecgscreen = GameObject.Find("ECGScreen");
		// Normalizzare in base alla dimensione dello schermo
		float screenWidth = ecgscreen.GetComponent<ScreenProperties>().width;
		int maxImpulsesOnScreen = ecgscreen.GetComponent<ScreenProperties> ().maxImpulsesOnScreen;
		velocity = Vector3.left * screenWidth / maxImpulsesOnScreen * bpm / 60;
		lifeSpan = (maxImpulsesOnScreen + 1) * 60 / bpm;
		lifeCounter = 0;
		isConsumed = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + velocity*Time.deltaTime;
		if (lifeCounter >= lifeSpan) {
			ecgscreen.GetComponent <WaveManager>().ImpulseDeathNotice();
			GameObject.Destroy(this);
		} else {
			lifeCounter += Time.deltaTime;
		}
	}

	private void Consume() {
		// scolora l'impulso (cambia sprite oppure shader)
		// aggiunge punti allo score manager
		isConsumed = true;
	}

	public void resolveImpulse(ImpulseType clickedType) {
		if (!isConsumed) {
			if (clickedType == type) {
				// aggiungi punti
				Consume();
			} else {
				// togli punti
			}
		} else {
			// togli punti
		}
	}
}
