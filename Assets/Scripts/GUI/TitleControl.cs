using UnityEngine;
using System.Collections;

public class TitleControl : MonoBehaviour {

    public bool clicked;
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("P1 Attack") ||
            Input.GetButtonDown("P2 Attack")) && !clicked)
        {
            clicked = true;
            StartCoroutine(this.GetComponent<changeLevel>().change("Character Select"));
        }
	}
}
