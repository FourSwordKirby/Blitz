using UnityEngine;
using System.Collections;

public class ReturnToGame : MonoBehaviour {

    private bool p1ready = false;
    private bool p2ready = false;
    private bool changed = false;

    public ResultsConfirmationUI player1UI;
    public ResultsConfirmationUI player2UI;

    // Update is called once per frame
    void Update()
    {
        if (p1ready && p2ready && !changed) {
            StartCoroutine(this.GetComponent<changeLevel>().change("Character Select", 0.5f));
            changed = true;
        }
        if (Input.GetButtonDown("P1 Attack"))
        {
            if (!p1ready)
            {
                player1UI.confirm();
                p1ready = true;
            }
            else
            {
                player1UI.deconfirm();
                p1ready = false;
            }
        }
        if (Input.GetButtonDown("P1 Special"))
        {
            player1UI.deconfirm();
            p1ready = false;
        }
        if (Input.GetButtonDown("P2 Attack"))
        {
            if (!p2ready)
            {
                player2UI.confirm();
                p2ready = true;
            }
            else
            {
                player2UI.deconfirm();
                p2ready = false;
            }
        }
        if (Input.GetButtonDown("P1 Special"))
        {
            player1UI.deconfirm();
            p1ready = false;
        }
    }
}
