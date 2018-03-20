using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle {

	public string question;
	public string answer;

	public Puzzle(string question, string answer)
	{
		this.question = question;
		this.answer = answer;
	}
}