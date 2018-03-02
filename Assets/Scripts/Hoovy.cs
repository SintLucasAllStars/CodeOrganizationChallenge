using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hoovy : Creature
{
    void Start()
    {
        dna = new DNA(50, 20, 20, 100, "Hoovy", 0.1f);
        type = Type.Omnivorous;      //Heavy eats meat and fruits.
        transform.localScale = new Vector3(dna.size, dna.size, dna.size);
        hostility = Hostility.Friendly;

        agent.speed = dna.speed;

        coll.size = new Vector3(37.45f, 101.74f, 48.11f);
        coll.center = new Vector3(0, 37.38f, 0);
    }
}