using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseCreature : MonoBehaviour
{
    //AI
    NavMeshAgent navAgent;
    public Genes myGenes;
    public DNA myDNA = new DNA();
    public GameObject Mesh;
    

    // Start is called before the first frame update
    void Start()
    {

       navAgent = GetComponent<NavMeshAgent>();
       myDNA.genes = myGenes;
        myDNA.genes.skinColor = Random.ColorHSV();

        
        Mesh.GetComponent<MeshRenderer>().material.color = myDNA.genes.skinColor;

    }

    // Update is called once per frame
    void Update()
    {
        Wander(15);
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

    void SetGenes()
    {
       
    }

   //Check if creature or food is nearby
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Creature"))
        {
            var otherCreature = other.GetComponent<BaseCreature>();
           
            

        }
        else if (other.gameObject.CompareTag("Food"))
        {
          
        }
    }
}

    
    
