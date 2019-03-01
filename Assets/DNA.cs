using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{
	float colorR = Random.value, colorG = Random.value, colorB = Random.value, colorA = 255f;
	float curiosity, aggression, hungerSpeed;

	public float size, speed;		
	public Color randomColor;

	public DNA()
	{
		//Random DNA
		randomColor = new Color(colorR, colorG, colorB, colorA);
		size = Random.Range(1f, 4f);
		speed = Random.Range(1f, 3f);
		curiosity = Random.Range(1f, 10f);
		aggression = Random.Range(1f, 10f);
		hungerSpeed = Random.Range(1f, 5f); 
	}

	public DNA(DNA father, DNA mother)
	{
		//Randomly chooses values from mother and father.
		randomColor = mateColor(father.randomColor, mother.randomColor);
		size = mateValue(father.size, mother.size);
		speed = mateValue(father.size, mother.size);
		curiosity = mateValue(father.size, mother.size);
		aggression = mateValue(father.aggression, mother.aggression);
		hungerSpeed = mateValue(father.hungerSpeed, mother.hungerSpeed);
		
	}

	public DNA(DNA father, DNA mother, float mutationProbability)
	{
		//Same as the one before but randomly changes some values.
		randomColor = mateColor(father.randomColor, mother.randomColor);
		size = mateValue(father.size, mother.size);
		speed = mateValue(father.size, mother.size);
		curiosity = mateValue(father.size, mother.size);
		aggression = mateValue(father.aggression, mother.aggression);
		hungerSpeed = mateValue(father.hungerSpeed, mother.hungerSpeed);
	}

	Color mateColor(Color val1, Color val2)
	{
		float r = Random.value;

		if (r > 0.5)
		{
			return val1;
		}
		else
		{
			return val2;
		}
	}
	

	float mateValue(float val1, float val2)
	{
		float r = Random.value;

		if(r > 0.5)
		{
			return val1;
		}
		else
		{
			return val2;
		}
	}
}
