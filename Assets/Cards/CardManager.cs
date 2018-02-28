using System.Collections.Generic;

public class CardManager
{
	private static CardManager cardManager;
	private List<Card> avalibleCards;
	private CardType[] cardtypes = {CardType.Harten, CardType.Klaver, CardType.Ruiten, CardType.Schoppen};

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
		avalibleCards = new List<Card>();

		foreach (CardType cardType in cardtypes)
		{
			for (int i = 2; i <= 9; i++)
			{
				avalibleCards.Add(new Card(cardType, i));
			}
		}
	}

	public Card FindCard(CardType cardType)
	{
		foreach (Card card in avalibleCards)
		{
			if (card.GetCardType() == cardType)
			{
				return ReturnAndRemove(card);
			}
		}
		return GetRandomAvalibleCard();
	}

	public Card FindCard(int cardNumber)
	{
		foreach (Card card in avalibleCards)
		{
			if (card.GetCardNumber() == cardNumber)
			{
				return ReturnAndRemove(card);
			}
		}
		return GetRandomAvalibleCard();
	}

	public Card GetRandomAvalibleCard()
	{
		return ReturnAndRemove(avalibleCards[0]);
	}

	private Card ReturnAndRemove(Card card)
	{
		avalibleCards.Remove(card);
		return card;
	}
	
}