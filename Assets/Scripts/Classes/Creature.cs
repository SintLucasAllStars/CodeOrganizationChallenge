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

		// Find worldmanager if we need to pull some info from it
		wm = GameObject.FindGameObjectWithTag ("World Manager");

		// Set initial rotation to a random degree (else they all walk in the same direction at start)
		gameObject.transform.eulerAngles = new Vector3 (0,Random.Range(0,361),0);


		// Set lifestate to alive on start
		currentState = LifeState.alive;
		StartCoroutine (randMovement ());

	}

	public void Update(){

		#region State Switch

		switch (currentState) {
		case LifeState.alive:
			Alive ();
			Aging ();
		break;
		case LifeState.dead:
			Dead ();
		break;
		case LifeState.hungry:
			Hungry ();
		break;
		case LifeState.combat:
			// It should activate Combat() and fight with the other creature.
			// One of the creatures should die, resorting to Dead() and the
			// -other creature will return to Alive() and continue the simulation.
		break;
		case LifeState.mating:
			// It should activate Mating() and mate with another creature to make a new creature,
			// -inheriting dna from both parents and normalizing the values to an acceptable number
			// -to avoid insanely strong creatures too early in the simulation.
		break;
		default:
			//It should only go default if something went wrong, in which case we want to terminate the test subject.
			Dead ();
		break;
		}

		#endregion

	}

	#region Lifestate Functions

	public void Aging(){

		// The creatures age up.
		age = age + 0.017f * Time.deltaTime;

	}

	public void Alive(){

		// Moves forward when living
		transform.Translate(Vector3.forward * speed / 20 * Time.deltaTime);

		// When the creature gets hungry it activates Hungry state
		if (hunger <= 20) {
			currentState = LifeState.hungry;
		}

	}

	public void Dead(){

		// It should also become a carcass.
		// -This can be done by just changing current material
		// -to a more "dead" coloured material.
		gameObject.tag = "Food";

	}

	public void Hungry(){

		// It should find the closest food and eat it.
		// We would do this by accessing the list of food
		// -from the world manager, and then finding the closest
		// -gameobject of type food and going towards it.

	}

	#endregion

	#region IENumerators

	public IEnumerator randMovement(){

		// We're using a looping IENumerator for our random creature movements.
		// Proper function coming soon^tm
		yield return new WaitUntil(() => currentState >= LifeState.alive);
		transform.Rotate (0, Random.Range (-50f, 50f), 0);
		yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
		StartCoroutine (randMovement ());

	}

	#endregion

	#region Collisions

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
    }

	#endregion

}