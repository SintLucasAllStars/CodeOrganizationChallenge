using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Porcoo : Creature
{
    void Start()
    {
        dna = new DNA(20, 25, 50, 250, "Porcoo", Random.Range(4, 5));
        type = Type.Carnivore;      //Porcoo eats meat, which means he eats other creatures.
        transform.localScale = new Vector3(dna.size, dna.size, dna.size);
        hostility = Hostility.Neutral;

        coll.center = new Vector3(0, 0.54f, 0);

        agent.speed = dna.speed;

    }
}