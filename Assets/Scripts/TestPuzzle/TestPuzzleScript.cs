using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPuzzleScript : MonoBehaviour {
	void Update () {
//		sets the puzzle as completed and changes the scene to main again when pressing Left mouse button 
		if (Input.GetMouseButtonDown(0)) {
            GameObject.Find("MainController").GetComponent<MainScript>().FinishPuzzle("test");
        }
// 		if you do not press Left mouse button the game quits
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0)) {
            Application.Quit();
        }
	}
}
