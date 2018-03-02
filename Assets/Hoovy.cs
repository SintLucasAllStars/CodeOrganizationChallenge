using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hoovy : Creature
{
    void Start()
    {
        dna = new DNA(50, 40, 20, 100);
        type = Type.Omnivorous;      //Heavy eats meat and fruits.
        dna.speed = 50;     //Heavy's speed is neutral
        dna.attackSpeed = 1f;       //Heavy's attackspeed is neutral
        dna.size = 0.1f;
        transform.localScale = new Vector3(dna.size, dna.size, dna.size);
        dna.intelligence = 20;      //Heavys are not that smart
        dna.strength = 40;      //Heavy's attacks do 40 damage
        hostility = Hostility.Friendly;
        dna.species = "Hoovy";
        dna.health = 100;

        agent.speed = dna.speed;
    }
}