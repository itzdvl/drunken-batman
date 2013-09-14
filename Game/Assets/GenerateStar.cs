using UnityEngine;
using System.Collections;

public class GenerateStar : MonoBehaviour {

	public GameObject star;

	// Use this for initialization
	void Start () {
		Instantiate (star);
		star.transform.position = new Vector3 (0, 0, 0);
		//sphere.transform.scale = Vector3(1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
