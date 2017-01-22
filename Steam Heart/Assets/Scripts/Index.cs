using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Index : MonoBehaviour {

	[HideInInspector]
	public Impulse currentImpulse;

	void onTriggerEnter(Collider collider) {
		currentImpulse = collider.gameObject.GetComponent<Impulse> ();
	}
}
