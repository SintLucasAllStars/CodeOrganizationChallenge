using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card{
	public enum types {Earth, Wind, Fire, Air};
	public enum state {Deck, Hand, Table};

	bool active;
	types cardType;
	state cardState;
	int value;
	GameObject gameObject;
	Vector3 position;


	public Card (int value, Vector3 position, GameObject prefab, types cardType, state cardState){
		active = true;
		this.value = value;
		this.cardType = cardType;
		this.cardState = cardState;
		this.position = position;
		gameObject = GameObject.Instantiate (prefab, position, Quaternion.identity);


	}

	public types ReturnCardtype (){
		return cardType;
	}

	public int ReturnValue (){
		return value;
	}

}
