using UnityEngine;
using System.Collections;

public class MeterOrb : MonoBehaviour {

    public int meterGain;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject enterObject = col.gameObject;
        Debug.Log(enterObject);

        PlayerOriginPoint playerOriginPoint = enterObject.GetComponent<PlayerOriginPoint>();

        if (playerOriginPoint != null)
        {
            playerOriginPoint.player.gainMeter(meterGain);
            Destroy(this.gameObject);
        }
    }
}
