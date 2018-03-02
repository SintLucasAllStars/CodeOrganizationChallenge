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

	public GameObject wm;

	// Type to set and read the current state of individual creature
	public enum LifeState {alive,dead,hungry,combat,mating};
	public LifeState currentState;

	// Raycast to detect food/fighting/fucking
	RaycastHit hit;

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

		//wm = GameObject.FindGameObjectWithTag ("World Manager");

		// Set initial rotation to a random degree (else they all walk in the same direction at start)
		gameObject.transform.eulerAngles = new Vector3 (0,Random.Range(0,361),0);


		// Set lifestate to alive on start
		currentState = LifeState.alive;

	}

	public void Update(){

		switch (currentState) {
		case LifeState.alive:
			Alive ();
			Aging ();
		break;
		case LifeState.dead:
			Dead ();
		break;
		case LifeState.hungry:
		break;
		case LifeState.combat:
		break;
		case LifeState.mating:
		break;
		default:
			
		break;
		}

	}

	public void Aging(){

		age = age + 1f * Time.deltaTime / 0.017f;

	}

	public void Alive(){

		// This will become a proper movement function at some point, sorry David/Luc i'm  too lazy to fix it right now. :(
		transform.Translate(Vector3.forward * speed / 20 * Time.deltaTime);
		StartCoroutine (randMovement ());

		if (hunger <= 20) {
			currentState = LifeState.hungry;
		}

	}

	public void Dead(){
	
		gameObject.tag = "Food";

	}

	public void Hungry(){



	}

	public IEnumerator randMovement(){

		transform.Rotate (0, Random.Range (-50f, 50f), 0);
		yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
		StartCoroutine (randMovement ());

	}

}