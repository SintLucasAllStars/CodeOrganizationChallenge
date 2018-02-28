using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public List<Deck> myDecks = new List<Deck>();
	public Text deckName;
	public GameObject testObject;
	public int counter;
	public int deckCounter;
	public Dropdown deckList;
	List<string> DeckAsNumbers = new List<string>();
	// Use this for initialization
	void Start () {
		deckCounter = -1;
	}
	
	// Update is called once per frame
	void Update () {
	}


	public void CreateDeck(){
		myDecks.Add (new Deck (deckName.text, "player1"));
		deckCounter++;
		DeckAsNumbers.Add (deckCounter.ToString ());
		deckList.ClearOptions ();
		deckList.AddOptions (DeckAsNumbers);

}

	public void CreateCard(){
		myDecks[0].AddCardToList (Random.Range(0,100).ToString(), testObject, "do this", Card.cardType.monster, Card.cardAttribute.divine, Card.monsterType.beastWarrior, Card.spellType.none, Card.trapType.none, 1900, 1200, Card.cardState.inDeck, "player1");
		Debug.Log (myDecks [0].cardList [counter].GetCardName());
		counter++;

	}
}