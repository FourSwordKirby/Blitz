using UnityEngine;
using System.Collections;

public class ReturnToGame : MonoBehaviour {

    private bool p1ready = false;
    private bool p2ready = false;

    // Update is called once per frame
    void Update()
    {
        if (p1ready && p2ready) {
            StartCoroutine(this.GetComponent<changeLevel>().change("Character Select"));
        }
        if (Input.GetButtonDown("P1 Attack"))
        {
            Debug.Log("P1 READY");
            p1ready = true;
        }
        if (Input.GetButtonDown("P2 Attack"))
        {
            Debug.Log("P2 READY");
            p2ready = true;
        }
    }
}
