using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Index : MonoBehaviour {

	private Impulse currentImpulse;

	public Impulse getCurrentImpulse() {
		return currentImpulse;
	}

	public void setCurrentImpulse(Impulse impulse) {
		if (currentImpulse != null) {
			if (!currentImpulse.isConsumed && currentImpulse.type != ImpulseType.VOID) {
				GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().Miss ();
			}
		}
		currentImpulse = impulse;
	}
}
