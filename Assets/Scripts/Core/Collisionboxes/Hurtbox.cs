using UnityEngine;
using System.Collections;

/*
 * The hurtbox does not respond when it's hit by something, it only provides ways for the hitbox to do different things to the hitboxes
 * The reason for this is because Hurtboxes have more consistent and adaptable behavior compared to other hitboxes
 */
public abstract class Hurtbox : Collisionbox {
    public Player owner;
    public Parameters.HurtboxStatus status;

    public abstract void TakeDamage(float damage);
    public abstract void TakeHitstun(float hitstun);
    public abstract void TakeKnockback(Vector2 knockback);
    public abstract void ApplyEffect(Parameters.Effect effect);
}
