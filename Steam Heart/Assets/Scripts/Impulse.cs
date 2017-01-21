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

	// Use this for initialization
	void Start () {
		ecgscreen = GameObject.Find("ECGScreen");
		// Normalizzare in base alla dimensione dello schermo
		float screenWidth = ecgscreen.GetComponent<ScreenProperties>().width;
		int maxImpulsesOnScreen = GameObject.Find ("ECGScreen").GetComponent<ScreenProperties> ().maxImpulsesOnScreen;
		velocity = Vector3.left * screenWidth / maxImpulsesOnScreen * bpm / 60;
		lifeSpan = (maxImpulsesOnScreen + 1) * 60 / bpm;
		lifeCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + velocity*Time.deltaTime;
		if (lifeCounter >= lifeSpan) {
			GameObject.Find ("ECGScreen").GetComponent <WaveManager>().ImpulseDeathNotice();
			GameObject.Destroy(this);
		} else {
			lifeCounter += Time.deltaTime;
		}
	}
}
