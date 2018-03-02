using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DNA {

    public float speed;     //The speed of the creature.
    public float strength;      //The combat strength of the creature.
    public float intelligence;      //The intelligence of the creature.
    public float health;        //The health points the creature has.

    public float size;      //The size of the creature.
    public int age;

    public string species;      //The name of the species the creature represents.

    //Constructor for the DNA that lets me choose whatever values I want.
    public DNA(float speed, float strength, float intelligence, float health, string species, float size, int age)
    {
        this.speed = speed;
        this.strength = strength;
        this.intelligence = intelligence;
        this.health = health;
        this.species = species;
        this.size = size;
        this.age = age;
    }

    //Overload constructor that let's me choose an entire DNA.
    public DNA(DNA dna)
    {
        this.speed = dna.speed;
        this.strength = dna.strength;
        this.intelligence = dna.intelligence;
        this.health = dna.health;
        this.species = dna.species;
        this.size = dna.size;
        this.age = dna.age;
    }

    //Just a function that lets me combine two DNAs with each other and returns a DNA. Did this with Bas together, so our methods are quite similar.
    public DNA MergeStats(DNA otherDna)
    {
        float finalSpeed, finalStrength, finalIntelligence, finalHealth, finalSize;
        string finalSpecies;
        int finalAge;
        /*
        ######################
        Speed
        ######################
        */
        if (speed < otherDna.speed)
        {
            finalSpeed = Random.Range(speed, otherDna.speed + speed);
        }
        else
        {
            finalSpeed = Random.Range(otherDna.speed, speed + otherDna.speed);
        }
        /*
        ######################
        Strength
        ######################
        */
        if (strength < otherDna.strength)
        {
            finalStrength = Random.Range(strength, otherDna.strength + strength);
        }
        else
        {
            finalStrength = Random.Range(otherDna.strength, strength + otherDna.strength);
        }
        /*
        ######################
        Intelligence
        ######################
        */
        if (intelligence < otherDna.intelligence)
        {
            finalIntelligence = Random.Range(intelligence, otherDna.intelligence + intelligence);
        }
        else
        {
            finalIntelligence = Random.Range(otherDna.intelligence, intelligence + otherDna.intelligence);
        }
        /*
        ######################
        Health
        ######################
        */
        if (health < otherDna.health)
        {
            finalHealth = Random.Range(health, otherDna.health + health);
        }
        else
        {
            finalHealth = Random.Range(otherDna.health, health + otherDna.health);
        }
        /*
        ######################
        Species
        ######################
        */
        finalSpecies = species;
        /*
        ######################
        Size
        ######################
        */
        if (size < otherDna.size)
        {
            finalSize = Random.Range(size, otherDna.size + size);
        }
        else
        {
            finalSize = Random.Range(otherDna.size, size + otherDna.size);
        }
        /*
        ######################
        Size
        ######################
        */
        finalAge = 1;
        return new DNA(finalSpeed, finalStrength, finalIntelligence, finalHealth, finalSpecies, finalSize, finalAge);
    }

}
