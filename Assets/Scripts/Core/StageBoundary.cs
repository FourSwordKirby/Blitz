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
            Color deathColor = playerOriginPoint.player.GetComponent<HueRotation>().rotateColor();
            deathEffectPrefab.GetComponent<DeathEffect>().color = deathColor;
            Vector3 angleVector = col.gameObject.transform.position;
            float angle = Mathf.Atan(angleVector.y / angleVector.x) * Mathf.Rad2Deg;
            if(angleVector.x > 0)
                angle += 180.0f;
            playDeathEffect(col.gameObject.transform.position, angle);
            playerOriginPoint.player.Die();
        }
    }

    private void playDeathEffect(Vector2 location, float rotation, ParticleSystem playerDeathEffect = null)
    {
        GameObject deathEffect = Instantiate(deathEffectPrefab);
        deathEffect.gameObject.transform.position = location;
        deathEffect.gameObject.transform.rotation = Quaternion.AngleAxis(-90f+ rotation, Vector3.forward);
    }
}
