using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPuzzleScript : MonoBehaviour {
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            GameObject.Find("MainController").GetComponent<MainScript>().FinishPuzzle("test");
        }

        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0)) {
            Application.Quit();
        }
	}
}
