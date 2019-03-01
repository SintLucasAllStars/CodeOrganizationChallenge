using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerControl : MonoBehaviour 
{
    /*
     * this take care of restating level
     * and going back to the mainmenu
     */

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("LevelChoose");
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
	}
}