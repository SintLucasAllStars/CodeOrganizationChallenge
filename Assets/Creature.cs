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

    private void Awake()
    {
        gameObject.AddComponent<Animator>();
        anim = GetComponent<Animator>();

        body = gameObject.AddComponent<Rigidbody>();
        collider = gameObject.AddComponent<BoxCollider>();
        agent = gameObject.AddComponent<NavMeshAgent>();


    }

    void Interact()
    {

    }

    private void Update()
    {
        if (agent.remainingDistance < 0.5)
        {
            float x = Random.Range(13, 400);
            float z = Random.Range(0, 400);
            randomPos = new Vector3(x, transform.position.y, z);
        }
        agent.SetDestination(randomPos);




    }

}
