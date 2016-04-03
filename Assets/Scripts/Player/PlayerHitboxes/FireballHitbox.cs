using UnityEngine;
using System.Collections;

public class FireballHitbox : Hitbox {
    public float decayTime;
	public GameObject explodePrefab;

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
        Hitbox hitbox = col.gameObject.GetComponent<Hitbox>();

        if (hitbox != null && hitbox.owner != this.owner)
        {
            Destroy(this.gameObject);
        }

        if (hurtbox != null && hurtbox.owner != this.owner)
        {
            float xDir = this.transform.parent.GetComponent<Rigidbody2D>().velocity.x;
            xDir = Mathf.Sign(xDir);

            Vector2 appliedKnockbackVector = new Vector2(knockbackVector.x * xDir, knockbackVector.y);

            hurtbox.TakeDamage(damage, shieldDamage);
            hurtbox.TakeHit(hitlag, hitstun, blockstun, appliedKnockbackVector);
			Vector3 loc = col.gameObject.transform.position;
			Instantiate (explodePrefab, loc, Quaternion.identity);	
            owner.gainMeter(meterGain);

            Destroy(this.transform.parent.gameObject);
        }
    }
}
