using UnityEngine;
using System.Collections;

public class bgmcontroller : MonoBehaviour {

    public AudioSource bgm;

    public bool fadeOut;
    public float fadeDelta = 0.05f;

	// Update is called once per frame
	void Update () {
        if (!fadeOut)
            bgm.volume = Mathf.Clamp(bgm.volume + fadeDelta, 0, 1.0f);
        else
            bgm.volume = Mathf.Clamp(bgm.volume - fadeDelta, 0, 1.0f);
	}
}
