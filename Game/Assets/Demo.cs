using UnityEngine;
using UnityEditor;
using System.Collections;

public class Demo : MonoBehaviour {

	public GameObject starModel;
	public GameObject planetModel;
	public GameObject db;
	private Database database;
	private Material[] planetSkins;


	private GameObject star;
	private GameObject[] planets;

	// Use this for initialization
	void Start () {
		loadDatabase ();


		star = createStar ();

		planets = new GameObject[8];
		for (int i = 0; i < planets.Length; i++) {
			planets[i] = createPlanet(i);
		}
		
		star.transform.position = new Vector3 (0, 0, 0);

		for (int i = 0; i < planets.Length; i++) {
			int angle = (int)(UnityEngine.Random.value*359);
			int r = (int)((UnityEngine.Random.value*10)*2 + 5);

			planets[i].transform.position = new Vector3((int) (r*System.Math.Cos(angle)),0,(int) (r*System.Math.Sin(angle)));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject createStar(){
		GameObject star = starModel;
		Instantiate (star);
		StarStats starStats = star.GetComponent<StarStats> ();
		starStats.mass = 5;
		star.renderer.material = database.s0;
		return star;
	}

	public GameObject createPlanet(int num){
		GameObject planet = (GameObject)Instantiate (planetModel);
		PlanetStats planetStats = planet.GetComponent<PlanetStats> ();
		planetStats.mass = 1;
		planet.renderer.material = planetSkins[num];
		return planet;
	}

	private void loadDatabase(){
		database = db.GetComponent<Database> ();
		planetSkins = new Material[] {
			database.p1,
			database.p2,
			database.p3,
			database.p4,
			database.p5,
			database.p6,
			database.p7,
			database.p8,
			database.p9,
			database.p10,
			database.p11,
			database.p12,
			database.p13,
			database.p14,
			database.p15,
			database.p16,
			database.p17,
			database.p18,
			database.p19,
			database.p20
		};
		planetSkins = (Material[])shuffleSkins(planetSkins);
	}

	public Material[] shuffleSkins(Material[] a){
		int n = a.Length;  
		while (n > 1) {  
			n--;  
			int k = (int)UnityEngine.Random.value*(n+1);  
			Material value = a[k];  
			a[k] = a[n];  
			a[n] = value;  
		}
		return a;
	}
}
