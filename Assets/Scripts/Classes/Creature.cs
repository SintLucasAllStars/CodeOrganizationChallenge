using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

	#region DNA

	private DNA thisDNA;

	[Header("Set this type - A, B or C")]
	[Tooltip("Set value to A, B or C to generate accordingly")]
	public string type;

	[Header("DNA Generated Values - DON'T EDIT THESE")]
	[Tooltip("Do not change these values - this is generated from DNA")]
	public string gender;
	public string form;
	public float health;
	public float strength;
	public float speed;
	public float hunger;
	public float pride;
	public float carcassValue;
	public float age;
	public MeshRenderer meshRend;
	public Material femMat;
	public Material malMat;
	public MeshFilter meshFilter;
	public Mesh cube;
	public Mesh sphere;
	public Mesh cylinder;

	#endregion

	public void Start(){
		
		#region OOP setup
		meshRend = GetComponent<MeshRenderer> ();
		meshFilter = GetComponent<MeshFilter> ();

		thisDNA = new DNA (type);

		gender = thisDNA.thisGender;
		if (gender == "male") {
			meshRend.material = malMat;
		}else {
			meshRend.material = femMat;
		}

		form = thisDNA.thisForm;
		if (form == "A") {
			meshFilter.mesh = cube;
			gameObject.AddComponent<BoxCollider> ();
		}
		if (form == "B") {
			meshFilter.mesh = sphere;
			gameObject.AddComponent<SphereCollider> ();
		}
		if (form == "C") {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
			meshFilter.mesh = cylinder;
			gameObject.AddComponent<MeshCollider> ();
			gameObject.GetComponent<MeshCollider> ().convex = true;
		}

		health = thisDNA.health;
		strength = thisDNA.strength;
		speed = thisDNA.speed;
		hunger = thisDNA.hunger;
		pride = thisDNA.pride;
		carcassValue = thisDNA.carcassValue;
		age = thisDNA.age;
		#endregion

		StartCoroutine (randMovement ());

	}

	public void Update(){

		#region Movement

		transform.Translate(Vector3.forward * speed / 20 * Time.deltaTime);

		#endregion

	}

	public IEnumerator randMovement(){

		transform.Rotate (0, Random.Range (-50f, 50f), 0);
		yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
		StartCoroutine (randMovement ());

	}

}