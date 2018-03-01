using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    public List<string> completedPuzzles;               // Completed puzzles list.
    public GameObject player;                           // The player object (might be replaced).
    public Vector3 startingPosition, startingRotation;  // Starting position and rotation of the player - set in editor.

    Vector3 playerPosition;     /* Player position and rotation to be  */
    Quaternion playerRotation;  /*   saved when loading a new scene.   */

    // Replace with singleton - Kars' job btw
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Creates an empty completed puzzles list and sets player starting position
    /// </summary>
    void Start() {
        completedPuzzles = new List<string>();
        playerPosition = startingPosition;
        playerRotation = Quaternion.Euler(startingRotation);
    }

    /// <summary>
    /// Loads a puzzle's scene and saves players position
    /// </summary>
    /// <param name="puzzleSceneName">Puzzle scene name</param>
    public void LoadPuzzle(string puzzleSceneName) {
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;
        SceneManager.LoadScene(puzzleSceneName, LoadSceneMode.Single);
    }

    /// <summary>
    /// Called when puzzle is completed, adds the puzzle's name into the completed
    /// puzzles list, loads the main scene and restores the players position
    /// </summary>
    /// <param name="puzzleName">Puzzle name.</param>
    public void FinishPuzzle(string puzzleName) {
        completedPuzzles.Add(puzzleName);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);

        // Should theoretically work, but player might not exist yet? NEEDS TESTING
        player.transform.SetPositionAndRotation(playerPosition, playerRotation);
    }
}
