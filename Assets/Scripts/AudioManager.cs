using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public List<AudioClip> soundEffects;
	AudioSource audio;

	void Awake() {
		audio = GetComponent<AudioSource>();
        Debug.Log(audio);
	}

    public void play(string name)
    {
        audio.PlayOneShot(soundEffects.Find(x => x.name == name));
    }
}
