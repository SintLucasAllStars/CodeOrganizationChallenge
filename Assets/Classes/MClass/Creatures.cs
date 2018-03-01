using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creatures : MonoBehaviour {
	public enum SocialStatus {Friend, Neutral, Enemy};
	public enum CombatBehaviour {Aggressive, Defensive, Coward};
	public enum EatingBehaviour {omnivore, carnivore, herbivore};

	//These are the variales used to create creatures that roam the world
	public float speed;
	public float size; // You use this to see how big and strong a creature is, a high size value also gives a bonus to combat efficiency.
	public float fertility; // You use this to see how much change a creature has to get a child
	public float attractionRate; // You use this to see how many times a creature would try to breed
	public float hunger; // You use this to see if a creature needs to eat.
	public float age, maxAge; // You use this to determine a creature's current age and age when it dies.
	public float combatEfficiency; // You use this to see how likely a creature is to win a fight.
	public float aggression; // You use this to determine how fast it detects creatures. A higher value will also make it more likely to attack a other creature.

	GameObject otherCreatures;

	public void setDetection () {
		GetComponent<SphereCollider> ().radius = combatEfficiency / 2 + aggression; //this will be used to determine a creature's detection radius
	}
	public void OnTriggerEnter (Collision coll) {
		
	}
	public void Encounter () {
		float engage;
		engage = aggression + Random.Range (1, 50);
		if (engage > 99) {
			
		}
	}
}
