using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Impulse : MonoBehaviour {
	
	public ImpulseType type;

	private int MusicHeartBeats = 80;

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
		// Debug.Log ("Lifespan = " + lifeSpan);
		lifeCounter = 0;
		isConsumed = false;
	}

	void Update () {
		transform.position = transform.position + velocity*Time.deltaTime;
		if (lifeCounter >= lifeSpan) {
			ecgscreen.GetComponent <WaveManager>().ImpulseDeathNotice();
			if (type != ImpulseType.VOID && !isConsumed) {
				// feedback visivo pls TODO
				scoremng.Miss ();
			}
			GameObject.Destroy(gameObject);
		} else {
			lifeCounter += Time.deltaTime;
		}
	}

	private void Consume() {
		isConsumed = true;
	}

	public void resolveImpulse(ImpulseType clickedType) {
		if (!isConsumed) {
			if (clickedType == type) {
				// feedback visivo
				scoremng.Hit();
				Consume();
			} else {
				// qualche feedback visivo non sarebbe male TODO
				scoremng.Miss ();
				Consume ();
			}
		} else {
			// anche qui, feedback visivo pls TODO
			scoremng.Miss ();
		}

		/* Versione senza lo score: */
//		if (!isConsumed && clickedType == type) {
			// Feedback visivi
//			scoremng.IncreaseHits ();
//			Consume ();
//		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.name.Equals ("Index"))
			other.GetComponent<Index> ().setCurrentImpulse (this);
	}
}
