using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassEscapeRoom 
{

	public float keyPosX;
	public float keyPosY;
	public bool haveKey;

	public ClassEscapeRoom()
	{
		
		keyPosX = Random.Range (-7, 8);
		keyPosY = Random.Range (-3, 4);
		haveKey = false;

	}

}
