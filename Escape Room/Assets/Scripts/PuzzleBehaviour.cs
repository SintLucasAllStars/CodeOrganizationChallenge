using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBehaviour : MonoBehaviour
{
    public string SceneName;
    GameManager gm;

    void Start()
    {
        gm.Instantiate(gm.RegisterPuzzle(this));
    }


    private void OnCollisionEnter(Collision collision)
    {
        gm.Instantiate(gm.LoadPuzzle(SceneName));
    }
}
