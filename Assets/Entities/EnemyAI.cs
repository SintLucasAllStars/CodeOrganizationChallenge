using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour {

	RaycastHit 		hit;

	NavMeshAgent 	agent;

	Transform 		target;

	public float 	aggression;
	public float	attractionRate;
	public float 	combatEfficiency;
	public float 	fertility;

	public Vector3 currentDest;
	Transform otherCreature;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void LateUpdate()
	{
		if (agent.remainingDistance < 0.5f) 
		{
			currentDest = new Vector3 (Random.Range (499, -499), 3, Random.Range (499, -499));
			GetComponent<NavMeshAgent> ().SetDestination (currentDest);
		}
	}
}
