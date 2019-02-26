using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{

	[System.Serializable]
	public struct Attributes
	{
		public enum food
		{
			herbivore, omnivore, carnivore
		};


		public double m_Strength;

		public double m_Speed;

		public double m_Longevity;

		public double m_Endurance;

		public double m_Size;



	}

	Attributes Gene;

	public DNA(Attributes parentA, Attributes parentB)
	{

		int m_Evolution = Random.Range(1, 100);

		if (m_Evolution >1)
		{
			Gene.m_Strength = 5; 
		}


	}



}
