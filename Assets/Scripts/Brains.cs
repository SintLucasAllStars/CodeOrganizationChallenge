using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Brains : MonoBehaviour {

    List<Puzzle> puzzles;
    List<Room> rooms;

    int currentpuzzle = -1;
    int currentroom = 1;

    public InputField answerField;
    public Text feedback;
    public Text questionText;

    bool correct;

    // Use this for initialization
    void Start ()
    {
        puzzles = new List<Puzzle>();
        rooms = new List<Room>();
        CreatePuzzle();
        CreateRooms();
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
        else
        {
            SceneManager.LoadScene("Main");
            nextRoom();
        }
    }

    public void nextRoom()
    {
        currentroom++;
        if(currentroom < rooms.Count)
        {
            //SceneManager.LoadScene("Room2");
            SceneManager.LoadScene(rooms[currentroom].name);
            currentpuzzle = -1;
        }
    }

    public void CreatePuzzle()
    {
        if (currentroom == 1)
        {
            puzzles.Add(new Puzzle("What is 5 x 5?", "25"));
            puzzles.Add(new Puzzle("What is 6 + 1?", "7"));
            puzzles.Add(new Puzzle("What is 5 - 4?", "1"));
        }

        if (currentroom == 2)
        {
            puzzles.Add(new Puzzle("What is 2 + 10?", "12"));
            puzzles.Add(new Puzzle("What is 2 x 7?", "14"));
            puzzles.Add(new Puzzle("What is 12 - 4?", "8"));
        }
    }

    public void CreateRooms()
    {
        if (currentroom == 2)
        {
            rooms.Add(new Room("Room2"));
        }

        if (currentroom == 3)
        {
            rooms.Add(new Room("Room3"));
        }

        if (currentroom == 4)
        {
            rooms.Add(new Room("Room4"));
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Room1");
    }

    public void Next()
    {
        //SceneManager.LoadScene(rooms[currentroom].name);
        nextRoom();
    }
}