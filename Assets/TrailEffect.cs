using UnityEngine;
using System.Collections;

public class TrailEffect : MonoBehaviour {

    public AnimationCurve heightCurve;

    private Vector3 targetPosition;

    private float lerpRadius;
    private float radius;
    private float angleOffset;
    private float radiansTraveled;
    private float frequency;

    private float height;
    private float lifeTime;
    private float duration;

    void Start() {
        radius = Random.Range(7, 25);

        angleOffset = Random.Range(0, 2 * Mathf.PI);
        radiansTraveled = Random.Range(10 * Mathf.PI, 20 * Mathf.PI);

        frequency = Random.Range(25f, 40f) * (Random.value > 0.5 ? 1 : -1);

        duration = Random.Range(0.2f, 1f);
        height = Random.Range(15, 35);
    }

    void Update() {
        if (lifeTime < duration) {
            float angle = radiansTraveled * heightCurve.Evaluate(lifeTime / duration) + angleOffset;
            targetPosition = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * lerpRadius;
            targetPosition.y = height * heightCurve.Evaluate(lifeTime / duration);

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * 5);

            lerpRadius = Mathf.Lerp(lerpRadius, radius, Time.deltaTime * 5);

            lifeTime += Time.deltaTime;
        }
    }
}
