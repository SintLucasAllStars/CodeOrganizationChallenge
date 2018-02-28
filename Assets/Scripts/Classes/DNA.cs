using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA {

	// DNA Type Values (string)
	public string[] gender = new string[] {"male","female","other"};
	public string thisGender;
	public string[] form = new string[] {"A","B","C"};
	public string thisForm;

	// DNA Float Values
	public float health;
	public float strength;
	public float speed;
	public float hunger;
	public float pride;
	public float carcassValue;
	public float age;

	// True Random
	public DNA(){

		// Generate gender and form
		thisGender = gender[Random.Range(0,2)].ToString();
		thisForm = thisForm [Random.Range (0, 2)].ToString();

		// Generate random values 25-100
		health = Random.Range (25, 101);
		strength = Random.Range (25, 101);
		speed = Random.Range (25, 101);
		hunger = Random.Range (25, 101);
		pride = Random.Range (25, 101);
		carcassValue = 0;
		age = 0;

	}

	// Creature Specific
	public DNA(string thisForm) {
		
		this.thisForm = thisForm;

		//Checks if thisForm is equal to one of the forms, creates values accordingly
		if (thisForm == "A") {
			thisGender = gender [Random.Range (0, 2)].ToString ();
			health = Random.Range (61, 60);
			strength = Random.Range (81, 101);
			speed = Random.Range (40, 61);
			hunger = Random.Range (25, 101);
			pride = Random.Range (81, 101);
			carcassValue = 0;
			age = 0;
		} else if (thisForm == "B") {
			thisGender = gender [Random.Range (0, 1)].ToString ();
			health = Random.Range (81, 101);
			strength = Random.Range (40,60);
			speed = Random.Range (61, 80);
			hunger = Random.Range (25,101);
			pride = Random.Range (61,81);
			carcassValue = 0;
			age = 0;
		} else if (thisForm == "C") {
			thisGender = gender [Random.Range (0, 1)].ToString ();
			health = Random.Range (81, 101);
			strength = Random.Range (61, 81);
			speed = Random.Range (81, 101);
			hunger = Random.Range (25, 101);
			pride = Random.Range (40,60);
			carcassValue = 0;
			age = 0;
		} else {
			Debug.Log ("SYNTAX ERROR");
		}

	}

}