using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings {

    // We keep a list of all the puzzles we've completed
    public List<string> completedPuzzles;

    /// <summary>
    /// Initializes a new instance of the <see cref="Settings"/> class.
    /// </summary>
    public Settings() {
        completedPuzzles = new List<string>();
    }
}
