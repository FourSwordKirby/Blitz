using UnityEngine;
using System.Collections;

public class ReturnToGame : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(this.GetComponent<changeLevel>().change("Fight Scene"));
    }
}
