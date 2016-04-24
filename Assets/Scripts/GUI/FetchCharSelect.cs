using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FetchCharSelect : MonoBehaviour {

	public GameObject tempStateHolder; 
	public TempState tempState;

	public GameObject p1;
    public GameObject p1Portrait;
	public HueRotation p1rot;
	public HueRotation p1chargeRot;

	public GameObject p2;
    public GameObject p2Portrait;
	public HueRotation p2rot;
	public HueRotation p2chargeRot;

	// Use this for initialization
	void Start () {
		tempStateHolder = GameObject.Find ("TempState");
		if (tempStateHolder) {
			tempState = tempStateHolder.GetComponent<TempState> ();
		}
		if (tempState) {

			if (tempState.state["playerOne"] == tempState.state["playerTwo"]) {
				p2.GetComponent<Renderer> ().material.SetColor ("_Color", new Color(.6f, .6f, .6f, 1f));
			}
			if (tempState.state["playerOne"] == "Green") {
				p1rot.RotationAngle = 90;
                p1chargeRot.RotationAngle = 90;
                p1Portrait.GetComponent<Image>().color = Color.green;
			} else if (tempState.state["playerOne"] == "Blue") {
				p1rot.RotationAngle = 240;
				p1chargeRot.RotationAngle = 240;
                p1Portrait.GetComponent<Image>().color = Color.blue;
            } else if (tempState.state["playerOne"] == "Purple") {
				p1rot.RotationAngle = 300;
				p1chargeRot.RotationAngle = 300;
                p1Portrait.GetComponent<Image>().color = Color.magenta;
            } else {
				p1rot.RotationAngle = 0;
				p1chargeRot.RotationAngle = 0;
                p1Portrait.GetComponent<Image>().color = Color.red;
            }
			if (tempState.state["playerTwo"] == "Red") {
				p2rot.RotationAngle = 0;
				p2chargeRot.RotationAngle = 0;
                p2Portrait.GetComponent<Image>().color = Color.red;
            } else if (tempState.state["playerTwo"] == "Blue") {
				p2rot.RotationAngle = 240;
				p2chargeRot.RotationAngle = 240;
                p2Portrait.GetComponent<Image>().color = Color.blue;
            } else if (tempState.state["playerTwo"] == "Purple") {
				p2rot.RotationAngle = 300;
				p2chargeRot.RotationAngle = 300;
                p2Portrait.GetComponent<Image>().color = Color.magenta;
            } else {
				p2rot.RotationAngle = 90;
				p2chargeRot.RotationAngle = 90;
                p2Portrait.GetComponent<Image>().color = Color.green;
            }
		}
	}
}
