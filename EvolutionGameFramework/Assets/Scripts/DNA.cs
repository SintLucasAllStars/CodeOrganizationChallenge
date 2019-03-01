using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DNA
{
	public Genes m_Genes;

	private readonly float m_Rand;
	private readonly Mesh[] m_Shapes = GameObject.Find("Meshes").GetComponent<Test>().Shapes;

	public DNA()
	{
		m_Genes.EatingHabit = ((Genes.EeatingHabit)Random.Range(0, 3));
		m_Genes.Agression = (Random.Range(1f, 10f));
		m_Genes.Gender = ((Genes.Egender)Random.Range(0, 2));
		m_Genes.Strength = (Random.Range(1f, 10f));
		m_Genes.Speed = (Random.Range(1f, 10f));
		m_Genes.Shape = (m_Shapes[(Random.Range(0, 4))]);
	}

	public DNA(Genes _DadGenes, Genes _MomGenes)
	{
		//schrijf overal megelijk heden voor een mutatie en combienaties van ouders
		m_Rand = Random.Range(0f, 10f);
		if(m_Rand >= 5.5f)
		{
			m_Genes.EatingHabit = _DadGenes.EatingHabit;
		}
		else if(m_Rand < 5.5f && m_Rand > 1f)
		{
			m_Genes.EatingHabit = _MomGenes.EatingHabit;
		}
		else
		{
			m_Genes.EatingHabit = ((Genes.EeatingHabit)Random.Range(0, 3));
		}

		// Agression
		m_Rand = Random.Range(0f, 10f);
		if(m_Rand >= 5.5f)
		{
			m_Genes.Agression = _DadGenes.Agression;
		}
		else if(m_Rand < 5.5f && m_Rand > 1f)
		{
			m_Genes.Agression = _MomGenes.Agression;
		}
		else
		{
			m_Genes.Agression = (Random.Range(1f, 10f));
		}

		// Gender
		m_Rand = Random.Range(0f, 10f);
		if (m_Rand >= 5.5f)
		{
			m_Genes.Gender = _DadGenes.Gender;
		}
		else if (m_Rand < 5.5f && m_Rand > 1f)
		{
			m_Genes.Gender = _MomGenes.Gender;
		}
		else
		{
			m_Genes.Gender = ((Genes.Egender)Random.Range(0, 2));
		}

		// Strength
		m_Rand = Random.Range(0f, 10f);
		if (m_Rand >= 5.5f)
		{
			m_Genes.Strength = _DadGenes.Strength;
		}
		else if (m_Rand < 5.5f && m_Rand > 1f)
		{
			m_Genes.Strength = _MomGenes.Strength;
		}
		else
		{
			m_Genes.Strength = (Random.Range(1f, 10f));
		}

		// Speed
		m_Rand = Random.Range(0f, 10f);
		if (m_Rand >= 5.5f)
		{
			m_Genes.Speed = _DadGenes.Speed;
		}
		else if (m_Rand < 5.5f && m_Rand > 1f)
		{
			m_Genes.Speed = _MomGenes.Speed;
		}
		else
		{
			m_Genes.Speed = (Random.Range(1f, 10f));
		}

		// Shape
		m_Rand = Random.Range(0f, 10f);
		if (m_Rand >= 5.5f)
		{
			m_Genes.Shape = _DadGenes.Shape;
}
		else if (m_Rand < 5.5f && m_Rand > 1f)
		{
			m_Genes.Shape = _MomGenes.Shape;
		}
		else
		{
			m_Genes.Shape = (m_Shapes[(Random.Range(0, 4))]);
		}
	}
}