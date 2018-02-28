using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card {
	string cardName;
	GameObject cardImage;
	string cardEffect;
	public enum cardType {monster, spell, trap};
	cardType myCardType;
	public enum cardAttribute {dark, divine, earth, fire, light, water,wind};
	cardAttribute myCardAttribute;
	public enum monsterType {aqua, beast, beastWarrior, dinosaur, divineBeast, dragon, fairy, fiend, fish, insect, machine, plant, psychic, pyro, reptile, rock, seaSerpent, spellcaster, thunder, warrior, wingedBeast, wyrm, zombie};
	monsterType myMonsterType;
	public enum spellType {normal, continous, quickPlay, fieldSpell, equip };
	spellType mySpellType;
	public enum trapType {normal, continous, counter, equip};
	trapType myTrapType;
	int monsterAttack;
	int monsterDefense;
	public enum cardState {inDeck, inHand, inGraveyard, attackPosition, defensePosition};
    cardState myCardState;
	string cardOwner;

	public Card(string crdName, GameObject crdImage, string crdEffect, cardType crdType, cardAttribute crdAttribute, monsterType monType, spellType spType, trapType tpType, int monAttack, int monDefense, cardState crdState, string crdOwner){
		cardName = crdName;
		cardImage = crdImage;
		cardEffect = crdEffect;
		myCardType = crdType;
		myCardAttribute = crdAttribute;
		myMonsterType = monType;
		mySpellType = spType;
		myTrapType = tpType;
		monsterAttack = monAttack;
		monsterDefense = monDefense;
		myCardState = crdState;
		cardOwner = crdOwner;

	}

	public string GetCardName(){
		return cardName;
	}
	public GameObject GetCardimage(){
		return cardImage;
	}
	public string GetCardEffect(){
		return cardEffect;
	}
	public cardType GetCardType(){
		return myCardType;
	}

	public cardAttribute GetCardAttribute(){
		return myCardAttribute;
	}

	public monsterType GetMonsterType(){
		return myMonsterType;
	}
	public spellType GetSpellType(){
		return mySpellType;
	}

	public trapType GetTrapType(){
		return myTrapType;
	}
	public int GetMonsterAttack(){
		return monsterAttack;
	}
	public int GetMonsterDefense(){
		return monsterDefense;
	}
	public cardState GetCardState(){
		return myCardState;
	}
	public string GetCardOwner(){
		return cardOwner;
	}
}
