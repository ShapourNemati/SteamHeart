using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Impulse : MonoBehaviour {
	
	public ImpulseType type;

	// immagine TODO
	// immagine spenta TODO
	// BPM da raggiungere. Influenza velocità dell'impulso
	[HideInInspector]
	public int TargetHeartBeats;
	// Punto di origine dell'onda. Dipende dalle dimensioni dell'immagine

	private GameObject ecgscreen;
	private ScoreManager scoremng;
	private Vector3 velocity;
	private float lifeSpan;
	private float lifeCounter;

	private bool isConsumed;

	void Start () {
		ecgscreen = GameObject.Find("ECGScreen");
		scoremng = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();

		float screenWidth = ScreenProperties.width;
		int maxImpulsesOnScreen = ScreenProperties.maxImpulsesOnScreen;
		// fare un debug, non mi fido.
		Debug.Log(maxImpulsesOnScreen);
		velocity = Vector3.left * screenWidth / maxImpulsesOnScreen * TargetHeartBeats / 60;
		lifeSpan = (maxImpulsesOnScreen + 1) * 60 / TargetHeartBeats;
		lifeCounter = 0;
		isConsumed = false;
	}

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
