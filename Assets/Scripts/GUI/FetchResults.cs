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

    public ResultsConfirmationUI p1UI;
    public ResultsConfirmationUI p2UI;

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
            results.text = "PLAYER <b>1</b> VICTORY! (>^__^)>";

            p1UI.displayText.text = "1st place: Player 1 !";
            p2UI.displayText.text = "2nd place: Player 2";
		} else if (tempState.state ["Winner"] == "Player 2") {
            results.text = "PLAYER <b>2</b> VICTORY! (>^__^)>";

            p1UI.displayText.text = "2nd place: Player 1";
            p2UI.displayText.text = "1st place: Player 2!";
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
