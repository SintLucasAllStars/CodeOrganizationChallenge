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
			cards.Add (new Card (Random.Range (1, 5), transform.position, prefab, Random.Range (0, 4), 0));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
