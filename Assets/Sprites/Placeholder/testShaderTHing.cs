using UnityEngine;
using System.Collections;

public class testShaderTHing : MonoBehaviour {

	public float rotationAngle;

	// Use this for initialization
	void Start () {

		//to understand the math behind this matrix, see: www.graphicaobscura.com/matrix
		Material something = GetComponent<Renderer> ().material;

		Matrix4x4 HueTrans = new Matrix4x4 ();
		something.SetMatrix ("_HueTransform", HueTrans);
	}
}
