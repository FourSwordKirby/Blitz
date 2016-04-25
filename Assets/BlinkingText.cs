using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingText : MonoBehaviour {

    public Text text;
    private float lowerAlpha = 0.4f;
    public float alphaChange = 0.005f;
    private bool increasing;

	// Update is called once per frame
	void Update () {
        if (increasing)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + alphaChange);
            if (text.color.a == 1.0f)
            {
                increasing = false;
            }
        }
        else
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - alphaChange);
            if (text.color.a <= lowerAlpha)
            {
                increasing = true;
            }
        }
	}
}
