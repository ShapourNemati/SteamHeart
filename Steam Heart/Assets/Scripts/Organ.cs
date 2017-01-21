using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Organ : MonoBehaviour, Clickable {

	public ImpulseType impulseType;

	public void Clicked()
	{
		//SFX
		//ANIMATION
		//PARTICLES
		GameObject.Find ("ECGScreen").GetComponent<WaveManager> ().OrganClickNotice (impulseType);
	}
}
