using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRoom : MonoBehaviour {
    
    void Start() {
        // Testing out json capabilites
        Settings test = new Settings();
        test.completedPuzzles.Add("puzzle1");
        test.completedPuzzles.Add("puzzle2");
        Debug.Log(JsonUtility.ToJson(test));
    }

}
