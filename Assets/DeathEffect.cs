using UnityEngine;
using System.Collections;

using UsefulThings;

public class DeathEffect : MonoBehaviour {

    public GameObject triangle;
    public GameObject trail;
    public Color color;

    void Start() {
        for (int i = 0; i < 40; i++) {
            spawnTriangle();
        }
        for (int i = 0; i < 80; i++) {
            spawnTrail();
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
        c.color.a = Random.Range(0.2f, 0.6f);
        c.alphaCurve.frequency += Random.Range(-0.1f, 0.1f);

        ScaleWithCurve s = obj.GetComponent<ScaleWithCurve>();
        s.curveX.amplitude += Random.Range(-0.2f, 2);
        s.curveX.frequency += Random.Range(-0.1f, 0.1f);
        s.curveY.amplitude += Random.Range(-10f, 10f);
        s.curveY.frequency += Random.Range(-0.1f, 0.1f);
    }

    private void spawnTrail() {
        GameObject obj = (GameObject)Instantiate(trail);

        StartCoroutine(delaySetActive(obj, Random.Range(0.2f, 0.4f)));

        obj.transform.parent = transform;
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = Vector3.zero;

        TrailRenderer t = obj.GetComponent<TrailRenderer>();

        t.material.color = Color.Lerp(color, Color.white, Random.Range(0, 0.8f));

        t.startWidth = t.endWidth = Random.Range(0.4f, 0.6f);
        t.time = Random.Range(0.3f, 0.7f);
    }

    private IEnumerator delaySetActive(GameObject obj, float delay) {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }
}
