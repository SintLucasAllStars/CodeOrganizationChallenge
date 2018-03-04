using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMaze 
	{


	public int preset;
	public float playerLocX;
	public float playerLocY;

		public ClassMaze()
		{
			int spawnLocation = Random.Range (1, 5); 
			preset = Random.Range (1, 6);
		if (spawnLocation == 1)
			{
				playerLocX = -7.5f;
				playerLocY = 3.8f;
			}
		else if (spawnLocation == 2)
			{
				playerLocX = -7.5f;
				playerLocY = -3.8f;
			}
		else if (spawnLocation == 3)
			{
				playerLocX = 7.5f;
				playerLocY = -3.8f;
			}
		else if (spawnLocation == 4)
			{
				playerLocX = 7.5f;
				playerLocY = 3.8f;
			}

		}
}