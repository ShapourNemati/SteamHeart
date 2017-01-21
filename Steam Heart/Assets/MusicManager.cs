using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioSource[] soundTracks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeTrack(int n)
	{
		soundTracks [n - 1].SetScheduledEndTime (3d);
		soundTracks [n].SetScheduledStartTime(3d);
		soundTracks [n].Play ();
	}

}
