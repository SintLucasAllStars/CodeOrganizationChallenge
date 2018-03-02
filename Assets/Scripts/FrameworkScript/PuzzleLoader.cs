using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLoader : MonoBehaviour {

    public string sceneName;

    public void OnUsed() {
        GameObject mainScript = GameObject.Find("MainController");
        mainScript.GetComponent<MainScript>().LoadPuzzle(sceneName);
    }
}
