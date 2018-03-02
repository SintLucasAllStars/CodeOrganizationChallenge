﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature : MonoBehaviour
{
    public enum Type        //The type of food the creature likes. It will still attack other creatures if it is hostile, but depending on this, it might eat or not eat it.
    {
        Omnivorous,
        Herbivorous,
        Carnivore
    }
    public enum Hostility       //The feeling the creature has. They can either be friendly, neutral or hostile. This enum decides if a creature attacks, mates, or is able to do both.
    {
        Friendly,
        Neutral,
        Hostile
    }
    public enum State       //This is just a state enum that explains what the creature is currently doing. After an attack from other creatures it will go to hit mode.
    {
        Walking,
        Mating,
        Fighting,
        Hit
    }

    public Rigidbody body;      //The rigidbody for the creature.
    public BoxCollider collider;        //The collider for the creature, might want to add a second collider for the triggers etc.
    Animator anim;      //An animator in case someone wants to animate creatures.
    public NavMeshAgent agent;      //A navmesh agent so that the creature walks around and avoids obstacles. Of course this is the easiest way to let an agent chase another agent too.
    
    public DNA dna;     //The DNA the creature has. This DNA will get values in other scripts such as Hoovy and Porcoo.
        
    public Type type;
    public Hostility hostility;
    public State state;

    public Vector3 randomPos;       //Just a vector3 that stores the random position the creature is walking to if it is in walking mode.

    private void Awake()
    {
        gameObject.AddComponent<Animator>();
        anim = GetComponent<Animator>();

        body = gameObject.AddComponent<Rigidbody>();
        collider = gameObject.AddComponent<BoxCollider>();
        agent = gameObject.AddComponent<NavMeshAgent>();

        gameObject.tag = "Character";

        agent.acceleration = 20;
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
            case Hostility.Friendly:
                state = State.Mating;
                Mate(monster);
                
                break;
            case Hostility.Neutral:
                int random = Random.Range(0, 2);
                switch (random)
                {
                    case 0:
                        state = State.Mating;
                        Mate(monster);

                        break;
                    case 1:
                        state = State.Fighting;
                        Attack(monster);

                        break;
                }
                break;
            case Hostility.Hostile:
                state = State.Fighting;
                Attack(monster);

                break;
        }
    }

    void Attack(GameObject monster)
    {
        state = State.Fighting;
        Creature monsterCreature = monster.GetComponent<Creature>();
    }

    void Mate(GameObject monster)
    {
        if (monster.GetComponent<Creature>().hostility != Hostility.Hostile)
        {
            monster.GetComponent<Creature>().state = State.Mating;
            GameObject Baby = new GameObject("Baby");
            Baby.AddComponent<Creature>();
            Baby.GetComponent<Creature>().dna = new DNA(dna.MergeStats(monster.GetComponent<Creature>().dna));

        }
    }

    private void Update()
    {
        if (state == State.Walking)
        {
            if (agent.remainingDistance < 0.5)
            {
                float x = Random.Range(13, 400);
                float z = Random.Range(0, 400);
                randomPos = new Vector3(x, transform.position.y, z);
            }
            agent.SetDestination(randomPos);

        }

        Debug.DrawRay(transform.position + new Vector3(0, 2, 0), transform.forward * 100.0f, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, 2, 0), transform.forward, out hit, 1000))
        {
            if (hit.collider.gameObject.CompareTag("Character"))
            {

                if(state == State.Walking)
                {
                    Interact(hit.collider.gameObject);
                    Debug.Log(gameObject.name + " has seen " + hit.collider.gameObject.name);
                }
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Character"))
        {
            Interact(collision.gameObject);

        }
    }
}
