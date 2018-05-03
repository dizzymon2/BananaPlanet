using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitField : MonoBehaviour {

	public GameObject orbitingObject;
	public Ellipse orbitPath;
	private Rigidbody2D rb;
	public bool clockwise = true;
	public bool tmp=true;
	[Range(0f,1f)]
	public float orbitProgress = 0f;
	public float orbitPeriod = 3f;
	public bool orbitActive = false; 


	// Use this for initialization

		
	float dist(Vector3 a, Vector3 b){
		float c = a.x - b.x;
		float d = a.y - b.y;
		return Mathf.Sqrt (d * d + c * c);
	}

	void Clicked()
	{
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit = new RaycastHit();
		print ("!!");
		if (Physics.Raycast (ray, out hit)) {
			Debug.Log (hit.collider.gameObject.name);
		} else if(orbitActive){
			Shoot ();
		}
	}
	void Shoot()
	{
		orbitActive = false;

		Vector2 v2 = orbitingObject.transform.position - this.transform.position;

		if (clockwise) {
			v2 = new Vector2 (-v2.y, v2.x);
		} else {
			v2 = new Vector2 (v2.y, -v2.x);
		}
		print (v2.x);
		print (v2.y);
		rb.velocity = v2;

	}

	void Update(){
		print (rb.velocity.x + "!!!!");
		print (rb.velocity.y + "@@@@");
		if (tmp && orbitActive == false && orbitingObject != null && dist (orbitingObject.transform.position, this.transform.position) <= orbitPath.xAxis) {
			orbitActive = true;
			tmp = false;
			orbitProgress = Mathf.Atan2 (orbitingObject.transform.position.y - this.transform.position.y,
				orbitingObject.transform.position.x - this.transform.position.x) / (Mathf.PI * 2);
			StartCoroutine (AnimateOrbit ());
		} else {
			if (Input.GetMouseButtonDown(0))
			{
				Clicked();
			}
		}

	}

	void SetOrbitingObjectPosition(){
		Vector2 orbitPos = orbitPath.Evaluate (orbitProgress);
		orbitingObject.transform.position = new Vector3 ((orbitPos.x+this.transform.position.x), orbitPos.y+this.transform.position.y, 0.1f);
	}

	IEnumerator AnimateOrbit(){
		if (orbitPeriod < 0.1f) {
			orbitPeriod = 0.1f;
		}
		float OrbitSpeed = 1f / orbitPeriod;
		while (orbitActive) {
			orbitProgress += Time.deltaTime * OrbitSpeed;
			orbitProgress %= 1f;
			SetOrbitingObjectPosition ();
			yield return null;
		}
	}

	void Start()
	{
		rb = orbitingObject.GetComponent<Rigidbody2D> ();

	}

	
}
