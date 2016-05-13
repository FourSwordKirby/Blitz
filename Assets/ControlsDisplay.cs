using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ControlsDisplay : MonoBehaviour {

    public Image background;
    public List<Image> pages;
    int pageNumber;
    public bool visible;

    private float cooldownLength = 0.2f;
    private float cooldownTimer;

	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;

        if (!visible)
        {
            background.gameObject.SetActive(false);
            for (int i = 0; i < pages.Count; i++)
            {
                pages[i].gameObject.SetActive(false);
            }
            return;
        }
        else
        {
            background.gameObject.SetActive(true);
        }

        for (int i = 0; i < pages.Count; i++)
        {
            if (i != pageNumber)
                pages[i].gameObject.SetActive(false);
            else
                pages[i].gameObject.SetActive(true);
        }
	}

    public void display()
    {
        if (cooldownTimer < 0)
        {
            visible = !visible;

            cooldownTimer = cooldownLength;
            FindObjectOfType<AudioManager>().play("Toggle");
        }
    }

    public void nextPage()
    {
        if (cooldownTimer < 0)
        {
            pageNumber = Mathf.Clamp(pageNumber + 1, 0, pages.Count-1);

            cooldownTimer = cooldownLength;
            FindObjectOfType<AudioManager>().play("Toggle");
        }
    }

    public void previousPage()
    {
        if (cooldownTimer < 0)
        {
            pageNumber  = Mathf.Clamp(pageNumber - 1, 0, pages.Count-1);

            cooldownTimer = cooldownLength;
            FindObjectOfType<AudioManager>().play("Toggle");
        }
    }
}
