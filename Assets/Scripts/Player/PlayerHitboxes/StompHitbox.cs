﻿using UnityEngine;
using System.Collections;

public class StompHitbox : Hitbox {

    public GameObject explodePrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        Hurtbox hurtbox = col.gameObject.GetComponent<Hurtbox>();
        if (hurtbox != null && hurtbox.owner != this.owner)
        {
            Vector2 appliedKnockbackVector = new Vector2(knockbackVector.x, knockbackVector.y);

            hurtbox.TakeDamage(damage, shieldDamage);
            hurtbox.TakeHit(hitlag, hitstun, blockstun, knockbackVector);


            //This is what happens if they weren't shielding;
            owner.airJumps = owner.maxAirJumps;
            owner.selfBody.velocity = new Vector2(owner.selfBody.velocity.x, owner.jumpHeight);
            owner.ActionFsm.ChangeState(new AirState(owner, owner.ActionFsm));

            Vector3 loc = col.gameObject.transform.position;
            Instantiate(explodePrefab, loc, Quaternion.identity);	
        }
    }
}
