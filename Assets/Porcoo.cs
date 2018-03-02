using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Porcoo : Creature
{
    void Start()
    {
        dna = new DNA(20, 10, 50, 100);
        type = Type.Carnivore;      //Porcoo eats meat, which means he eats other creatures.
        dna.speed = 20;     //Porcoo's speed is neutral
        dna.attackSpeed = 8f;       //Porcoo's attackspeed is neutral
        dna.size = Random.Range(4, 5);      //Porcoo's can either be alfa Porcoos or normal Porcoos
        transform.localScale = new Vector3(dna.size, dna.size, dna.size);
        dna.intelligence = 50;      //Porcoos are not that smart
        dna.strength = 0;      //Porcoo's attacks do 40 damage
        hostility = Hostility.Neutral;
        dna.species = "Porcoo";
        dna.health = 100;

        collider.center = new Vector3(0, 0.54f, 0);

        agent.speed = dna.speed;

    }
}