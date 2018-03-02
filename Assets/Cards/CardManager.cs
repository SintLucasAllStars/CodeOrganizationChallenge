using System.Collections.Generic;
using UnityEngine;

public class CardManager
{
	private static CardManager cardManager;
	private List<Card> availableCards;
	private CardType[] cardtypes = {CardType.Harten, CardType.Klaver, CardType.Ruiten, CardType.Schoppen};
	private Card currentPlayCard;

	public CardManager()
	{
		cardManager = this;
	}

	public static CardManager GetCardManager()
	{
		return cardManager;
	}

	public void LoadCards()
	{
		availableCards = new List<Card>();

		foreach (CardType cardType in cardtypes)
		{
			for (int i = 2; i <= 9; i++)
			{
				availableCards.Add(new Card(cardType, i));
			}
		}

		currentPlayCard = GetRandomAvailableCard();
	}

	public Card GetCurrentPlayCard()
	{
		return currentPlayCard;
	}

	public void SetCurrentPlayCards(Card card)
	{
		MarkCardAvailable(currentPlayCard);
		currentPlayCard = card;
	}

	public Card FindCard(CardType cardType)
	{
		foreach (Card card in availableCards)
		{
			if (card.GetCardType() == cardType)
			{
				return ReturnAndRemove(card);
			}
		}
		return GetRandomAvailableCard();
	}

	public Card FindCard(int cardNumber)
	{
		foreach (Card card in availableCards)
		{
			if (card.GetCardNumber() == cardNumber)
			{
				return ReturnAndRemove(card);
			}
		}
		return GetRandomAvailableCard();
	}

	public Card GetRandomAvailableCard()
	{
		return ReturnAndRemove(availableCards[Random.Range(0, availableCards.Count)]);
	}

	private Card ReturnAndRemove(Card card)
	{
		availableCards.Remove(card);
		return card;
	}
	
	public void MarkCardAvailable(Card card)
	{
		availableCards.Add(card);
	}

	public CardType GetCardType(string type)
	{
		foreach (CardType cardType in cardtypes)
		{
			if (cardType.ToString().Equals(type))
			{
				return cardType;
			}
		}
		return CardType.Null;
	}
	
}