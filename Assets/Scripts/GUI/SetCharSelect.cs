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
		if (!P1Red.interactable) {
			tempState.state ["playerOne"] = "Red";
		} else if (!P1Green.interactable) {
			tempState.state ["playerOne"] = "Green";
		} else if (!P1Blue.interactable) {
			tempState.state ["playerOne"] = "Blue";
		} else if (!P1Purple.interactable) {
			tempState.state ["playerOne"] = "Purple";
		}
	}

	public void setPlayerTwo ()
	{
		if (!P2Red.interactable) {
			tempState.state ["playerTwo"] = "Red";
		} else if (!P2Green.interactable) {
			tempState.state ["playerTwo"] = "Green";
		} else if (!P2Blue.interactable) {
			tempState.state ["playerTwo"] = "Blue";
		} else if (!P2Purple.interactable) {
			tempState.state ["playerTwo"] = "Purple";
		}
	}
}
