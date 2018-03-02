using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature : MonoBehaviour
{
    public enum Type                                                            //The type of food the creature likes. It will still attack other creatures if it is hostile, but depending on this, it might eat or not eat it.
    {
        Omnivorous,
        Herbivorous,
        Carnivore
    };
    public enum Hostility                                                       //The feeling the creature has. They can either be friendly, neutral or hostile. This enum decides if a creature attacks, mates, or is able to do both.
    {
        Friendly,
        Neutral,
        Hostile
    };
    public enum State                                                           //This is just a state enum that explains what the creature is currently doing. After an attack from other creatures it will go to hit mode.
    {
        Walking,
        Mating,
        Hunting,
        Fighting,
        Hit
    };                                                                          //shit - Maud, 2018

    public Rigidbody body;                                                      //The rigidbody for the creature.
    public BoxCollider coll;                                                    //The collider for the creature, might want to add a second collider for the triggers etc.
    Animator anim;                                                              //An animator in case someone wants to animate creatures.
    public NavMeshAgent agent;                                                  //A navmesh agent so that the creature walks around and avoids obstacles. Of course this is the easiest way to let an agent chase another agent too.
    
    public DNA dna;                                                             //The DNA the creature has. This DNA will get values in other scripts such as Hoovy and Porcoo.
        
    public Type type;
    public Hostility hostility;
    public State state;

    public Vector3 randomPos;                                                   //Just a vector3 that stores the random position the creature is walking to if it is in walking mode.
    public bool canGetHit = true;

    public GameObject other;                                                    //The other creature this creature is either fighting or mating with.
    public bool hasBaby;

    public int hunger;
    public bool isHungry;

    private void Awake()
    {
        gameObject.AddComponent<Animator>();        
        anim = GetComponent<Animator>();

        body = gameObject.AddComponent<Rigidbody>();
        coll = gameObject.AddComponent<BoxCollider>();
        agent = gameObject.AddComponent<NavMeshAgent>();

        gameObject.tag = "Character";

        agent.acceleration = 20;

        StartCoroutine(HungerUp());
    }

    IEnumerator HungerUp()
    {
        hunger++;
        yield return new WaitForSeconds(1);
        StartCoroutine(HungerUp());
    }

    /*
    ######################
    A function that checks which hostility the creature has. Neutral will take a random direction and either chooses to mate or attack.
    ######################
    */
    void Interact(GameObject monster)
    {
        switch (hostility)
        {
            case Hostility.Friendly:                                            //If the creature is friendly it will start mating with the other creature.
                if (monster.GetComponent<Creature>().dna.species == dna.species)
                {
                    int ra = Random.Range(0, 2);
                    switch(ra)
                    {
                        case 0:
                            state = State.Walking;
                            other = null;
                            break;
                        case 1:
                            state = State.Mating;
                            break;
                    }

                }
                
                break;
            case Hostility.Neutral:                                             //If the creature is neutral it will take a random path.
                int random = Random.Range(0, 3);
                switch (random)
                {
                    case 0:
                        if (monster.GetComponent<Creature>().dna.species == dna.species)
                        {
                            state = State.Mating;
                        }

                        break;
                    case 1:
                        if (monster.name != dna.species)
                        {
                            state = State.Fighting;
                        }

                        break;
                    case 2:
                        state = State.Walking;
                        other = null;
                        break;
                }
                break;
            case Hostility.Hostile:                                             //Hostile creatures will always attack and don't feel the need to mate because they are hostile and cannot feel love.
                int r = Random.Range(0, 2);
                switch(r)
                {
                    case 0:
                        state = State.Fighting;
                        break;
                    case 1:
                        state = State.Walking;
                        other = null;
                        break;
                }


                break;
        }
    }

    void Attack(GameObject other)
    {
        state = State.Fighting;
        Creature monsterCreature = other.GetComponent<Creature>();
        if(monsterCreature.canGetHit)
        {
            monsterCreature.dna.health -= dna.strength;                         
        }
        Debug.Log(this.gameObject.name + " and " + other.gameObject.name + " started fighting.");
    }

    void Mate(GameObject other)                                                 //If the other creature is hostile, the creatures won't be able to mate so it will return to just walking around;
    {
        if (other.GetComponent<Creature>().hostility != Hostility.Hostile)      //We first want to check if the other creature is not hostile.
        {   
            if (other.GetComponent<Creature>().hostility == Hostility.Friendly)     //If a creature is friendly it will always want to mate with a creature of the same species.
            {
                StartCoroutine(BreedBaby());                                                                    //The creature can't breed for a few seconds.
                GameObject Baby = new GameObject(dna.species);     //The name will be a merge of the species.
                Baby.AddComponent<Creature>();                                                                  //Adding the creature component to the new baby.
                Baby.GetComponent<Creature>().dna = new DNA(dna.MergeStats(other.GetComponent<Creature>().dna));        //Merging stats from the other creature.
                if (Resources.Load<GameObject>(dna.species) != null)                                                    //In case there is a model in the resources folder, it will load it and instantiate as child.                                   
                {
                    Instantiate(Resources.Load<GameObject>(dna.species), Baby.transform.position, Baby.transform.rotation, Baby.transform);
                }
                Debug.Log(this.gameObject.name + " and " + other.gameObject.name + " made a baby named " + Baby.gameObject.name + ".");
            }
            if (other.GetComponent<Creature>().hostility == Hostility.Neutral)
            {
                int random = Random.Range(0, 2);
                switch(random)
                {
                    case 0:
                        StartCoroutine(BreedBaby());                                                                            //The neutral creature refuses, but the creature still cannot reproduce for a few seconds.
                        Debug.Log(this.gameObject.name + " tried to make a baby but " + other.gameObject.name + " refused.");   //Neutral creatures can also refuse mating.
                        break;
                    case 1:
                        StartCoroutine(BreedBaby());                                                                            //The creature can't breed for a few seconds.
                        GameObject Baby = new GameObject(dna.species);             //The name will be a merge of the species.
                        Baby.AddComponent<Creature>();                                                                          //Adding the creature component to the new baby.
                        Baby.GetComponent<Creature>().dna = new DNA(dna.MergeStats(other.GetComponent<Creature>().dna));        //Merging stats from the other creature.
                        if (Resources.Load<GameObject>(Baby.gameObject.name) != null)                                           //In case there is a model in the resources folder, it will load it and instantiate as child.                                   
                        {
                            Instantiate(Resources.Load<GameObject>(Baby.gameObject.name), Baby.transform.position, Baby.transform.rotation, Baby.transform);
                        }
                        Debug.Log(this.gameObject.name + " and " + other.gameObject.name + " made a baby named " + Baby.gameObject.name + ".");
                        break;
                }
            }
        }
        else
        {
            state = State.Walking;                  //If the other creature is hostile, the creature will not initiate a mating request and just continue walking around.                                
        }
    }

    private void Update()
    {
        if(hunger > 50)
        {
            isHungry = true;
            state = State.Hunting;
        }
        if (other == null && !isHungry)
        {
            state = State.Walking;
        }
        if (hunger > 100)
        {
            Destroy(this.gameObject);
        }
        if(dna.health < 1)
        {
            Destroy(this.gameObject);               //Destroy the creature if the health gets under 0.
            Debug.Log(gameObject.name + " got killed.");
        }
        switch(state)
        {
            case State.Fighting:        //If the creature is fighting it will naturally follow the opponent.
                if (other != null)
                {
                    agent.SetDestination(other.transform.position);
                }

                break;
            case State.Mating:      //If the creature is mating it will still follow the creature but without harmful intentions.
                if (other != null)
                {
                    agent.SetDestination(other.transform.position);
                }

                break;
            case State.Hunting:      //If the creature is hunting for fewd.
                if (other != null)
                {
                    agent.SetDestination(other.transform.position);
                }

                break;
            case State.Walking:     //If the creature is walking around it will take random positions on the map.
                if (agent.remainingDistance < 1)
                {
                    float x = Random.Range(13, 400);
                    float z = Random.Range(0, 400);
                    randomPos = new Vector3(x, transform.position.y, z);
                }
                agent.SetDestination(randomPos);

                break;
        }

        /*
        ######################
        When the creature sees another creature it changes behaviour accordingly.
        ######################
        */
        Debug.DrawRay(transform.position + new Vector3(0, 2, 0), transform.forward * 100.0f, Color.red);
        RaycastHit hit;
        if (other == null)
        {
            if (Physics.Raycast(transform.position + new Vector3(0, 2, 0), transform.forward, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Character"))
                {
                    if (state == State.Walking)
                    {
                        other = hit.collider.gameObject;
                        Interact(hit.collider.gameObject);
                    }
                }
                if(hit.collider.gameObject.CompareTag("Food"))
                {
                    if(type == Type.Herbivorous || type == Type.Omnivorous && isHungry)
                    {
                        other = hit.collider.gameObject;
                    }
                }
            }
        }
    }

    /*
    ######################
    When the creature touches the other creature it behaves accordingly with either mating or fighting.
    ######################
    */
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Character"))
        {
            if(state == State.Mating && !hasBaby)
            {
                Mate(collision.gameObject);
            }
            if (state == State.Fighting)
            {
                Attack(collision.gameObject);
                collision.gameObject.GetComponent<Creature>().other = this.gameObject;
                collision.gameObject.GetComponent<Creature>().state = State.Fighting;
                hunger = 0;
            }
        }
        if(collision.gameObject.CompareTag("Food"))
        {
            if (isHungry)
            {
                Destroy(other.gameObject);
                hunger = 0;
                other = null;
                state = State.Walking;
            }
        }
    }

    IEnumerator BreedBaby()
    {
        hasBaby = true;
        yield return new WaitForSeconds(8);
        state = State.Walking;
        other = null;
        hasBaby = false;
    }
}
