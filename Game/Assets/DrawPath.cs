﻿using UnityEngine;
using System.Collections;

public class DrawPath : MonoBehaviour
{
	public int segments;
	public float xradius;
	public float zradius;
	LineRenderer line;

	void Start ()
	{
		line = gameObject.GetComponent<LineRenderer>();

		line.SetVertexCount (segments + 1);
		line.useWorldSpace = false;
		CreatePoints ();
	}


	void CreatePoints ()
	{
		float x;
		float y = 0f;
		float z;

		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Cos (Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Sin (Mathf.Deg2Rad * angle) * zradius;

			line.SetPosition (i,new Vector3(x,y,z) );

			angle += (360f / segments);
		}
	}
}