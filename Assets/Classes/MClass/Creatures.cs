using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour {
	//public enum EatingBehaviour {omnivore, carnivore, herbivore}; // determines what the creature eats, omnivore and carnivore increase aggression.

	//These are the variales used to create creatures that roam the world
	public float size; // You use this to see how big and strong a creature is, a high size value also gives a bonus to combat efficiency
	public float fertility; // You use this to see how much change a creature has to get a child
	public float attractionRate; // You use this to see how many times a creature would try to breed
	public float hunger; // You use this to see if a creature needs to eat
	public float age, maxAge; // You use this to determine a creature's current age and age when it dies
	public float combatEfficiency; // You use this to see how likely a creature is to win a fight
	public float aggression; // You use this to determine how fast it detects creatures. A higher value will also make it more likely to attack a other creature

	Transform otherCreature;


	public void OnTriggerEnter (Collider coll) //template SHOULD BE IN ANIMALS AND HUMANS 
	{ 
		float engage;
        otherCreature = coll.gameObject.transform;
		engage = aggression + Random.Range (1, 50); // determine what the creature is going to do.
		if (engage > 99) { // Approach the target and try to attack it.
			transform.position = Vector3.MoveTowards(transform.position, otherCreature.position, 5); //move towards the target. "needs tweaking on values"
		}
		if (engage < 49) { // Run away and try to flee from the target.
			transform.position = Vector3.MoveTowards (transform.position, otherCreature.position, -5); //move away from the target. "needs tweaking on values"
		}
	}
}
