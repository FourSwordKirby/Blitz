using UnityEngine;
using System.Collections;

using UsefulThings;

[RequireComponent(typeof(TimeKeeper))]
public class DeathEffectColor : MonoBehaviour {

    public Curve alphaCurve;
    public Color color;

    private SpriteRenderer sprite;
    private TimeKeeper tk;

    private Color clearColor;

    void Start() {
        sprite = transform.Find("Visual").GetComponent<SpriteRenderer>();
        clearColor = sprite.color = color;
        clearColor.a = 0;

        tk = GetComponent<TimeKeeper>();
    }

    void Update() {
        sprite.color = Color.Lerp(color, clearColor, alphaCurve.Evaluate(tk));
    }
}
