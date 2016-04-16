using UnityEngine;
using System.Collections;

public class ChargeHitbox : Hitbox
{

    public GameObject explodePrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        Hurtbox hurtbox = col.gameObject.GetComponent<Hurtbox>();

        if (hurtbox != null && hurtbox.owner != this.owner)
        {
            float xDir = col.gameObject.transform.position.x - this.gameObject.transform.position.x;
            xDir = Mathf.Sign(xDir);
            Vector2 appliedKnockbackVector = new Vector2(knockbackVector.x * xDir, knockbackVector.y);

            hurtbox.TakeDamage(damage, shieldDamage);
            hurtbox.TakeHit(hitlag, hitstun, blockstun, appliedKnockbackVector);
            Vector3 loc = col.gameObject.transform.position;
            Instantiate(explodePrefab, loc, Quaternion.identity);	


            owner.selfBody.velocity = new Vector2(-0.5f * owner.selfBody.velocity.x, 2.0f * owner.jumpHeight);
            owner.ActionFsm.ChangeState(new AirState(owner, owner.ActionFsm));
            return;
        }
    }
}
