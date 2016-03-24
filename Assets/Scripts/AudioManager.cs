using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public List<AudioClip> soundEffects;

    public void play(string name)
    {
        float volume = 100;

        AudioSource.PlayClipAtPoint(soundEffects.Find(x => x.name == name), this.transform.position,volume);
    }
}
