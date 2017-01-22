using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Heart : MonoBehaviour, Clickable {

	public ImpulseType impulseType;

	public void Clicked() {
		GameObject.Find ("ECGScreen").GetComponent<WaveManager> ().OrganClickNotice (impulseType);
	}
}
