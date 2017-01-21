using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Impulse : MonoBehaviour {
	
	public ImpulseType type;

	// immagine TODO
	// immagine spenta TODO
	// BPM da raggiungere. Influenza velocità dell'impulso
	private int MusicHeartBeats = 80;
	// Punto di origine dell'onda. Dipende dalle dimensioni dell'immagine

	private GameObject ecgscreen;
	private ScoreManager scoremng;
	private Vector3 velocity;
	public float lifeSpan = 0;
	private float lifeCounter;

	private bool isConsumed;

	void Awake() {
		ecgscreen = GameObject.Find("ECGScreen");
		scoremng = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();

		float screenWidth = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().width;
		int maxImpulsesOnScreen = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().maxImpulsesOnScreen;
		velocity = Vector3.left * screenWidth / maxImpulsesOnScreen * MusicHeartBeats / 60;
		if (lifeSpan == 0) lifeSpan = (maxImpulsesOnScreen + 1) * 60.0f / MusicHeartBeats;
		Debug.Log ("Lifespan = " + lifeSpan);
		lifeCounter = 0;
		isConsumed = false;
		// Resize:

	}

//	void Start () {
//		Debug.Log ("WHAT.");
//		ecgscreen = GameObject.Find("ECGScreen");
//		scoremng = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
//
//		float screenWidth = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().width;
//		int maxImpulsesOnScreen = GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().maxImpulsesOnScreen;
//		velocity = Vector3.left * screenWidth / maxImpulsesOnScreen * MusicHeartBeats / 60;
//		lifeSpan = (maxImpulsesOnScreen + 1) * 60 / MusicHeartBeats;
//		Debug.Log ("Lifespan = " + lifeSpan);
//		lifeCounter = 0;
//		isConsumed = false;
//	}

	void Update () {
		transform.position = transform.position + velocity*Time.deltaTime;
		if (lifeCounter >= lifeSpan) {
			ecgscreen.GetComponent <WaveManager>().ImpulseDeathNotice();
			GameObject.Destroy(gameObject);
		} else {
			lifeCounter += Time.deltaTime;
		}
	}

	private void Consume() {
		// scolora l'impulso (cambia sprite oppure shader) TODO
		isConsumed = true;
	}

	/* Regola: questo è l'unico metodo che tocca lo score manager! */
	public void resolveImpulse(ImpulseType clickedType) {
		if (!isConsumed) {
			if (clickedType == type) {
				// feedback visivo
				scoremng.IncreaseScore ();
				Consume();
			} else {
				// qualche feedback visivo non sarebbe male TODO
				scoremng.DecreaseScore ();
			}
		} else {
			// anche qui, feedback visivo pls TODO
			scoremng.DecreaseScore ();
		}
	}
}
