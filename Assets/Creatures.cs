using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour {
	enum SocialStatus {Friend, Neutral, Enemy};
	enum CombatBehaviour {Aggressive, Defensive, Coward};
	enum EatingBehaviour {omnivore, carnivore, herbivore};

	float speed;
	float size;
	float fertility;
	float attractionRate;
	float hunger;
	float age, maxAge;
	float combatEfficiency;
}
