using UnityEngine;
using System.Collections;

public class CharSelectController : MonoBehaviour {
    public SelectionController p1Controller;
    public SelectionController p2Controller;

    public SelectionController stageController;

    private bool done;

    // Use this for initialization
	void Start () {
        stageController.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
    private float demoScreenTime = 58.0f;
    private float timer = 0.0f;
	void Update () {
        if (!p1Controller.clicked && !p2Controller.clicked)
        {
            timer += Time.deltaTime;
            if (timer >= demoScreenTime
                || (Input.GetButtonDown("P1 Special") || Input.GetButtonDown("P2 Special")))
            {
                StartCoroutine(GameManager.FindObjectOfType<changeLevel>().change("Title", 1.8f, true));
                timer = -demoScreenTime;
            }
            return;
        }
        timer = 0.0f;

        if (done)
            return;

        if (stageController.gameObject.activeSelf == true)
        {
            if ((Input.GetButtonDown("P1 Special") ||
                Input.GetButtonDown("P2 Special")) && !stageController.clicked)
            {
                p1Controller.clicked = false;
                p2Controller.clicked = false;
                stageController.gameObject.SetActive(false);
                return;
            }
            if (Input.GetButtonDown("P1 Attack") ||
                Input.GetButtonDown("P2 Attack"))
            {
                GameObject.FindObjectOfType<SetCharSelect>().setPlayerOne();
                GameObject.FindObjectOfType<SetCharSelect>().setPlayerTwo();
                done = true;
                GameObject.FindObjectOfType<bgmcontroller>().fadeOut = true;
                if (stageController.currentIndex == 0)
                    StartCoroutine(GameManager.FindObjectOfType<changeLevel>().change("Fight Scene", 2.0f, true));
                if (stageController.currentIndex == 1)
                    StartCoroutine(GameManager.FindObjectOfType<changeLevel>().change("Fight Scene 2",2.0f,true));
            }
        }

        if (p1Controller.clicked && p2Controller.clicked)
        {
            if (p1Controller.currentIndex == p2Controller.currentIndex)
            {
                FindObjectOfType<AudioManager>().play("Deconfirm");
                p1Controller.clicked = false;
                p2Controller.clicked = false;
                return;
            }
            stageController.gameObject.SetActive(true);
        }
	}
}
