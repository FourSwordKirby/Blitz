using UnityEngine;
using System.Collections;
public class StageBoundary : MonoBehaviour {

    public GameObject deathEffectPrefab;

    void OnTriggerExit2D(Collider2D col)
    {
        GameObject exitObject = col.gameObject;
        PlayerOriginPoint playerOriginPoint = exitObject.GetComponent<PlayerOriginPoint>();

        if (playerOriginPoint != null)
        {
            float angle = Vector3.Angle(col.gameObject.transform.position, this.gameObject.transform.position);
            playDeathEffect(col.gameObject.transform.position, 90);
            playerOriginPoint.player.Die();
        }
    }

    private void playDeathEffect(Vector2 location, float rotation, ParticleSystem playerDeathEffect = null)
    {
        GameObject deathEffect = Instantiate(deathEffectPrefab);
        deathEffect.gameObject.transform.position = location;
        deathEffect.gameObject.transform.rotation = Quaternion.EulerRotation(0, 0, -15f * rotation);
    }
}
