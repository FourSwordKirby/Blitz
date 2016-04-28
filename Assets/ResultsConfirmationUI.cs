using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;


public class ResultsConfirmationUI : MonoBehaviour {
    public AudioManager audioManger;

    public Text displayText;
    public Text confirmText;

    public Image displayNode;
    public Image emblem;

    public Quaternion targetRotation;

	// Use this for initialization
	void Start () {
        emblem.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 30.0f;
	}

    void Update()
    {

        this.displayNode.gameObject.transform.rotation = Quaternion.RotateTowards(this.displayNode.gameObject.transform.rotation, targetRotation, 6);

        if (this.displayNode.gameObject.transform.rotation == targetRotation)
        {
            if(this.targetRotation == Quaternion.Euler(180, 0, 0))
                this.emblem.gameObject.transform.rotation = Quaternion.Euler(0, 180, this.emblem.gameObject.transform.rotation.eulerAngles.z);
            else
                this.emblem.gameObject.transform.rotation = Quaternion.Euler(0, 0, this.emblem.gameObject.transform.rotation.eulerAngles.z);
        }

        if (this.displayNode.gameObject.transform.rotation.eulerAngles.y == 180 && this.targetRotation == Quaternion.Euler(180, 0, 0))
        {
            this.confirmText.gameObject.SetActive(true);
            this.displayText.gameObject.SetActive(false);
        }
        if (this.displayNode.gameObject.transform.rotation.eulerAngles.y == 0 && this.targetRotation == Quaternion.Euler(Vector3.zero))
        {
            this.confirmText.gameObject.SetActive(false);
            this.displayText.gameObject.SetActive(true);
        }
    }

    public void confirm()
    {
        this.targetRotation = Quaternion.Euler(180, 0, 0);
        audioManger.play("Select");
    }

    public void deconfirm()
    {
        this.targetRotation = Quaternion.Euler(Vector3.zero);
        this.confirmText.gameObject.SetActive(false);
        this.displayText.gameObject.SetActive(true);
        audioManger.play("Deconfirm");
    }
}
