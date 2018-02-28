using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
	string deckName;
	public List<Card> cardList;
	string owner;

	public Deck(string dckName, string own){
		deckName = dckName;
		owner = own;
		cardList = new List<Card> (1);


	}

	public void AddCardToList(string name, GameObject image, string effect, Card.cardType type, Card.cardAttribute attribute, Card.monsterType mnType, Card.spellType sType, Card.trapType tType, int mAtk, int mDef, Card.cardState state, string ow ){
		cardList.Add(new Card(name,image,effect,type,attribute,mnType,sType,tType,mAtk,mDef,state,ow));
	}

}
