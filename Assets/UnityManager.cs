using System;
using UnityEngine;
using UnityEngine.UI;

public class UnityManager : MonoBehaviour
{
	public Text cardText;
	public Text playCardText;
	public InputField inputField;

	private Deck playerDeck;
	private Deck computerDeck;

	// Use this for initialization
	void Start ()
	{
		CardManager cardManager = new CardManager();
		cardManager.LoadCards();
		
		playerDeck = new Deck();
		computerDeck = new Deck();
		
		playerDeck.GetStartCards();
		computerDeck.GetStartCards();
		
		UpdateCardText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RunCommandButton()
	{
		String[] args = inputField.text.Split(' ');
		inputField.text = "";

		if (args[0].Equals("place"))
		{
			if (args.Length != 3)
			{
				inputField.text = "Usage: place <card-type> <card number>";
				return;
			}

			CardType cardType = CardManager.GetCardManager().GetCardType(args[1]);
			if (cardType == CardType.Null)
			{
				inputField.text = "Invalid Card Type";
				return;
			}

			int cardNumber = int.Parse(args[2]);
			if (cardNumber < 2 || cardNumber > 9)
			{
				inputField.text = "Invalid Card Number";
				return;
			}

			Card card = playerDeck.GetCard(cardType, cardNumber);
			if (card == null)
			{
				inputField.text = "Card not found!";
				return;
			}

			if (!card.CanPlace())
			{
				inputField.text = "You are not allowed to place this card!";
				return;
			}
			playerDeck.RemoveFromDeck(card);
			CardManager.GetCardManager().SetCurrentPlayCards(card);
			
			computerDeck.ComputerTurn();
			
			UpdateCardText();
			return;
		}

		if (args[0].Equals("combine"))
		{
			if (args.Length != 5)
			{
				inputField.text = "Usage: combine <type> <number> <type> <number>";
				return;
			}
			

			// Card 1
			CardType cardType1 = CardManager.GetCardManager().GetCardType(args[1]);
			if (cardType1 == CardType.Null)
			{
				inputField.text = "Invalid Card Type";
				return;
			}

			int cardNumber1 = int.Parse(args[2]);
			if (cardNumber1 < 2 || cardNumber1 > 9)
			{
				inputField.text = "Invalid Card Number";
				return;
			}

			Card card1 = playerDeck.GetCard(cardType1, cardNumber1);
			if (card1 == null)
			{
				inputField.text = "Card not found!";
				return;
			}

			// Card 2
			CardType cardType = CardManager.GetCardManager().GetCardType(args[1]);
			if (cardType == CardType.Null)
			{
				inputField.text = "Invalid Card Type";
				return;
			}

			int cardNumber = int.Parse(args[2]);
			if (cardNumber < 2 || cardNumber > 9)
			{
				inputField.text = "Invalid Card Number";
				return;
			}

			Card card2 = playerDeck.GetCard(cardType, cardNumber);
			if (card2 == null)
			{
				inputField.text = "Card not found!";
				return;
			}
			
			playerDeck.Combine(card1, card2);
			
			computerDeck.ComputerTurn();
			
			UpdateCardText();
			
		}
	}

	public void UpdateCardText()
	{
		cardText.text = "Cards:" + '\n';
		foreach (Card card in playerDeck.GetCards())
		{
			cardText.text += card.ToString() + '\n';
		}

		playCardText.text = CardManager.GetCardManager().GetCurrentPlayCard().ToString();

	}

	public void NextPlayer()
	{
		playerDeck.PickNewCard();
		computerDeck.ComputerTurn();
		UpdateCardText();
	}
	
}