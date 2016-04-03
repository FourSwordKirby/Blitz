using UnityEngine;
using System.Collections;

public class DestroyObjectAfterSeconds : MonoBehaviour {
	public float seconds;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, seconds);
	}

}
