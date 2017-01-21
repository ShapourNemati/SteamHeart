using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVFX : MonoBehaviour {

	public float animationTime;
	private float animationCounter;

	public Sprite ring2;
	public Sprite ring3;
	public Sprite ring4;

	void Start() {
		animationCounter = 0;
	}

	// Update is called once per frame
	void Update () {
		if (animationCounter >= animationTime / 4 && animationCounter < animationTime/2) {
			Debug.Log ("Cambio a ring2");
			GetComponent<SpriteRenderer> ().sprite = ring2;
		} else if (animationCounter >= animationTime/2 && animationCounter < animationTime*3/4) {
			Debug.Log ("Cambio a ring3");
			GetComponent<SpriteRenderer> ().sprite = ring3;
		} else if (animationCounter >= animationTime*3/4 && animationCounter < animationTime) {
			Debug.Log ("Cambio a ring4");
			GetComponent<SpriteRenderer> ().sprite = ring4;
		} else if (animationCounter >= animationTime) {
			Debug.Log ("killo");
			GameObject.Destroy(gameObject);
		}
		animationCounter += Time.deltaTime;
	}
}
