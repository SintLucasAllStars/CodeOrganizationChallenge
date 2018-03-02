using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public List <Card> cards;
	public GameObject prefab;
	public int playerAmount;
	public List <Card> player;
	public List <Card> player2;
	int deck;


	// Use this for initialization
	void Start () {
		player = new List<Card> ();
		player2 = new List<Card> ();

		cards = new List<Card>();
		for (int i = 0; i < 30; i++) {
			deck++;
			cards.Add (new Card (Random.Range (1, 7), new Vector3(i*2,0,0), prefab, Card.types.Air, Card.state.Hand));
		}
		for (int i = 15; i < 30; i++) {
			player2.Add (cards[i]);
			player [i].ReturnCardtype ();
			cards.Add (new Card (Random.Range (1, 7), new Vector3(i*2,0,0), prefab, Card.types.Air, Card.state.Hand));
		}
		for (int i = 0; i < 15; i++) {
			player.Add (cards[i]);
			cards.Add (new Card (Random.Range (1, 7), new Vector3(i*2,0,0), prefab, Card.types.Air, Card.state.Hand));
		}
		Debug.Log (player.Count + " " + player2.Count);
		
	}
		
	void Combine (Card card1, Card card2, List<Card> player){
		int value1 = card2.ReturnValue ();
		int value2  = card1.ReturnValue ();
		deck++;
		cards.Add (new Card (value1+value2, new Vector3 (0, 2, 0), prefab, Card.types.Air, Card.state.Hand));
		player.Add (cards [deck]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
