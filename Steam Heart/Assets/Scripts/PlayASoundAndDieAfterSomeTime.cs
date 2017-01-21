using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayASoundAndDieAfterSomeTime : MonoBehaviour {

	public float maxLife = 3;
	public float life = 0;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		life += Time.deltaTime;
		if (life >= maxLife)
			GameObject.Destroy (gameObject);
	}
}
