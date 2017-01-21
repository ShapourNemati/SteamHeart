using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Heart : MonoBehaviour, Clickable {

	public ImpulseType impulseType;
	private WaveManager wm;

	void Start() {
		wm = GameObject.Find ("ECGScreen").GetComponent<WaveManager> ();
	}

	public void Clicked() {
		if (wm.currentPattern == GameObject.Find("ECGScreen").GetComponent<ScreenProperties>().maxImpulsesOnScreen) {
			// PARTICLES
			// SFX
			// ANIMATION
			wm.OrganClickNotice (impulseType);
		}
	}
}
