using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public List <Card> cards;
	public GameObject prefab;
	public int playerAmount;

	// Use this for initialization
	void Start () {
		cards = new List<Card>();
		for (int i = 0; i < 30; i++) {
			cards.Add (new Card (Random.Range (1, 7), this.transform.position, prefab, Card.types.Air, Card.state.Deck));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
