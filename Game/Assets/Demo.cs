using UnityEngine;
using UnityEditor;
using System.Collections;

public class Demo : MonoBehaviour {

	public GameObject starModel;
	public GameObject planetModel;
	public GameObject pathModel;
	public GameObject db;
	private Database database;
	private Material[] planetSkins;
	private float[] xR;
	private float[] zR;
	private float[] offset;
	private int SCALE = 100;
	private int time = 1;


	private GameObject star;
	private GameObject[] planets;
	private GameObject[] paths;

	// Use this for initialization
	void Start () {
		loadDatabase ();

		star = createStar ();
		star.transform.position = new Vector3 (0, 0, 0);

		planets = new GameObject[(int)(UnityEngine.Random.value*9)+3];
		paths = new GameObject[planets.Length];
		createPlanetEllipses ();
		createOffsets ();
		for (int i = 0; i < planets.Length; i++) {
			planets[i] = createPlanet(i);
			paths [i] = createPath (i);
		}
	}
	
	// Update is called once per frame
	void Update () {
		star.transform.Rotate ((float)(0.05),(float)(0.05),(float)(0.05));
		for (int i = 0; i < planets.Length; i++) {
			planets[i].transform.position = new Vector3((int) (xR[i]*System.Math.Cos(offset[i]+Time.frameCount*time/5000.0)), 0,(int) (zR[i]*System.Math.Sin(offset[i]+Time.frameCount*time/5000.0)));
			float rotationMultiplier = (((float)(100-(System.Math.Sqrt(System.Math.Pow(xR [i],2)+System.Math.Pow(zR [i],2)) / 100.0))) * 20)/5000*time;
			planets[i].transform.RotateAround (planets[i].transform.position, planets[i].transform.up, rotationMultiplier);
		}

	}

	public GameObject createStar(){
		GameObject star = (GameObject)Instantiate (starModel);
		StarStats starStats = star.GetComponent<StarStats> ();
		starStats.mass = 5;
		star.transform.localScale = new Vector3 (15*SCALE, 15*SCALE, 15*SCALE);
		star.renderer.material = database.s0;
		return star;
	}

	public GameObject createPlanet(int num){
		GameObject planet = (GameObject)Instantiate (planetModel);
		PlanetStats planetStats = planet.GetComponent<PlanetStats> ();
		planetStats.mass = 1;
		float scaleMultiplier = (((float)(xR [num] / 100.0)) * 5 + 95)/100;
		planet.transform.localScale = new Vector3 (scaleMultiplier*SCALE, scaleMultiplier*SCALE, scaleMultiplier*SCALE);
		planetStats.a = xR [num];
		planetStats.b = zR [num];
		planet.transform.Rotate (offset [num], offset [num], offset [num]);
		planet.renderer.material = planetSkins[num];
		return planet;
	}

	public GameObject createPath(int num){
		GameObject path = (GameObject)Instantiate (pathModel);
		DrawPath drawpath = path.GetComponent<DrawPath>();
		drawpath.xradius = xR[num];
		drawpath.zradius = zR[num];
		return path;

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

	public void createPlanetEllipses(){
		xR = new float[planets.Length];
		zR = new float[planets.Length];


		float[] pool1 = new float[45];
		for (int i = 0; i < pool1.Length; i++) {
			pool1 [i] = 2*i+10;
		}
		pool1 = shuffle (pool1);
		for (int i = 0; i < pool1.Length; i++) {
			Debug.Log (pool1[i]);
		}

		float[] pool2 = new float[45];
		for (int i = 0; i < pool2.Length; i++) {
			pool2 [i] = 2*i+10;
		}
		pool2 = shuffle (pool2);

		for (int i = 0; i < planets.Length; i++) {
			xR[i] = pool1[i]*SCALE;
			zR[i] = pool2[i]*SCALE;
		}
		System.Array.Sort (xR);
		System.Array.Sort (zR);
	}

	public void createOffsets(){
		offset = new float[planets.Length];
		for (int i = 0; i < offset.Length; i++) {
			offset [i] = (float)(UnityEngine.Random.value * 2 * System.Math.PI);
		}

	}
	public Material[] shuffleSkins(Material[] a){
		for (int i = a.Length; i > 1; i--)
		{
			int j = (int)(UnityEngine.Random.value*i);
			Material tmp = a[j];
			a[j] = a[i - 1];
			a[i - 1] = tmp;
		}
		return a;
	}

	public float[] shuffle(float[] a){
		for (int i = a.Length; i > 1; i--)
		{
			int j = (int)(UnityEngine.Random.value*i);
			float tmp = a[j];
			a[j] = a[i - 1];
			a[i - 1] = tmp;
		}
		return a;
	}

	public float[] sort(float[] a){
		for (int i = 0; i < a.Length-1; i++) {
			if (a [i] > a [i + 1]) {
				float t = a [i+1];
				a [i+1] = a [i];
				a [i] = t;
				i = 0;
			}
		}
		return a;
	}
}
