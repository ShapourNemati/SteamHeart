using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class InputManager : MonoBehaviour {

	private const int LMB = 0;
	private const float MAX_DISTANCE = 100.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (LMB) )
		{
			Debug.Log ("Premuto bottone");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			RaycastHit hit;
			Physics.Raycast (ray, out hit, MAX_DISTANCE);
			if (hit.transform != null) {
				hit.transform.gameObject.GetComponent<Clickable> ().Clicked ();
			} else {
				Debug.Log ("No raycast hit");
			}
		}
	}

}
