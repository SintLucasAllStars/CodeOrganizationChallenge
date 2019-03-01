using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Critter : MonoBehaviour
{

	NavMeshAgent navAgent; 

	public Critter()
	{

	}

	public void Start()
	{
		navAgent = GetComponent<NavMeshAgent>(); 
	}

	private void Update()
	{
		Idle(15);
	}

	public void Idle(float maxDistance)
	{
		//sets a random direction
		Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
		if (navAgent != null)
		{
			
		
			if (Vector3.Distance(transform.position, navAgent.destination) < 0.5f)
			{
				
				randomDirection += transform.position;
				NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, maxDistance, 1);
				navAgent.destination = hit.position;

			}
		}
	}


}	
