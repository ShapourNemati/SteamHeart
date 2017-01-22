using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Index : MonoBehaviour {

	private Impulse currentImpulse;

	public Impulse getCurrentImpulse() {
		return currentImpulse;
	}

	public void setCurrentImpulse(Impulse impulse) {
		currentImpulse = impulse;
	}
}
