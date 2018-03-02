using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : Creatures {
	float instinct;

	public Animals (EatingBehaviour eB, float sz, float fer, float at, float ma, float a) { //attempt at animal template. sz size, fer fertility, at attractionRate, ma maxAge, a Aggression
		sz = size;
		fer = fertility;
		at = attractionRate;
		ma = maxAge;
		a = aggression;
		GetComponent<SphereCollider> ().radius = combatEfficiency / 2 + aggression; //sets the detection radius
		combatEfficiency = size + a;
		speed = 1 / size;
	}
}
