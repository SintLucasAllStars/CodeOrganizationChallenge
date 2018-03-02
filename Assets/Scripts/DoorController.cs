using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public List<string> dependencies;   // List of puzzles that must be completed before the door opens

	/// <summary>
    /// Door script checks if all of it's dependancies have been fulfilled.
    /// If they are, the door is destroyed
    /// </summary>
	void Start () {
        // Get the main script object
        GameObject mainScript = GameObject.Find("MainController");

        // Open the door by default, prevents door being closed if it's dependencies have not been setup
        bool open = true;

        // Go through the dependency list and check if all of the dependecies have been fulfilled
        foreach (string d in dependencies) {
            if (!mainScript.GetComponent<MainScript>().completedPuzzles.Contains(d)) {
                // If at least one dependency does not exist in the completedPuzzles list, close the door
                open = false;
                break;
            }
        }

        // If the door should be open, then just destroy the entire object
        if (open) {
            Destroy(gameObject);
        }
	}
}
