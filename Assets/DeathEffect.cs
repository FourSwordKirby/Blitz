using UnityEngine;
using System.Collections;

using UsefulThings;

public class DeathEffect : MonoBehaviour {

    public GameObject triangle;
    public Color color;

    void Start() {
        for (int i = 0; i < 20; i++) {
            spawnTriangle();
        }

        ParticleSystem particles = transform.Find("Particles").GetComponent<ParticleSystem>();
        particles.startColor = color;
        particles.Emit(1000);
    }

    private void spawnTriangle() {
        GameObject obj = (GameObject)Instantiate(triangle);
        obj.SetActive(true);

        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.right * Random.Range(-1f, 1f);
        obj.transform.localEulerAngles = Vector3.forward * Random.Range(-1f, 1f);

        DeathEffectColor c = obj.GetComponent<DeathEffectColor>();
        c.color = Color.Lerp(color, Color.white, Random.Range(0, 0.5f));
        c.alphaCurve.frequency += Random.Range(-0.1f, 0.1f);

        ScaleWithCurve s = obj.GetComponent<ScaleWithCurve>();
        s.curveX.amplitude += Random.Range(-0.2f, 2);
        s.curveX.frequency += Random.Range(-0.1f, 0.1f);
        s.curveY.amplitude += Random.Range(-10f, 10f);
        s.curveY.frequency += Random.Range(-0.1f, 0.1f);
    }
}
