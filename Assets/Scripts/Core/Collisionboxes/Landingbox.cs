using UnityEngine;
using System.Collections;

public class Landingbox : Collisionbox {
    public Player owner;

    void OnCollisionEnter2D(Collision2D collision)
    {
        owner.grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        owner.grounded = false;
    }
}
