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
	void Update () {
        if (done)
            return;

        if (p1Controller.clicked && p2Controller.clicked)
        {
            if (p1Controller.currentIndex == p2Controller.currentIndex)
            {
                p1Controller.clicked = false;
                p2Controller.clicked = false;
                return;
            }
            stageController.gameObject.SetActive(true);
        }

        if(stageController.gameObject.activeSelf == true)
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
                done = true;
                if(stageController.currentIndex == 0)
                    StartCoroutine(GameManager.FindObjectOfType<changeLevel>().change("Fight Scene"));
                if (stageController.currentIndex == 1)
                    StartCoroutine(GameManager.FindObjectOfType<changeLevel>().change("Fight Scene 2"));
           }
        }
	}
}
