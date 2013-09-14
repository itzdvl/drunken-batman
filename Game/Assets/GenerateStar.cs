using UnityEngine;
using System.Collections;

public class GenerateStar : MonoBehaviour {

	public GameObject starModel;
	public GameObject planetModel;
	private GameObject star;
	private GameObject[] planets;

	// Use this for initialization
	void Start () {
		star = starModel;
		Instantiate (star);

		planets = new GameObject[4];
		for (int i = 0; i < planets.Length; i++) {

			planets[i] = (GameObject) Instantiate (planetModel);
		}
		
		star.transform.position = new Vector3 (0, 0, 0);

		for (int i = 0; i < planets.Length; i++) {
			int angle = (int)(UnityEngine.Random.value*359);
			Debug.Log (angle);
			int r = (int)((UnityEngine.Random.value*9) + 5);

			planets[i].transform.position = new Vector3((int) (r*System.Math.Cos(angle)),0,(int) (r*System.Math.Sin(angle)));
		}
		//sphere.transform.scale = Vector3(1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
