﻿using UnityEngine;
using System.Collections;

public class Landingbox : Collisionbox {
    public Player owner;

    public LayerMask floorMask;

    void Update()
    {
        //Note, might just make it raycast when the player isn't grounded
        Debug.DrawRay(this.transform.position, 0.3f * Vector3.down, Color.red);

        if (Physics2D.Raycast(this.transform.position, Vector3.down, 0.3f, floorMask))
        {
            Debug.Log("Grounded");
            owner.grounded = true;
        }
        else
        {

            Debug.Log("NOT");
            owner.grounded = false;
        }
    }
}
