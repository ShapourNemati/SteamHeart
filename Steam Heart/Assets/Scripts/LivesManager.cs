using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour {

	public int lives;
	private int currentLives;

	void Start() {
		currentLives = lives;
	}

	// Update is called once per frame
	void Update () {
		if (currentLives <= 0) {
			// Logica che termina il gioco e riporta al menù TODO
			Debug.Log("HAI PERDUTO.");
		}
	}

	public void loseLife() {
		// animazione? TODO
		Debug.Log("-1 cuore");
		currentLives--;
	}

	public int getLives() {
		return currentLives;
	}
}