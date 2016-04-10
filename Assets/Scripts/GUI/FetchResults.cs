using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FetchResults : MonoBehaviour {

	public GameObject tempStateHolder; 
	public TempState tempState;

	public Text results;

	// Use this for initialization
	void Start () {
		tempStateHolder = GameObject.Find ("TempState");
		if (tempStateHolder) {
			tempState = tempStateHolder.GetComponent<TempState> ();
		}
		if (tempState.state ["Winner"] == "Player") {
			results.text = "PLAYER 1 VICTORY";
		} else if (tempState.state ["Winner"] == "Player 2") {
			results.text = "PLAYER 2 VICTORY";
		} else {
			results.text = "DRAW";
		}
	}
}
