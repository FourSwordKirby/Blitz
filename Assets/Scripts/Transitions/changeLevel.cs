using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour {

	public IEnumerator change(string levelName, float time = 0.1f)
    {
		float fadeTime = time;
        this.GetComponent<ScreenFader>().fadeIn = false;
        yield return this.GetComponent<ScreenFader>().FadeOut();
        SceneManager.LoadScene(levelName);
   	}
}
