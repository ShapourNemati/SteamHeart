using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProperties : MonoBehaviour {

	public int maxImpulsesOnScreen = 1;
	public float width = 0;
	// Hard coddato in base alle dimensioni dello sprite dell'impulso
	[HideInInspector]
	public float impulseWidth;
	private Vector3 impulseSpawnPoint;


	void Awake() {
		// TODO ottieni width dalla risoluzione dello schermo?
		impulseWidth = width/maxImpulsesOnScreen;
		impulseSpawnPoint = transform.position + Vector3.right * (width / 2 + impulseWidth / 2);
	}

	public Vector3 getInpulseSpawnPoint() {
		return impulseSpawnPoint;
	}
}
