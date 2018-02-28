using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

	private DNA thisDNA;

	[Header("Set this type")]
	[Tooltip("Set value to A, B or C to generate accordingly")]
	public string type;

	[Header("Values generated from DNA")]
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

	public void Start(){
		
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
		if (form == "V") {
			meshFilter.mesh = cylinder;
			gameObject.AddComponent<MeshCollider> ();
		}

		health = thisDNA.health;
		strength = thisDNA.strength;
		speed = thisDNA.speed;
		hunger = thisDNA.hunger;
		pride = thisDNA.pride;
		carcassValue = thisDNA.carcassValue;
		age = thisDNA.age;

	}

	public void Update(){
	

	
	}

}