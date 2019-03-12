using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    Vector3 position;
    DNA dna;
    int age;
    float hunger;

    public int nature;

    GameObject go;

    public Creature(GameObject g, float x, float y, float z)
    {
        go = GameObject.Instantiate(g);
        SetPosition(new Vector3(x, y, z));
        dna = new DNA();

        //Random dna
    }

    public Creature(GameObject g, float x, float y,float z, Creature father, Creature mother)
    {
        //dna constructor with mother and father dna 
        go = GameObject.Instantiate(g);
        SetPosition(new Vector3(x, y, z));
        dna = new DNA(father.dna, mother.dna);
    }

    void SetPosition(Vector3 p)
    {
        position = p;
        go.transform.position = p;
    }

    public void Move(Vector3 movement)
    {
        //SetPosition(position + movement);
        //go.transform.Translate(Vector3.forward * Time.deltaTime);
        float speed = 5f;
        float step = speed * Time.deltaTime;
        go.transform.position = Vector3.MoveTowards(go.transform.position, movement, step);




    }

    //public void Step()
    //{
    //    Vector3 movement = new Vector3(Random.Range(0.2f, -0.2f), 0, Random.Range(0.2f, -0.2f));
    //    Move(movement);
    //}

    public void Mate()
    {

    }

    public void Fight()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        nature = Random.Range(1, 10);

        if (nature % 2 == 0)
        {
            Fight();
            
        }

        if (nature % 2 == 1)
        {
            Mate();
        }



    }

}