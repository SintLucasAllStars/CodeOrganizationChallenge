using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Button play;

	void ButtonPress(){
		SceneManager.LoadScene ("Level1");
	
	}
}
