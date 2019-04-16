using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private static readonly object padlock = new object();
    enum puzzles { Puzzle1, Puzzle2, Puzzle3};
    List<Rooms> room = new List<Rooms>();


    public RegisterPuzzle(PuzzleBehaviour p)
    {
    }

    public LoadPuzzle(string sceneName)
    {

    }

    public void Win()
    {

    }

    public void Lose()
    {
        
    }


    GameManager()
    {
    }

    public static GameManager Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
    }
}
