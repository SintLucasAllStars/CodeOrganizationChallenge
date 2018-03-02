using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGScript : MonoBehaviour {

    public List<string> dependancies;
    GameObject mainScript;

	/// <summary>
    /// Door script checks if all of it's dependancies have been fulfilled.
    /// If they are, the door is destroyed
    /// </summary>
	void Start () {
        mainScript = GameObject.Find("MainController");

        bool open = true;

        foreach (string d in dependancies) {
            if (!mainScript.GetComponent<MainScript>().completedPuzzles.Contains(d)) {
                open = false;
                break;
            }
        }

        if (open) {
            Destroy(gameObject);
        }
	}
}
