using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateTest : MonoBehaviour {

	void FixedUpdate() {
		Debug.Log (Time.fixedDeltaTime);
	}
}
