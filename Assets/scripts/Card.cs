using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card{
	//enum types {Earth, Wind, Fire, Air};
	//enum state {Deck, Hand, Table};

	bool active;
	int cardType;
	int cardState;
	int value;
	GameObject gameObject;
	Vector3 position;


	public Card (int value, Vector3 position, GameObject prefab, int cardType, int cardState){
		active = true;
		this.value = value;
		this.cardType = cardType;
		this.cardState = cardState;
		this.position = position;

	}

	public int ReturnCardtype (int type){
		return type;
	}

	public int ReturnValue (int value){
		return value;
	}

}
