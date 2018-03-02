using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Animals : Creatures {
	float instinct;

	public Animals (float s, float fer, float at, float ma, float a, GameObject prefabanimal) { //attempt at animal template. s size, fer fertility, at attractionRate, ma maxAge, a Aggression
		//set values
		size = s;
		fertility = fer;
		attractionRate = at;
		maxAge = ma;
		aggression = a;

		//calculating values
		combatEfficiency = size + aggression;

        GameObject currentAnimal = Instantiate(prefabanimal, new Vector3(Random.Range(499, -499), 3 , Random.Range(499, -499)), Quaternion.identity); //Instantiate the Animal.
		currentAnimal.transform.localScale = new Vector3 (size / 2, size/ 2, size / 2); //set the animal his size.

		MeshRenderer m = currentAnimal.GetComponent<MeshRenderer> ();
		m.material.SetColor ("_Color", new Color (aggression / 100, attractionRate / 100, fertility / 100)); //change the colour of the animal according to it's primary attributes.

		currentAnimal.GetComponent<NavMeshAgent>().speed = 3 / size;

        currentAnimal.GetComponent<SphereCollider>().radius = aggression / 5; //sets the detection radius
    }
}