using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingSprite : MonoBehaviour
{

    public Image image;
    private float lowerAlpha = 0.7f;
    public float alphaChange = 0.005f;
    private bool increasing;

    // Update is called once per frame
    void Update()
    {
        if (increasing)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + alphaChange);
            if (image.color.a == 1.0f)
            {
                increasing = false;
            }
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - alphaChange);
            if (image.color.a <= lowerAlpha)
            {
                increasing = true;
            }
        }
    }
}