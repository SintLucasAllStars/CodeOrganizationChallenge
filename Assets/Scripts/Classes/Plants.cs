﻿///made by ertugrul yesil
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants{

	public int type;

	public float GrowthSpeed;
	public float LifeSpan;
	public bool Eatable;
	
	public Plants()
	{
		type = Random.Range(0,3);

		switch (type)
		{
			case 0://normal tree
				GrowthSpeed = Random.Range(6,10);
				LifeSpan = Random.Range(2,5);
				Eatable = false;
			break;

			case 1://bush
				GrowthSpeed = Random.Range(2,5);
				LifeSpan = Random.Range(8,10);
				Eatable = true;
			break;

			case 2://een rots
				GrowthSpeed = Random.Range(3,7);
				LifeSpan = Random.Range(3,7);
				Eatable = false;
			break;

			default:
				Debug.Log("MOM GET THE CAMERA I FACKED UP");
			break;
		}
	}		
}

