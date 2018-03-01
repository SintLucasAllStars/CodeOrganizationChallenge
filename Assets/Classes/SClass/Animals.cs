using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : Creatures {
	float instinct;

	void Start () {
		GetComponent<SphereCollider> ().radius = combatEfficiency / 2 + aggression;
	}
}
