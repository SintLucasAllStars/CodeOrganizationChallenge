using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class BaseCreature : MonoBehaviour
{
    //AI
    NavMeshAgent navAgent;
    public DNA Genes = new DNA();
    public GenderType gender;
    public FoodType foodType;
    public GameObject Mesh;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

     

        Genes.Gender = gender;
        Genes.foodType = foodType;

        Genes.skinColor = Random.ColorHSV();
        Mesh.GetComponent<MeshRenderer>().material.color = Genes.skinColor;

    }

    // Update is called once per frame
    void Update()
    {
        Wander(15);         
    }

    void Wander(float maxDistance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * maxDistance;
        NavMeshHit hit;

        if (navAgent)
        {
            if(transform.position == navAgent.destination)
            {
                randomDirection += transform.position;
                NavMesh.SamplePosition(randomDirection, out hit, maxDistance, 1);
                navAgent.destination = hit.position;

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }
}
