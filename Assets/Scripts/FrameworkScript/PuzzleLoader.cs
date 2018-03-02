using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLoader : MonoBehaviour {

    public string sceneName;            // Name of the scene to load when painting is activated
    public List<string> dependencies;   // List of puzzles that must be completed before this painting can be activated
    bool active;                        // Whether or not this painting is active
    GameObject mainScript;

    /// <summary>
    /// Check all dependencies on script start
    /// </summary>
    void Start() {
        // Get the main script object
        mainScript = GameObject.Find("MainController");

        // Assume painting is active
        active = true;

        // Go through the dependency list and check if all of the dependecies have been fulfilled
        foreach (string d in dependencies) {
            if (!mainScript.GetComponent<MainScript>().completedPuzzles.Contains(d)) {
                // If at least one dependency does not exist in the completedPuzzles list, deactivate the painting
                active = false;
                break;
            }
        }

        // If the puzzle attached to this painting has been already completed, deactivate this painting
        if (mainScript.GetComponent<MainScript>().completedPuzzles.Contains(sceneName)) {
            active = false;
        }
    }

    /// <summary>
    /// When a painting is used, load it's associated scene
    /// </summary>
    public void OnUsed() {
        if (active) {
            mainScript.GetComponent<MainScript>().LoadPuzzle(sceneName);
        }
    }
}
