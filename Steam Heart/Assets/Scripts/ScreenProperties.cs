using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProperties : MonoBehaviour {

	public const int maxImpulsesOnScreen = 1;
	public const float width = 0;
	// Hard coddato in base alle dimensioni dello sprite dell'impulso
	public const float impulseWidth = width/maxImpulsesOnScreen;
	private Vector3 impulseSpawnPoint;


	void Awake() {
		impulseSpawnPoint = transform.position + Vector3.right * (width / 2 + impulseWidth / 2);
	}

	public Vector3 getInpulseSpawnPoint() {
		return impulseSpawnPoint;
	}
}
