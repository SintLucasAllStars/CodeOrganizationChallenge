using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Critter : MonoBehaviour
{

	
	Attributes Gene; 
	Attributes.Diet m_Diet;

	NavMeshAgent navAgent;
	GameObject Creature;
	Critter critterscript;

	public StateCritter AICritter; 
	public enum StateCritter
	{
		Fight, Idle, Mate, 
	};

	public float VisionOfCritter; 
	public float m_Hunger;


	public Critter()
	{
		
	}

	public void Start()
	{
		navAgent = GetComponent<NavMeshAgent>(); 

	}

	private void Update()
	{
		CritterStates();
		See();

		if (Creature != null)
		{
			critterscript = Creature.GetComponent<Critter>();
			if (Gene.isMale == critterscript.Gene.isMale && critterscript.AICritter != StateCritter.Mate)
			{
				Debug.Log("1");
				AICritter = StateCritter.Fight; 
			}

		}
		
	}
	
	public void CritterStates()
	{
		switch (AICritter)
		{
			case 
				StateCritter.Fight:
				if (Creature != null)
				{
					Debug.Log("2");
					Fight(critterscript);
				}
				
			break;

			case 
				StateCritter.Idle:
				Idle(15);
			break;

			case 
				StateCritter.Mate:
			break; 
		}
	}

	public void See()
	{
		//array for all creatures.
		GameObject[] otherCritter = GameObject.FindGameObjectsWithTag("Creature");

		//checks for the closest critter
		for (int i = 0; i < otherCritter.Length; i++)
		{
			
			if (Vector3.Distance(this.transform.position, otherCritter[i].transform.position) < VisionOfCritter && !otherCritter[i].Equals(this.gameObject))
			{
				Debug.Log("Critter is in range of me");
				//creates a var vor nearest critter
				Creature = otherCritter[i].gameObject;

			}
		}
	}
	
	public void Fight(Critter OtherCreature)
	{
		
		

		//checks if the aggression of the critter is greater then his resolve. 
		if (m_Hunger >= Gene.m_Aggression)
		{
			Debug.Log("3");
			if (Gene.m_Strength >= OtherCreature.Gene.m_Strength)
			{
				Debug.Log("4a");
				Destroy(Creature.gameObject);
				m_Hunger = 0;
				AICritter = StateCritter.Idle;
			}
			else
			{
				Debug.Log("4b");
			}

		}
	}

	public void Idle(float maxDistance)
	{
		//sets a random direction.
		Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
		if (navAgent != null)
		{
			
			//checks if the critter reached that dir. 
			if (Vector3.Distance(transform.position, navAgent.destination) < 0.5f)
			{
				//sets a new dir.
				randomDirection += transform.position;
				NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, maxDistance, 1);
				navAgent.destination = hit.position;

			}
		}
	}


}	
