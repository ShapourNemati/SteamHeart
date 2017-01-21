using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProperties : MonoBehaviour {

	public int maxImpulsesOnScreen = 1;
	public float width = 0;
	[HideInInspector]
	public float impulseWidth;
	private Vector3 impulseSpawnPoint;


	void Awake() {
		impulseWidth = width/maxImpulsesOnScreen;
		impulseSpawnPoint = transform.position + Vector3.right * (width / 2 + impulseWidth / 2);
	}

	public Vector3 getInpulseSpawnPoint() {
		return impulseSpawnPoint;
	}
}
