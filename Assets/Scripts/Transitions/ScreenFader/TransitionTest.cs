using UnityEngine;
using System.Collections;

public class TransitionTest : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<ScreenFader>().FadeToBlack();
            Debug.Log("fade");
        }        
        //yield return this.GetComponent<ScreenFader>().FadeOut();
	}
}
