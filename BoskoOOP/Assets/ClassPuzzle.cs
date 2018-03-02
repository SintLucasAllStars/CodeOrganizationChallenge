using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPuzzle 
{
	public bool isCompleted;
	public string[] puzzleType = new string[] {"Maze", "EscapeRoom", "WordSearch", "MainScene"};
	public string currentPuzzle;
	public int totalPuzzleRooms;

	public ClassPuzzle ()
	{
		
		isCompleted = false;
		currentPuzzle = puzzleType[Random.Range(0, puzzleType.Length - 1)];

	}

	public ClassPuzzle (string wantedPuzzle)
	{
		isCompleted = false;
		currentPuzzle = wantedPuzzle;
		if (wantedPuzzle == "MainScene") 
		{
			isCompleted = true;
			totalPuzzleRooms = Random.Range (1, 5);
		}
	}
}
