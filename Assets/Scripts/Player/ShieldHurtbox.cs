using UnityEngine;
using System.Collections;

public class ShieldHurtbox : Hurtbox {

    public Shield parentShield;

    override public void TakeDamage(float damage, float shieldDamage)
    {
        parentShield.currentShieldSize -= parentShield.shieldSize * shieldDamage / 50.0f;
    }

    override public void TakeHit(float hitlag, float hitstun, float blockStun, Vector2 knockback)
    {
    }

    override public void ApplyEffect(Parameters.Effect effect)
    {
    }
}
