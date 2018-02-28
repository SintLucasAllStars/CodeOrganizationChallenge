using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

	public DNA thisDNA;

	public string type;

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

	public void Start(){
		
		meshRend = GetComponent<MeshRenderer> ();

		thisDNA = new DNA (type);

		gender = thisDNA.thisGender;

		if (gender == "male") {
			meshRend.material = malMat;
		}else {
			meshRend.material = femMat;
		}


		form = thisDNA.thisForm;

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