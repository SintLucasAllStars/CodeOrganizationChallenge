using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Brains : MonoBehaviour {

    List<Puzzle> puzzles;

    int currentpuzzle = -1;

    public InputField answerField;
    public Text feedback;
    public Text questionText;

    bool correct;

    // Use this for initialization
    void Start ()
    {
        correct = false;
        puzzles = new List<Puzzle>();
        CreatePuzzle();

        nextPuzzle();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (answerField.text == puzzles[currentpuzzle].answer)
        {
            feedback.text = "Good job!";
            nextPuzzle();
        }
    }

    public void nextPuzzle()
    {
        currentpuzzle++;
        if(currentpuzzle < puzzles.Count)
        {
            questionText.text = puzzles[currentpuzzle].question;
            answerField.text = "";
        }
    }

    public void CreatePuzzle()
    {
        puzzles.Add(new Puzzle("What is 5 x 5?", "25"));
        puzzles.Add(new Puzzle("What is 6 + 1?", "7"));
        puzzles.Add(new Puzzle("What is 5 - 4?", "1"));
    }

    public void NextQuestion()
    {
        if (correct == true)
        {
            SceneManager.LoadScene("Question_2");
        }
    }
}
