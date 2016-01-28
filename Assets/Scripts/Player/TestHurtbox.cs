using UnityEngine;
using System.Collections;

public class TestHurtbox : Hurtbox {
    override public void TakeDamage(float damage)
    {
        owner.loseHealth(damage);
        Debug.Log(owner.health);
    }

    override public void TakeHitstun(float hitstun)
    {
    }

    override public void TakeKnockback(Vector2 knockback)
    {
    }

    override public void ApplyEffect(Parameters.Effect effect)
    {
    }
}
