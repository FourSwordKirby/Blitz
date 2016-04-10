using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TempState : MonoBehaviour {

	public static TempState Instance = null;

	public Dictionary<string, string> state;

	void Awake () {
		// Checks for conflicting instances
		if (Instance == null) {
			Instance = this;
			state = new Dictionary<string, string>();
		} else if (Instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

}
