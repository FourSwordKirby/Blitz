using UnityEngine;
using System.Collections;

public class FireballHitbox : Hitbox {
    public float decayTime;

    void Update()
    {
        decayTime -= Time.deltaTime;
        if (decayTime < 0)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Hurtbox hurtbox = col.gameObject.GetComponent<Hurtbox>();
        if (hurtbox != null && hurtbox.owner != this.owner)
        {
            hurtbox.TakeDamage(damage);
            hurtbox.TakeHitstun(hitstun);

            float xDir = this.transform.parent.GetComponent<Rigidbody2D>().velocity.x;
            if (xDir == 0)
                xDir = 1;
            else
                xDir = xDir / Mathf.Abs(xDir);

            hurtbox.TakeKnockback(new Vector2(knockbackVector.x * xDir, knockbackVector.y));

             
            owner.gainMeter(meterGain);

            Destroy(this.transform.parent.gameObject);
        }
    }
}
