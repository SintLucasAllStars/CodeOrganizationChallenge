using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature_AI : MonoBehaviour //This scripts contains their behaviour, Reactions and stats
{
    public float hunger = 100;

    public int Attack_Power; //chance taker & damage dealer
    public int Defence_Power; //attack absorber

    public float wanderTimer;

    public GameObject other_creature;
    public GameObject food;
    public GameObject dead_meat;
    public GameObject child;
    public GameObject mom;
    public GameObject dad;

    private NavMeshAgent agent;

    private float timer = 100;
    float cooldown = 60;

    Creature_AI other_ai;
    Species_generator SG;

    public bool wander;
    public bool eat;
    public bool interact;
    public bool cooldown_check;

    void Start()
    {
        wander = true;

        Stat_gen();

        SG = GetComponent<Species_generator>();

        if(this.gameObject.name == "Born_creature(Clone)")
        {
           // mom = getcom
        }
    }
    // Use this for initialization
    void OnEnable()
    {
        timer = wanderTimer;
    }
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        hunger -= Time.deltaTime * 0.5f;

        if(cooldown_check = true)
        {
            cooldown += Time.deltaTime;
        }

        if(wander == true)
        {
            Wandering();
        }

        if(hunger < 1)
        {
            die();
        }
        
    }
    void Wandering()
    {
        if (timer >= wanderTimer)
        {
            agent.Resume();
            agent.stoppingDistance = 5;
            eat = false;
            interact = false;
            Vector3 newPos = new Vector3(Random.value * 500, 0, Random.value * 500);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }
    void Stat_gen()
    {
        agent = this.GetComponent<NavMeshAgent>();
        Attack_Power = Random.Range(1, 11);
        Defence_Power = Random.Range(1, 11);
        agent.speed = Random.Range(3, 12);
        agent.acceleration = Random.Range(8, 21);
        agent.angularSpeed = Random.Range(120, 151);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == food)
        {
            if(collision.gameObject.tag == "Meat" && SG.actual_diet == "Carnivor")
            {
                hunger += 20;
                Destroy(food);
            }
            if (collision.gameObject.tag == "Plant" && SG.actual_diet == "Herbivor")
            {
                hunger += 15;
                Destroy(food);
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(hunger < 70 && other.gameObject.tag == "Meat" && SG.actual_diet == "Carnivor")
        {
            agent.stoppingDistance = 0;
            agent.Stop();
            wander = false;
            eat = true;
            food = other.gameObject;
            agent.SetDestination(food.transform.position);
            agent.Resume();
            if (hunger > 70)
            {
                wander = true;
            }
        }
        if (hunger < 70 && other.gameObject.tag == "Plant" && SG.actual_diet == "Herbivor")
        {
            agent.stoppingDistance = 0;
            agent.Stop();
            wander = false;
            eat = true;
            food = other.gameObject;
            agent.SetDestination(food.transform.position);
            agent.Resume();
            if (hunger > 70)
            {
                wander = true;
            }
        }
        if(other.gameObject.tag == "Creature")
        {

            wander = false;
            eat = false;
            interact = true;
            if (cooldown < 20)
            {
                interact = false;
            }
            other_creature = other.gameObject;
            other_ai = other_creature.GetComponent<Creature_AI>();
            if(interact == true)
            {
                if (Attack_Power > other_ai.Attack_Power)
                {
                    int mate; // 0 = attack, 1 = mate
                    mate = Random.Range(0, 2);
                    Debug.Log(mate);

                    switch (mate)
                    {
                        case 0:
                            fight();
                            break;
                        case 1:
                            Mate();
                            break;
                    }

                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        food = null;
        other_creature = null;
        wander = true;
    }
    void Mate()
    {
        if(SG.female == true && other_ai.SG.female == false || SG.female == false && other_ai.SG.female == true)
        {
            if(SG.female == true)
            {
                Instantiate(child, transform.position, Quaternion.identity);
                this.gameObject.transform.parent = gameObject.transform;
            }
        }

        food = null;
        other_creature = null;
        wander = true;
        other_ai = null;
        interact_cooldown();
    }
    void fight()
    {
        if(other_ai.Attack_Power > Defence_Power)
        {
            die();
        }
        if(Attack_Power == other_ai.Defence_Power)
        {
            die();
        }

        food = null;
        other_creature = null;
        wander = true;
        other_ai = null;
        interact_cooldown();
    }
    void die()
    {
        Instantiate(dead_meat, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    void interact_cooldown()
    {
        cooldown_check = true;
        cooldown = 0;
        wander = true;
       
        if (cooldown < 20)
        {
            interact = false;
        }
        else;
        {
            cooldown_check = false;
        }
    }
}