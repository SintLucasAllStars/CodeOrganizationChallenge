using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseCreature : MonoBehaviour
{

    enum AIState
    {
        Wander,
        Eat,
        Attack,
        Mate,
        CoolDown
    }

    //AI
    NavMeshAgent navAgent;
    public Genes myGenes;
    public DNA myDNA = new DNA();
    public GameObject Mesh;
    public GameObject babyPrefab;
   

    public float SightRadius = 45.0f;
    private bool bhasChild;
    private bool m_Attacking;
    private bool m_Mating;
    private GameObject m_nearestCreature;
    private AIState m_AiState;

    // Start is called before the first frame update
    void Start()
    {

       navAgent = GetComponent<NavMeshAgent>();
       myDNA.genes = myGenes;
        myDNA.genes.skinColor = Random.ColorHSV();
        bhasChild = false;
        
        Mesh.GetComponent<MeshRenderer>().material.color = myDNA.genes.skinColor;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_nearestCreature)
        {
            var otherCreature = m_nearestCreature.GetComponent<BaseCreature>();
            if (otherCreature.myGenes.Gender == myGenes.Gender && !m_Mating)
            {
                m_AiState = AIState.Attack;
            }
            else
            {
                m_AiState = AIState.Mate;
            }
        }
        //dit is in update
        AiBehaviour();
       

    }

    //CreatureBehaviour
    void AiBehaviour()
    {
        switch (m_AiState)
        {
            case AIState.Wander:
                Wander(15);
                GetAllNearbyCreatures();
                break;
            case AIState.Attack:
                Attack(m_nearestCreature.GetComponent<BaseCreature>());
                break;
            case AIState.Mate:
                Mate(m_nearestCreature.GetComponent<BaseCreature>());
                
                break;
            case AIState.CoolDown:
                Wander(15);
                break;
            case AIState.Eat:
                //Eat Something
                break;
        }
    }

    //lets creature walk randomly
    void Wander(float maxDistance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
        NavMeshHit hit;

        if (navAgent)
        {
            if (transform.position == navAgent.destination)
            {
                randomDirection += transform.position;
                NavMesh.SamplePosition(randomDirection, out hit, maxDistance, 1);
                navAgent.destination = hit.position;

            }
        }
    }

    //AttackFunction
    void Attack(BaseCreature Enemy)
    {

        if (Enemy.myGenes.Strength > myGenes.Strength)
        {
            Destroy(this.gameObject);
           
        }
        else
        {
            Destroy(Enemy.gameObject);
            m_AiState = AIState.Wander;
        }
       
        
        
    }

    //MatingFunction
    void Mate(BaseCreature Creature)
    {
       
            navAgent.destination = Creature.gameObject.transform.position;
            if (myGenes.Gender == GenderType.Female)
            {

                var child = Instantiate(babyPrefab, this.transform.position, Quaternion.identity);
                
                var childGenes = child.GetComponent<BaseCreature>();
                
                childGenes.myGenes.Gender = Creature.myGenes.Gender;
                childGenes.myGenes.foodType = myGenes.foodType;
                childGenes.myGenes.skinColor = myGenes.skinColor;
                childGenes.MatingCoolDown(5);
     
            }
            m_nearestCreature = null;
         StartCoroutine(MatingCoolDown(5));


    }


   //Check if creature or food is nearby
   void GetAllNearbyCreatures()
    {
        GameObject[] Creatures = GameObject.FindGameObjectsWithTag("Creature");

        for (int i = 0; i < Creatures.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, Creatures[i].transform.position) < SightRadius && !Creatures[i].Equals(this.gameObject))
            {
                Debug.Log("CreatureFound");
                m_nearestCreature = Creatures[i].gameObject;
                

            }
            

        }
       
        

        
    }


    IEnumerator MatingCoolDown(float waitTime)
    {
        m_AiState = AIState.CoolDown;
        yield return new WaitForSeconds(waitTime);
        m_AiState = AIState.Wander;
    }

}

    
    
