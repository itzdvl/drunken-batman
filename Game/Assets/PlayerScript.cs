using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour {

	public Vector3 startPos;
	public GameObject ground;

	float xSensitivity = 5;
	float ySensitivity = 5;



	// Use this for initialization
	void Start () {

		transform.position = startPos;

	}
	
	// Update is called once per frame
	void Update () {
		getMovementInput ();

	}

	void getMovementInput() {

		float xComponent = (float) (-0.1 * Math.Cos (transform.localEulerAngles.y*Math.PI/180+Math.PI/2));
		float zComponent = (float) (0.1 * Math.Sin (transform.localEulerAngles.y*Math.PI/180+Math.PI/2));

		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (xComponent,0,zComponent,Space.World);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate ((float)(-0.1), 0, 0);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-xComponent,0,-zComponent,Space.World);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate ((float)(0.1), 0, 0);
		}

		float h = xSensitivity * Input.GetAxis ("Mouse X");
		float v = ySensitivity * Input.GetAxis ("Mouse Y");
		transform.Rotate (-v, h, 0);
		transform.localEulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);

	}
}
