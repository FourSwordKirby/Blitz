using UnityEngine;
using System.Collections;

public class HueRotation : MonoBehaviour {

	public float rotationAngle;
	private const float RLUM = 0.3086f;
	private const float GLUM = 0.6094f;
	private const float BLUM = 0.0820f;

	// Use this for initialization
	void Start () {

		//to understand the math behind this matrix, see: www.graficaobscura.com/matrix
		Material something = GetComponent<Renderer> ().material;

		Matrix4x4 HueTrans = Matrix4x4.identity;

		//rotate HueTrans into positive Z 
		float root2 = Mathf.Sqrt (2);
		float xrs = 1 / root2;
		float xrc = 1 / root2;

		HueTrans = xrotate (HueTrans, xrs, xrc);

		float root3 = Mathf.Sqrt (3);
		float yrs = -1 / root3;
		float yrc = Mathf.Sqrt (2) / root3;

		HueTrans = yrotate (HueTrans, yrs, yrc);

		//rotate the hue
		float zrs = Mathf.Sin (rotationAngle * Mathf.Deg2Rad);
		float zrc = Mathf.Cos (rotationAngle * Mathf.Deg2Rad);

		HueTrans = zrotate (HueTrans, zrs, zrc);

		//undo previous rotations
		HueTrans = yrotate (HueTrans, -yrs, yrc);
		HueTrans = xrotate (HueTrans, -xrs, xrc);

		something.SetMatrix ("_HueTransform", HueTrans);
	}

	Matrix4x4 xrotate (Matrix4x4 mat, float rsin, float rcos) {
		Matrix4x4 rotmat = new Matrix4x4 ();
		rotmat.SetRow (0, new Vector4 (1, 0, 0, 0));
		rotmat.SetRow (1, new Vector4 (0, rcos, -rsin, 0));
		rotmat.SetRow (2, new Vector4 (0, rsin, rcos, 0));
		rotmat.SetRow (3, new Vector4 (0, 0, 0, 1));

		return rotmat * mat;
	}

	Matrix4x4 yrotate (Matrix4x4 mat, float rsin, float rcos) {
		Matrix4x4 rotmat = new Matrix4x4 ();
		rotmat.SetRow (0, new Vector4 (rcos, 0, rsin, 0));
		rotmat.SetRow (1, new Vector4 (0, 1, 0, 0));
		rotmat.SetRow (2, new Vector4 (-rsin, 0, rcos, 0));
		rotmat.SetRow (3, new Vector4 (0, 0, 0, 1));

		return rotmat * mat;
	}

	Matrix4x4 zrotate (Matrix4x4 mat, float rsin, float rcos) {
		Matrix4x4 rotmat = new Matrix4x4 ();
		rotmat.SetRow (0, new Vector4 (rcos, -rsin, 0, 0));
		rotmat.SetRow (1, new Vector4 (rsin, rcos, 0, 0));
		rotmat.SetRow (2, new Vector4 (0, 0, 1, 0));
		rotmat.SetRow (3, new Vector4 (0, 0, 0, 1));

		return rotmat * mat;
	}
}
