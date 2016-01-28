using UnityEngine;
using System.Collections;

public class FireballHitbox : Hitbox {
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        Hurtbox hurtbox = col.gameObject.GetComponent<Hurtbox>();
        if (hurtbox != null && hurtbox.owner != this.owner)
        {
            hurtbox.TakeDamage(damage);
            hurtbox.TakeHitstun(hitstun);
            hurtbox.TakeKnockback(knockbackVector);

            owner.gainMeter(meterGain);

            Destroy(this.transform.parent.gameObject);
        }
    }
}
