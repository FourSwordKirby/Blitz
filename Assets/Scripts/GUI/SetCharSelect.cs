using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetCharSelect : MonoBehaviour {

	private GameObject tempStateHolder; 
	private TempState tempState;

	public Toggle P1Red;
	public Toggle P1Green;
	public Toggle P1Blue;
	public Toggle P1Purple;

	public Toggle P2Red;
	public Toggle P2Green;
	public Toggle P2Blue;
	public Toggle P2Purple;

	// Use this for initialization
	void Start () {
		tempStateHolder = GameObject.Find ("TempState");
		if (tempStateHolder) {
			tempState = tempStateHolder.GetComponent<TempState> ();
			tempState.state ["playerOne"] = "Red";
			tempState.state ["playerTwo"] = "Green";
		}
	}

	public void setPlayerOne () {
		if (P1Red.isOn) {
			tempState.state ["playerOne"] = "Red";
		} else if (P1Green.isOn) {
			tempState.state ["playerOne"] = "Green";
		} else if (P1Blue.isOn) {
			tempState.state ["playerOne"] = "Blue";
		} else if (P1Purple.isOn) {
			tempState.state ["playerOne"] = "Purple";
		}
	}

	public void setPlayerTwo ()
	{
		if (P2Red.isOn) {
			tempState.state ["playerTwo"] = "Red";
		} else if (P2Green.isOn) {
			tempState.state ["playerTwo"] = "Green";
		} else if (P2Blue.isOn) {
			tempState.state ["playerTwo"] = "Blue";
		} else if (P2Purple.isOn) {
			tempState.state ["playerTwo"] = "Purple";
		}
	}
}
