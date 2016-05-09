using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour {

	public IEnumerator change(string levelName, float time = 2.0f, bool fadeWhite = false)
    {
        GameObject.FindObjectOfType<ScreenFader>().setFadeTime(time);
        if (!fadeWhite)
            GameObject.FindObjectOfType<ScreenFader>().FadeToBlack();
        else
            GameObject.FindObjectOfType<ScreenFader>().FadeToWhite();

        while (!GameObject.FindObjectOfType<ScreenFader>().finishedFade)
        {
            yield return new WaitForSeconds(0.1f);
        }
		SceneManager.LoadScene(levelName);
   	}

    public IEnumerator EndGame()
    {
        float time = 1.0f;
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("Game");
    }
}
