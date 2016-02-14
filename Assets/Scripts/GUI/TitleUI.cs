using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
public class TitleUI : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton ("Start")) {
			Debug.Log ("test");
			SceneManager.LoadScene ("Main Menu");
		}
	}
}

