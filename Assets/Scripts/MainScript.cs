using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainScript : MonoBehaviour {

    public List<string> completedPuzzles;

    Vector3 playerPosition;
    Quaternion playerRotation;

    public Vector3 startingPosition, startingRotation;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }
    }

    void Start() {
        completedPuzzles = new List<string>();
        playerPosition = startingPosition;
        playerRotation = Quaternion.Euler(startingRotation);
    }
        
}
