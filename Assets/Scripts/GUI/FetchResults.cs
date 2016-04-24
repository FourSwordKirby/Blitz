using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FetchResults : MonoBehaviour {

	public GameObject tempStateHolder; 
	public TempState tempState;
    public AudioManager audioManager;

    private bool played = false;
    private ScreenFader fader;
    public Text results;

	// Use this for initialization
	void Start ()
    {
        fader = FindObjectOfType<ScreenFader>();
        Debug.Log(fader);
        fader.FadeToClear();

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

    void Update()
    {
        if (tempState.state["Winner"] == "Player" && fader.finishedFade && !played)
        {
            audioManager.play("player_1_win");
            played = true;
        } else if (tempState.state["Winner"] == "Player 2" && fader.finishedFade && !played)
        {
            audioManager.play("player_2_win");
            played = true;
        }
    }
}
