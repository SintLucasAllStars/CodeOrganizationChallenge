using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour {

    public static MainScript mainScript;
    public List<string> completedPuzzles;               // Completed puzzles list.
    public Vector3 startingPosition, startingRotation;  // Starting position and rotation of the player - set in editor.

    Vector3 playerPosition;     /* Player position and rotation to be  */
    Quaternion playerRotation;  /*   saved when loading a new scene.   */
    GameObject player;

    void Awake() {
        if (mainScript == null)
        {
            mainScript = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Creates an empty completed puzzles list and sets player starting position
    /// </summary>
    void Start() {
        completedPuzzles = new List<string>();
        player = GameObject.Find("MainPlayer"); // Player object in the main scene should be called 'MainPlayer'
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
        SceneManager.sceneLoaded += SetPlayerPosition;
    }

    /// <summary>
    /// Sets the player position back to where player was standing when a puzzle was loaded
    /// </summary>
    /// <param name="scene">The scene that was loaded</param>
    /// <param name="mode">Required to work, but not used</param>
    void SetPlayerPosition(Scene scene, LoadSceneMode mode) {
        if (scene.name == "Main") {
            player = GameObject.Find("MainPlayer");
            player.transform.SetPositionAndRotation(playerPosition, playerRotation);
        }
    }

    /// <summary>
    /// Temporary function to load and unload the 'test' puzzle
    /// </summary>
    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            FinishPuzzle("");
        }
    }
}
