using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Porcoo : Creature
{
    void Start()
    {
        dna = new DNA(20, 10, 50, 100, "Porcoo", Random.Range(4, 5));
        type = Type.Carnivore;      //Porcoo eats meat, which means he eats other creatures.
        dna.attackSpeed = 8f;       //Porcoo's attackspeed is neutral
        transform.localScale = new Vector3(dna.size, dna.size, dna.size);
        hostility = Hostility.Neutral;

        collider.center = new Vector3(0, 0.54f, 0);

        agent.speed = dna.speed;

    }
}