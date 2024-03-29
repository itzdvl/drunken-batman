﻿using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour {

	public Vector3 startPos;
	public GameObject ground;

	float xSensitivity = 5;
	float ySensitivity = 5;


	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		transform.GetChild(0).transform.Rotate (270,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		getMovementInput ();

	}

	void getMovementInput() {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (10*Vector3.forward);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (10*Vector3.left);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-10*Vector3.forward);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (10*Vector3.right);
		}
		if (Input.GetKey (KeyCode.Space)) {
			transform.Translate (10*Vector3.up);
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			transform.Translate (10*Vector3.down);
		}

		float h = xSensitivity * Input.GetAxis ("Mouse X");

		float v = ySensitivity * Input.GetAxis ("Mouse Y");
		transform.Rotate (-v, h, 0);
		transform.localEulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);

	}
}
