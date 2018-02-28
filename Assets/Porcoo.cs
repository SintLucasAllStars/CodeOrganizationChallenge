using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Porcoo : Creature
{
    void Start()
    {
        type = Type.carnivore;      //Porcoo eats meat, which means he eats other creatures.
        speed = 50;     //Porcoo's speed is neutral
        attackSpeed = 60;       //Porcoo's attackspeed is neutral
        size = Random.Range(4, 5);      //Porcoo's can either be alfa Porcoos or normal Porcoos
        transform.localScale = new Vector3(size, size, size);      
        intelligence = 20;      //Porcoos are not that smart
        strength = 40;      //Porcoo's attacks do 40 damage
        hostility = Hostility.Neutral;
        species = "Porcoo";

        collider.center = new Vector3(0, 0.54f, 0);

        agent.speed = speed;

    }
}