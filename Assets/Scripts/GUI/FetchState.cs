using UnityEngine;
using System.Collections;

public class FetchState : MonoBehaviour {

	public GameObject tempStateHolder; 
	public TempState tempState;
	public GameObject p1;
	private HueRotation p1rot;
	public GameObject p2;
	private HueRotation p2rot;

	// Use this for initialization
	void Start () {
		tempStateHolder = GameObject.Find ("TempState");
		if (tempStateHolder) {
			tempState = tempStateHolder.GetComponent<TempState> ();
		}
		if (tempState) {
			p1rot = p1.GetComponent<HueRotation> ();
			p2rot = p2.GetComponent<HueRotation> ();

			if (tempState.state["playerOne"] == tempState.state["playerTwo"]) {
				p2.GetComponent<Renderer> ().material.SetColor ("_Color", new Color(.5f, .5f, .5f, 1f));
			}

			if (tempState.state["playerOne"] == "Green") {
				p1rot.hueRotate (90);
			} else if (tempState.state["playerOne"] == "Blue") {
				p1rot.hueRotate (240);
			} else if (tempState.state["playerOne"] == "Purple") {
				p1rot.hueRotate (300);
			} else {
				p1rot.hueRotate (0);
			}
			if (tempState.state["playerTwo"] == "Red") {
				p2rot.hueRotate (0);
			} else if (tempState.state["playerTwo"] == "Blue") {
				p2rot.hueRotate (240);
			} else if (tempState.state["playerTwo"] == "Purple") {
				p2rot.hueRotate (300);
			} else {
				p2rot.hueRotate (90);
			}
		}
	}
}
