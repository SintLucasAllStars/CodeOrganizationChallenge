using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creature<T> where T : Creature
{
    public GameObject gameObject;
    public T ScriptComponent;

    public Creature(string name)
    {
        gameObject = new GameObject(name);
        ScriptComponent = gameObject.AddComponent<T>();
    }

    public T GetEnemyType()
    {
        return ScriptComponent;
    }
}

public abstract class Creature : MonoBehaviour
{
    public Rigidbody body;
    public BoxCollider collider;
    Animator anim;

    public float speed;     //The speed of the creature.
    public float attackSpeed;       //The attack speed of the creature
    public float size;      //The size of the creature
    public float intelligence;      //The intelligence of the creature
    public float strength;      //The combat strength of the creature
    public float health;        //The health points the creature has

    public string species;      //The name of the species the creature represents
    public enum Type
    {
        omnivorous,
        herbivorous,
        carnivore
    }
    public enum Hostility
    {
        Friendly,
        Neutral,
        Hostile
    }
    public Type type;
    public Hostility hostility;
    public NavMeshAgent agent;

    public Vector3 randomPos;

    public enum State
    {
        walking,
        mating,
        fighting,
        hit
    }
    public State state;

    public GameObject enemy;

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

    void Interact(GameObject monster)
    {
        switch (hostility)
        {
            case Hostility.Friendly:
                state = State.mating;
                Mate(monster);
                
                break;
            case Hostility.Neutral:
                int random = Random.Range(0, 2);
                switch (random)
                {
                    case 0:
                        state = State.mating;
                        Mate(monster);

                        break;
                    case 1:
                        state = State.fighting;
                        Attack(monster);

                        break;
                }
                break;
            case Hostility.Hostile:
                state = State.fighting;
                Attack(monster);

                break;
            default:

                break;
        }
    }

    void Attack(GameObject monster)
    {
        state = State.fighting;
        Creature monsterCreature = monster.GetComponent<Creature>();
        enemy = monster;

    }

    void Mate(GameObject monster)
    {
        monster.GetComponent<Creature>().state = State.mating;
    }

    private void Update()
    {
        if(enemy == null)
        {
            state = State.walking;
        }

        if(health < 1)
        {
            Destroy(this.gameObject);
        }

        if (state == State.walking)
        {
            if (agent.remainingDistance < 0.5)
            {
                float x = Random.Range(13, 400);
                float z = Random.Range(0, 400);
                randomPos = new Vector3(x, transform.position.y, z);
            }
            agent.SetDestination(randomPos);

        }
        if (state == State.fighting)
        {
            agent.SetDestination(enemy.transform.position);

        }

        Debug.DrawRay(transform.position + new Vector3(0, 2, 0), transform.forward * 100.0f, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(transform.position + new Vector3(0, 2, 0), transform.forward, out hit, 1000))
        {
            if (hit.collider.gameObject.CompareTag("Character"))
            {

                if(state == State.walking)
                {
                    state = State.fighting;
                    enemy = hit.collider.gameObject;
                    Debug.Log("Hit: " + hit.collider.gameObject.name);
                }
            }

        }

    }

    IEnumerator GetHit()
    {
        state = State.hit;
        yield return new WaitForSeconds(2);
        state = State.walking;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Character")
        {
            if(state == State.fighting)
            {
                Instantiate(Resources.Load<GameObject>("Blood"), enemy.transform.position, enemy.transform.rotation);
                enemy.GetComponent<Creature>().health = enemy.GetComponent<Creature>().health - strength;
                enemy.GetComponent<Creature>().StartCoroutine(GetHit());
                Debug.Log(collision.gameObject.name + " got hit and has " + enemy.GetComponent<Creature>().health + " health left and his state is " + enemy.GetComponent<Creature>().state);
                Debug.Log("heavy's state is " + state);
            }
        }
    }
}
