﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{


	public Attributes Gene; 

	public DNA(Attributes parentA, Attributes parentB)
	{

		int m_Evolution = Random.Range(1, 100);

		if (m_Evolution >1)
		{
			Gene.m_Strength = 5; 
		}


	}

	public void Breed(Attributes parentA, Attributes parentB)
	{

		int m_Evolution = Random.Range(1, 6);

		if (m_Evolution == 1)
		{
			Gene.m_Strength = Random.Range(1, 100);
			Gene.m_Speed = Random.Range(1, 100);
			Gene.m_Longevity = Random.Range(1, 100);
			Gene.m_Endurance = Random.Range(1, 100);
			Gene.m_Size = Random.Range(1, 100);

		}
		else if (m_Evolution == 2)
		{
			Gene.m_Strength = Random.Range(1, 100);
			Gene.m_Speed = Random.Range(1, 100);
			Gene.m_Longevity = Random.Range(1, 100);
			Gene.m_Endurance = Random.Range(1, 100);
			Gene.m_Size = Random.Range(1, 100);

		}
		else if (m_Evolution == 3)
		{
			Gene = parentB;

		}
		else if (m_Evolution == 4)
		{
			Gene = parentA;

		}
		else if (m_Evolution == 5)
		{
			Gene = parentA;

		}


	}



}

[System.Serializable]
public struct Attributes
{
	public enum Diet
	{
		herbivore, omnivore, carnivore

	};

	public bool isMale;

	public double m_Strength;

	public double m_Speed;

	public double m_Longevity;

	public double m_Endurance;

	public double m_Size;

	public double m_Aggression; 

}
