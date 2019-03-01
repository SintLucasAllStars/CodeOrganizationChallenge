using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Genes
{
	public enum EeatingHabit { Carnivore, Omnivore, Herbivore };
	public EeatingHabit EatingHabit;
	
	[Range(1, 10)]
	public float Agression;

	public enum Egender { Male, Female };
	public Egender Gender;

	[Range(1, 10)]
	public float Strength;

	[Range(1, 10)]
	public float Speed;

	public Mesh Shape;
}