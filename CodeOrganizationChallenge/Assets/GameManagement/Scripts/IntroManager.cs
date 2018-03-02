using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

	public Sprite[] NamingImages;
	public string[] dicriptions;
	string[] givenNames = new string[7];
	public Image imageDisplay;
	public Text discriptionText;
	public InputField nameInput;
	int currentSprite = 0;
	bool inputActive = false;
	public GameObject[] objectHiding;

	void Start (){
		DontDestroyOnLoad(gameObject);
		nameInput.gameObject.SetActive (false);
	}

	public void firstClick(){
		imageDisplay.enabled = true;
		nameInput.gameObject.SetActive (true);

		for (int i = 0; i < objectHiding.Length; i++) {
			objectHiding [i].SetActive (false);
		}

	}

	public void DisplayImage (){
		inputActive = true;
		if (currentSprite < 7) {
			imageDisplay.sprite = NamingImages [currentSprite];
			discriptionText.text = dicriptions [currentSprite];

		} else {
			SceneManager.LoadScene (1);

		}
	}



	void Update(){
		if (inputActive && Input.GetKeyDown (KeyCode.Return)) {
			givenNames [currentSprite] = nameInput.text;
			nameInput.text = "";
			currentSprite++;
			DisplayImage();

		}

		if (SceneManager.GetActiveScene().name == "Scene") {
			GameObject[] namefield = GameObject.FindGameObjectsWithTag ("NameField");
			for (int i = 0; i < givenNames.Length; i++) {
				namefield [i].GetComponent<Text> ().text = givenNames [i];
				Destroy (gameObject);
			}
			
		}


	}
}
