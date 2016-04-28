using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour {

    public int playerIndex;
    public List<Toggle> toggles;
    public int currentIndex;

    public bool clicked;

    private float cooldownLength = 0.4f;
    private float cooldownTimer;


	// Update is called once per frame
	void Update () {
        Debug.Log("player1" + Input.GetAxis("P1 Vertical"));

        Debug.Log("player2" + Input.GetAxis("P2 Vertical"));

        if (playerIndex == 0)
        {
            if (Input.GetButtonDown("P1 Attack"))
            {
                FindObjectOfType<AudioManager>().play("Select");
                clicked = true;
            }
            if (Input.GetButtonDown("P1 Special"))
            {
                FindObjectOfType<AudioManager>().play("Deconfirm");
                clicked = false;
            }
        }
        if (playerIndex == 1)
        {
            if (Input.GetButtonDown("P2 Attack"))
            {
                FindObjectOfType<AudioManager>().play("Select");
                clicked = true;
            }
            if (Input.GetButtonDown("P2 Special"))
            {
                FindObjectOfType<AudioManager>().play("Deconfirm");
                clicked = false;
            }
        }

        if (playerIndex == 3)
        {
            if (Input.GetButtonDown("P1 Attack")||Input.GetButtonDown("P2 Attack"))
            {
                FindObjectOfType<AudioManager>().play("Select");
                clicked = true;
            }
            if (Input.GetButtonDown("P1 Attack")||Input.GetButtonDown("P2 Special"))
            {
                FindObjectOfType<AudioManager>().play("Deconfirm");
                clicked = false;
            }
        }

        if (clicked)
        {
            toggles[currentIndex].interactable= false;
            return;
        }

        toggles[currentIndex].interactable = true;
        toggles[currentIndex].isOn = true;

        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
        {
            if (playerIndex == 0)
            {
                if (Input.GetAxis("P1 Vertical") > 0.5)
                {
                    FindObjectOfType<AudioManager>().play("Toggle");
                    currentIndex++;
                    if (currentIndex >= toggles.Count)
                        currentIndex = 0;
                    cooldownTimer = cooldownLength;
                }
                if (Input.GetAxis("P1 Vertical") < -0.5)
                {
                    FindObjectOfType<AudioManager>().play("Toggle");
                    currentIndex--;
                    if (currentIndex < 0)
                        currentIndex = toggles.Count - 1;
                    cooldownTimer = cooldownLength;
                }
            }
            if (playerIndex == 1)
            {
                if (Input.GetAxis("P2 Vertical") > 0.5)
                {
                    FindObjectOfType<AudioManager>().play("Toggle");
                    currentIndex++;
                    if (currentIndex >= toggles.Count)
                        currentIndex = 0;
                    cooldownTimer = cooldownLength;
                }
                if (Input.GetAxis("P2 Vertical") < -0.5)
                {
                    FindObjectOfType<AudioManager>().play("Toggle");
                    currentIndex--;
                    if (currentIndex < 0)
                        currentIndex = toggles.Count - 1;
                    cooldownTimer = cooldownLength;
                }
            }
            if (playerIndex == 3)
            {
                if (Input.GetAxis("P1 Vertical") > 0.5 || Input.GetAxis("P2 Vertical") > 0.5)
                {
                    FindObjectOfType<AudioManager>().play("Toggle");
                    currentIndex++;
                    if (currentIndex >= toggles.Count)
                        currentIndex = 0;
                    cooldownTimer = cooldownLength;
                }
                if (Input.GetAxis("P1 Vertical") < -0.5 ||Input.GetAxis("P2 Vertical") < -0.5)
                {
                    FindObjectOfType<AudioManager>().play("Toggle");
                    currentIndex--;
                    if (currentIndex < 0)
                        currentIndex = toggles.Count - 1;
                    cooldownTimer = cooldownLength;
                }
            }
        }
	}
}
