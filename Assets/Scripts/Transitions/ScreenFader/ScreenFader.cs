using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image FadeImg;
    public float fadeTime;
    private float elapsedTime;

    public bool finishedFade;

    private Color fadeColor;
    private Color previousColor;
    private bool fadeOnce;

    void Awake()
    {
        FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        fadeColor = FadeImg.color;
        previousColor = FadeImg.color;
    }

    void Update()
    {
        if(!finishedFade)
        {
            elapsedTime += Time.deltaTime;
            Color difference = fadeColor - previousColor;
            difference *= Mathf.Clamp(elapsedTime/fadeTime, 0, 1.0f);
            FadeImg.color = previousColor + difference;
        }else{
            elapsedTime = 0.0f;
            previousColor = fadeColor;
        }

        finishedFade = (FadeImg.color == fadeColor);

        if (fadeOnce && finishedFade)
        {
            FadeToClear();
            fadeOnce = false;
        }
    }


    public void setFadeTime(float time)
    {
        fadeTime = time;
    }

    public void FadeToClear()
    {
        fadeColor = Color.clear;
        finishedFade = false;
    }


    public void FadeToBlack()
    {
        fadeColor = Color.black;
        finishedFade = false;
    }
}