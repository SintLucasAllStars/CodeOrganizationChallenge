using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature : MonoBehaviour
{
	public DNA m_DNA;

	public enum EState { Fighting, Mating, Eating, Wandering, DEAD };
	public EState eCurState = EState.Wandering;

	private MeshFilter m_Filter;

	//agent
	private NavMeshAgent m_Agent;
	private Vector3 m_Point = Vector3.zero;

	// variables for FOV
	public float m_ViewRadius;
	[Range(0,360)]
	public float m_ViewAngle;

	// change this to layer that you need to get (this is just a test)
	public LayerMask targets;

	public List<Transform> visibleTargets = new List<Transform>();
	private Transform foodTarget;

	private Creature m_OtherCreature;

	private bool m_HasStartedMating;
	private float m_LastMated;

	public int m_Age;

	float nearestDist;
	Transform nearestTarget;

	// Create energy and hunger as such
	[Range(0, 100)]
	public float m_Energy = 100;

	private void Start()
	{
		m_Agent = GetComponent<NavMeshAgent>();
		m_Filter = GetComponent<MeshFilter>();
		SetUp(false);
		StartCoroutine(MinusEnergy());
		StartCoroutine(CheckIfHasMoved());
		m_Point = transform.position;
	}

	private void SetUp(bool _hasParents)
	{
		if(_hasParents)
		{
			//create new DNA from parents
			//m_DNA = new DNA(DadGenes, MomGenes);
		}
		else
		{
			m_DNA = new DNA();
		}
		m_Filter.mesh = m_DNA.m_Genes.Shape;
		gameObject.AddComponent<MeshCollider>();
	}

	private void Update()
	{
		switch (eCurState)
		{
			case EState.Fighting:
				// Compare Strength between you and the enemy (the weakest one dies)
				if(m_OtherCreature != null)
				{
					m_OtherCreature.MoveToTarget(transform.position);
					MoveToTarget(m_OtherCreature.transform.position);
					if (Vector3.Distance(transform.position, m_OtherCreature.transform.position) < 0.5f)
					{
						InFight();
					}
				}
				break;
			case EState.Mating:
				// Search for mate (of opposite gender) in FOV, and mate if creature is close enough
				if(m_OtherCreature != null)
				{
					m_OtherCreature.MoveToTarget(transform.position);
					MoveToTarget(m_OtherCreature.transform.position);
					if (Vector3.Distance(transform.position, m_OtherCreature.transform.position) < 0.5f && !m_HasStartedMating)
					{
						m_HasStartedMating = true;
						StartCoroutine(InMate());
					}
				}
				break;
			case EState.Eating:
				EatFood();
				break;
			case EState.Wandering:
				// Walk Randomly around the map
				FindVisibleTargets();
				Debug.Log("FOV");
				if (Vector3.Distance(transform.position, m_Point) < 0.5f)
				{
					m_Point = RandomNavPos();
					m_Agent.SetDestination(m_Point);
				}
				break;
			case EState.DEAD:
				// creature died (stupid creature)
				gameObject.layer = LayerMask.NameToLayer("Dead");
				Destroy(this.gameObject);
				break;
			default:
				// Just stand still (a T-rex can only see moving things)
				break;
		}
		m_Age = (int)(Time.time / 3f);
	}

	private Vector3 RandomNavPos()
	{
		Vector3 RandDir = Random.insideUnitSphere * (m_ViewRadius * 1.5f);
		RandDir += transform.position;
		NavMeshHit navHit;
		NavMesh.SamplePosition(RandDir, out navHit, m_ViewRadius, -1);

		return navHit.position;
	}

	void FindVisibleTargets()
	{
		visibleTargets.Clear();
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, m_ViewRadius, targets);
		nearestDist = float.MaxValue;
		nearestTarget = null;

		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			if (targetsInViewRadius[i].gameObject == this.gameObject) continue;
			Transform target = targetsInViewRadius[i].transform;
			Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
			if(Vector3.Angle(transform.forward, dirToTarget) < m_ViewAngle / 2)
			{
				visibleTargets.Add(target);
			}
		}
		foreach (Transform targetTransform in visibleTargets)
		{
			if(Vector3.Distance(transform.position, targetTransform.position) < nearestDist)
			{
				nearestDist = Vector3.Distance(transform.position, targetTransform.position);
				nearestTarget = targetTransform;
			}
		}
		if(nearestTarget != null)
		{
			if (nearestTarget.tag == "Food" && m_Energy < 60f)
			{
				eCurState = EState.Eating;
			}
			else if (nearestTarget.tag == "Creature")
			{
				if (nearestTarget.GetComponent<Creature>().eCurState == EState.Wandering)
				{
					if (Random.Range(1f, 10f) < (m_DNA.m_Genes.Agression / 4f))
					{
						m_OtherCreature = nearestTarget.GetComponent<Creature>();
						//Attack other creature
						//let other creature know they will fight
						// other creature will go along with it
						m_OtherCreature.eCurState = EState.Fighting;
						eCurState = EState.Fighting;
						Debug.Log("Start Fight");
					}
					else if (m_DNA.m_Genes.Gender != nearestTarget.GetComponent<Creature>().m_DNA.m_Genes.Gender && Time.time > m_LastMated)
					{
						if (Random.Range(0f, 10f) >= (4f / 4f))
						{
							m_OtherCreature = nearestTarget.GetComponent<Creature>();
							//Mate with the other creature
							m_OtherCreature.eCurState = EState.Mating;
							eCurState = EState.Mating;
							Debug.Log("Lets Fuck");
						}
						//do nothing just wander around
					}
					//do nothing just wander around
				}
			}
		}
	}

	private void EatFood()
	{
		m_Agent.SetDestination(nearestTarget.position);
		if (Vector3.Distance(transform.position, nearestTarget.position) < 0.5f)
		{
			m_Energy += 15f;
			Destroy(nearestTarget.gameObject);
			visibleTargets.Remove(nearestTarget);
			m_Point = transform.position;
			eCurState = EState.Wandering;
			return;
		}
	}

	IEnumerator MinusEnergy()
	{
		while (eCurState != EState.DEAD)
		{
			yield return new WaitForSeconds(3f);
			float energyLost = Time.deltaTime;
			energyLost = Mathf.Clamp(energyLost, 0.009f, 0.05f);
			m_Energy = Mathf.Lerp(m_Energy, 0, energyLost);
		}
	}

	public void MoveToTarget(Vector3 _pos)
	{
		m_Agent.SetDestination(_pos);
	}

	public void InFight()
	{
		if(Vector3.Distance(transform.position, nearestTarget.position) < 0.5f)
		{
			if(m_DNA.m_Genes.Strength < m_OtherCreature.m_DNA.m_Genes.Strength)
			{
				m_OtherCreature.eCurState = EState.Wandering;
				eCurState = EState.DEAD;
				visibleTargets.Remove(nearestTarget);
				m_Point = transform.position;
			}
			else
			{
				m_OtherCreature.eCurState = EState.DEAD;
				eCurState = EState.Wandering;
				visibleTargets.Remove(nearestTarget);
				m_Point = transform.position;
			}
			m_OtherCreature = null;
		}
	}

	private IEnumerator InMate()
	{
		yield return new WaitForSeconds(4.5f);
		m_LastMated = Time.time + 20f;
		//create child
		m_OtherCreature.eCurState = EState.Wandering;
		eCurState = EState.Wandering;
		m_OtherCreature.m_HasStartedMating = false;
		m_HasStartedMating = false;
	}

	public Vector3 DirFromAngle(float _angleInDegrees, bool _isAngleGlobal)
	{
		if(!_isAngleGlobal)
		{
			_angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(_angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(_angleInDegrees * Mathf.Deg2Rad));
	}

	IEnumerator CheckIfHasMoved()
	{
		while (eCurState != EState.DEAD)
		{
			Vector3 oldPos = transform.position;
			yield return new WaitForSeconds(3.5f);
			Vector3 newPos = transform.position;
			if(oldPos == newPos)
			{
				m_Point = RandomNavPos();
				m_Agent.SetDestination(m_Point);
				Debug.Log("Chaged pos cuz idle");
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, m_ViewRadius);

		Vector3 viewAngleA = DirFromAngle(-m_ViewAngle / 2, false);
		Vector3 viewAngleB = DirFromAngle(m_ViewAngle / 2, false);

		Gizmos.DrawLine(transform.position, transform.position + viewAngleA * m_ViewRadius);
		Gizmos.DrawLine(transform.position, transform.position + viewAngleB * m_ViewRadius);

		Gizmos.color = Color.red;
		foreach (Transform visibleTarget in visibleTargets)
		{
			Gizmos.DrawLine(transform.position, visibleTarget.position);
		}
	}
}
