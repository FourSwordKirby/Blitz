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
        //We will make it so the character enters a hitstun state and then moves
        //owner.ActionFsm.ChangeState(new HitstunState(owner, owner.ActionFsm);
        //owner.selfBody.AddForce(knockback);

        //For now, just set its velocity lol
        owner.selfBody.velocity = knockback;
    }

    override public void ApplyEffect(Parameters.Effect effect)
    {
    }
}
