using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature 
{
	public Vector2 position;
	public int age;
	public GameObject go;

	DNA dna;	
	float hunger;

	

	public Creature(GameObject g, float x, float y)
	{
		//Random DNA
		go = GameObject.Instantiate(g);
		SetPosition(new Vector2(x, y));
		dna = new DNA();
		go.GetComponent<SpriteRenderer>().color = dna.randomColor;
		go.GetComponent<Transform>().localScale = go.GetComponent<Transform>().localScale * dna.size;
		age = 0;
	}

	public Creature(GameObject g, float x, float y, Creature parent1, Creature parent2)
	{
		//DNA constructor with mother and father DNA 
		go = GameObject.Instantiate(g);
		SetPosition(new Vector2(x, y));
		dna = new DNA(parent1.dna, parent2.dna);
		go.GetComponent<SpriteRenderer>().color = dna.randomColor;
		go.GetComponent<Transform>().localScale = go.GetComponent<Transform>().localScale * dna.size;
		age = 0;
	}

	void SetPosition(Vector2 p)
	{
		position = p;
		go.transform.position = p;
	}

	void Move(Vector2 movement)
	{
		SetPosition(position + movement);
	}

    public void Step()
	{
		Vector2 movement = new Vector2(Random.Range(0.05f, -0.05f), Random.Range(0.05f, -0.05f)) * dna.speed;
		Move(movement);
	}		
}
