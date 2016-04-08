using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TempState : MonoBehaviour {

	public static TempState Instance = null;

	public Toggle P1Red;
	public Toggle P1Green;
	public Toggle P1Blue;
	public Toggle P1Purple;

	public Toggle P2Red;
	public Toggle P2Green;
	public Toggle P2Blue;
	public Toggle P2Purple;

    public string playerOne = "Red";
    public string playerTwo = "Green";

	void Awake () {
		// Checks for conflicting instances
		if (Instance == null) {
			Instance = this;
		}

		DontDestroyOnLoad (gameObject);
	}

	public void setPlayerOne () {
		if (P1Red.isOn) {
			playerOne = "Red";
		} else if (P1Green.isOn) {
			playerOne = "Green";
		} else if (P1Blue.isOn) {
			playerOne = "Blue";
		} else if (P1Purple.isOn) {
			playerOne = "Purple";
		}
		print(playerOne);
	}

    public void setPlayerTwo ()
	{
		if (P2Red.isOn) {
			playerTwo = "Red";
		} else if (P2Green.isOn) {
			playerTwo = "Green";
		} else if (P2Blue.isOn) {
			playerTwo = "Blue";
		} else if (P2Purple.isOn) {
			playerTwo = "Purple";
		}
        print(playerTwo);
    }

    public string getPlayerOne () { return playerOne; }
    public string getPlayerTwo() { return playerTwo; }

}
