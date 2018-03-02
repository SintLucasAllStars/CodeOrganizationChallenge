using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public List<int> hand1 = new List<int>();
	int Count = 9;
	public int totalPoints;
	public GameObject cardOne; //Card number 1
	public GameObject cardTwo; //Card number 2
	public GameObject cardThree; //Card number 3
	public GameObject cardFour; //Card number 4
	public GameObject cardFive; //Card number 5
	public GameObject cardSix; //Card number 6
	public GameObject cardSeven; //Card number 7
	public GameObject cardEight; //Card number 8
	public GameObject cardNine; //Card number 9

	public GameObject[] currentCards = new GameObject[2];
	public int totalCards;

	public Draggable.slot typeOfItem = Draggable.slot.INVENTORY1;

	public void OnPointerEnter (PointerEventData eventData) {
		
	}
	public void OnPointerExit (PointerEventData eventData) {
	
	}
	public void OnDrop (PointerEventData eventData) { //When a card is being dropped on the zone, it adds 1 card to the total and it checks if there are 2 cards
		if (totalCards < 2) {
			currentCards [totalCards] = eventData.pointerDrag.gameObject;
			totalCards++;
			Debug.Log (eventData.pointerDrag.name + " was dropped on " + gameObject.name);
			if (totalCards > 2) {
				totalPoints = 0;
			}

			CardStats cardStats = eventData.pointerDrag.gameObject.GetComponent<CardStats> ();

			if (cardStats != null) { //Giving the cards a value
				Debug.Log (cardStats.cardName);
				if (cardStats.cardName == "Lex") {
					totalPoints += 4;
				}
				if (cardStats.cardName == "Luca") {
					totalPoints += 5;
				}
				if (cardStats.cardName == "hahayes") {
					totalPoints += 3;
				}
				if (cardStats.cardName == "Sam") {
					totalPoints += 7;
				}
				if (cardStats.cardName == "Roggi") {
					totalPoints += 9;
				}
				if (cardStats.cardName == "Freddi") {
					totalPoints += 6;
				}
				if (cardStats.cardName == "Doge") {
					totalPoints += 8;
				}
			}
				
			Draggable d = eventData.pointerDrag.GetComponent<Draggable> (); //Changes the parent object of the card
			if (d != null) {
				if (typeOfItem == d.typeOfItem || typeOfItem == Draggable.slot.INVENTORY1) {
					d.parentToReturnTo = this.transform;
				}
			}
		}
	}
	public void Combine(){ //checking what the sum of the 2 cards being placed down is and what card it should give back

		if (totalPoints == 9) {
			Instantiate(cardNine, transform.position, transform.rotation, this.transform);

			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}
		if (totalPoints == 8) {
			Instantiate (cardEight, transform.position, transform.rotation, this.transform);
			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}
		if (totalPoints == 7) {
			Instantiate (cardSeven, transform.position, transform.rotation, this.transform);
			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}
		if (totalPoints == 6) {
			Instantiate (cardSix, transform.position, transform.rotation, this.transform);
			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}
		if (totalPoints == 5) {
			Instantiate (cardFive, transform.position, transform.rotation, this.transform);
			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}
		if (totalPoints == 4) {
			Instantiate (cardFour, transform.position, transform.rotation, this.transform);
			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}
		if (totalPoints == 3) {
			Instantiate (cardThree, transform.position, transform.rotation, this.transform);
			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}
		if (totalPoints == 2) {
			Instantiate (cardTwo, transform.position, transform.rotation, this.transform);
			for (int i = 0; i < totalPoints; i++) {
				Destroy (currentCards [i]);
			}
			totalPoints = 0;
		}

	}
}
