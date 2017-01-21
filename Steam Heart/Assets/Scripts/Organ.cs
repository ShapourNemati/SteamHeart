using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Organ : MonoBehaviour, Clickable {

	public ImpulseType impulseType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Clicked()
	{
		//SFX
		//ANIMATION
		//PARTICLES
		GameObject.Find ("ECGScreen").GetComponent<WaveManager> ().OrganClickNotice (impulseType);
	}
}
