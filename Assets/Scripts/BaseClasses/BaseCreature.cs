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

    //Public
    
    public Genes myGenes;
    public DNA myDNA = new DNA(); 
    public GameObject Mesh;
    public GameObject babyPrefab;
    public float SightRadius = 45.0f;

    //Private
    private NavMeshAgent navAgent;
    private bool m_Mating = false;
    private GameObject m_nearestCreature;
    private GameObject m_NearFood;
    private AIState m_AiState;

    // Start is called before the first frame update
    void Start()
    {

       navAgent = GetComponent<NavMeshAgent>();
        myDNA.genes.Size = Random.Range(1, 2.5f);
        myDNA.genes = myGenes;
        myDNA.genes.Aggresion = Random.Range(0, 11);
        
        //Set Skin Color Based on Gender
        if (myGenes.Gender == GenderType.Female)
        {
            myDNA.genes.skinColor = Random.ColorHSV(0.3f,0.33f);
        }
        else
        {
            myDNA.genes.skinColor = Random.ColorHSV(0,0.1f);
        }
        Mesh.GetComponent<MeshRenderer>().material.color = myDNA.genes.skinColor;
        //

       Mesh.transform.localScale *= myDNA.genes.Size; 
    }

    // Update is called once per frame
    void Update()
    {
        //Check if there is a creature near.
        if (m_nearestCreature)
        {         
            var otherCreature = m_nearestCreature.GetComponent<BaseCreature>();
            if (otherCreature.myGenes.Gender == myGenes.Gender && !m_Mating && myDNA.genes.Aggresion > 5)
            {
                m_AiState = AIState.Attack;  // goto attacking state
            }
            else if(otherCreature.m_AiState != AIState.Attack)
            {
                m_AiState = AIState.Mate;   // goto mating state
            }
        }
        else if (m_NearFood)
        {
            m_AiState = AIState.Eat; //Go to EatingState
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
                if (m_nearestCreature)
                { 
                Attack(m_nearestCreature.GetComponent<BaseCreature>());
                }
                else
                {
                    m_AiState = AIState.Wander;
                }
                break;

            case AIState.Mate:
                if (m_nearestCreature)
                {
                    Mate(m_nearestCreature.GetComponent<BaseCreature>());
                }
                else
                {
                    m_AiState = AIState.Wander;
                }
                break;

            case AIState.CoolDown:
                Wander(35);
                break;

            case AIState.Eat:
                if (m_NearFood)
                {
                  Eat(m_NearFood.GetComponent<Food>());
                }
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
        navAgent.destination = m_nearestCreature.transform.position;
        if ((this.transform.position - m_nearestCreature.transform.position).magnitude < SightRadius / 2)
        {
            if (Enemy.myGenes.Strength >= myGenes.Strength)
            {
                Destroy(this.gameObject);

            }
            else
            {
                Destroy(Enemy.gameObject);
                m_AiState = AIState.Wander;
            }
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

            if (Random.Range(0, 2) == 1)
            {
                childGenes.myGenes.Gender = GenderType.Male;
            }
            else
            {
                childGenes.myGenes.Gender = GenderType.Female;
            }
                childGenes.myGenes.Strength = Creature.myGenes.Strength;
                childGenes.myGenes.skinColor = myGenes.skinColor;
                childGenes.myGenes.Size = Creature.myGenes.Size;
                childGenes.babyPrefab = this.babyPrefab;
                childGenes.m_nearestCreature = null;
                childGenes.MatingCoolDown(10);
            
            }
            Creature.m_nearestCreature = null;
            Creature.StartCoroutine(Creature.MatingCoolDown(10));
            m_nearestCreature = null;
            StartCoroutine(MatingCoolDown(10));
            


    }

    //EatFunction
    void Eat(Food food)
    {
        if (!food.poisoness)
        {
            myDNA.genes.Aggresion = 0;
            Destroy(food.gameObject);
            m_NearFood = null;
            m_AiState = AIState.Wander;
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(food.gameObject);
        }

    }

    //Check if creature or food is nearby
    void GetAllNearbyCreatures()
    {
        GameObject[] Creatures = GameObject.FindGameObjectsWithTag("Creature");
        GameObject[] Food = GameObject.FindGameObjectsWithTag("Food");

        for (int i = 0; i < Creatures.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, Creatures[i].transform.position) < SightRadius && !Creatures[i].Equals(this.gameObject))
            {
          
                m_nearestCreature = Creatures[i].gameObject;
                

            }
            

        }

        for (int i = 0; i < Food.Length; i++)
        {
            if(Vector3.Distance(this.transform.position, Food[i].transform.position) < SightRadius)
            {
                m_NearFood = Food[i].gameObject;
            }
        }       
        

        
    }

    //Cooldown for mating process so that they can't make infinite kids..
    IEnumerator MatingCoolDown(float waitTime)
    {
        m_AiState = AIState.CoolDown;
        yield return new WaitForSeconds(waitTime);
        m_AiState = AIState.Wander;
    }

}

    
    
