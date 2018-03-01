using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hoovy : Creature
{
    void Start()
    {
        type = Type.omnivorous;      //Heavy eats meat and fruits.
        speed = 50;     //Heavy's speed is neutral
        attackSpeed = 1f;       //Heavy's attackspeed is neutral
        size = 0.1f;
        transform.localScale = new Vector3(size, size, size);
        intelligence = 20;      //Heavys are not that smart
        strength = 40;      //Heavy's attacks do 40 damage
        hostility = Hostility.Hostile;
        species = "Hoovy";
        health = 100;

        agent.speed = speed;
    }
}