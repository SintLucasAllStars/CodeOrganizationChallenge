using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject StartButton;
	public Text questionText;
	public Text scoreDisplay;
	public Text[] nameText;
	public GameObject[] awnserButtons;
	public string [] questionsHit;
	public string [] questionsNap;
	public string [] questionsSta;
	public string [] questionsVlad;
	public string [] questionsAti;
	public string [] questionsJes;
	public string [] questionsNob;
	string[,] questions = new string[7,3];
	string[] currentQuestions = new string[7];
	int[] questionOrder = new int[7];
	int questionNumber;
	int score = 0;

	void Start (){
		for (int i = 0; i < 3; i++) {
			questions [0,i] = questionsHit[i];
		}
		for (int i = 0; i < 3; i++) {
			questions [1,i] = questionsNap[i];
		}
		for (int i = 0; i < 3; i++) {
			questions [2,i] = questionsSta[i];
		}
		for (int i = 0; i < 3; i++) {
			questions [3,i] = questionsVlad[i];
		}
		for (int i = 0; i < 3; i++) {
			questions [4,i] = questionsAti[i];
		}
		for (int i = 0; i < 3; i++) {
			questions [5,i] = questionsJes[i];
		}
		for (int i = 0; i < 3; i++) {
			questions [6,i] = questionsNob[i];
		}

		for (int i = 0; i < 7; i++) {
			questionOrder [i] = i;
		}

		for (int i = 0; i < awnserButtons.Length; i++) {
			awnserButtons [i].SetActive (false);
			nameText [i].enabled = false;
		}

		scoreDisplay.text = score.ToString ();
	}

	public void LoadQuestions(){
		questionNumber = 0;

		for (int i = 0; i < 7; i++) {
			int tmp = questionOrder [i];
			int r = Random.Range (i, 7);
			questionOrder [i] = questionOrder [r];
			questionOrder [r] = tmp;
			StartButton.SetActive (false);

		}

		for (int i = 0; i < awnserButtons.Length; i++) {
			awnserButtons [i].SetActive (true);
			nameText [i].enabled = true;
		}

		for (int i = 0; i < 7; i++) {
			currentQuestions [i] = questions [i, Random.Range (0, 3)];
		}

		DisplayQuestion ();
	}

	public void DisplayQuestion(){
		questionText.text = currentQuestions [questionOrder [questionNumber]];

	}

	public void Awnsered(int which){
		awnserButtons [which].SetActive (false);
		nameText [which].enabled = false;
		if (questionOrder [questionNumber] == which) {
			score++;
		} else {
			score--;
		}


		questionNumber++;
		if (score > 9) {
			SceneManager.LoadScene (2);
		} else if (questionNumber >= 7) {
			StartButton.SetActive (true);
		} else {
			DisplayQuestion ();
		}

		scoreDisplay.text = score.ToString ();
	
	}
		
}
