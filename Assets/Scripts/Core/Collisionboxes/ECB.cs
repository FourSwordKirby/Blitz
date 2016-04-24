using UnityEngine;
using System.Collections;

/// <summary>
/// ECB is short for environmental collision box. This is used to check for collisions with floors, walls etc.
/// </summary>
public class ECB : Collisionbox {

    private float fallThroughLength = 0.2f;
    private float fallThroughTimer;

    public void fallThrough()
    {
        if(this.gameObject.layer == LayerMask.NameToLayer("Player"))
            this.gameObject.layer = LayerMask.NameToLayer("Fall Through");
    }

    void Update()
    {
        if(this.gameObject.layer == LayerMask.NameToLayer("Fall Through"))
        {
            fallThroughTimer -= Time.deltaTime;
            if(fallThroughTimer < 0)
            {
                this.gameObject.layer = LayerMask.NameToLayer("Player");
                fallThroughTimer = fallThroughLength;
            }
        }
    }
}
