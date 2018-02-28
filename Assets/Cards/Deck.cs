using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
    }

    private List<Card> GetSuitableCards(Card playCard)
    {
        List<Card> returnList = new List<Card>();
        foreach (Card card in cards)
        {
            if (card.GetCardType() == playCard.GetCardType() || card.GetCardNumber() == playCard.GetCardNumber())
            {
                returnList.Add(card);
            }
        }
        return returnList;
    }

    public void GetStartCards()
    {
        cards = new List<Card>();
        for (int i = 0; i < 7; i++)
        {
            cards.Add(CardManager.GetCardManager().GetRandomAvailableCard());
        }
    }

    public void ComputerTurn()
    {
        List<Card> suitableCards = GetSuitableCards(CardManager.GetCardManager().GetCurrentPlayCard());
        if (suitableCards.Count == 0)
        {
            cards.Add(CardManager.GetCardManager().GetRandomAvailableCard());
        }
        else
        {
            Card card = suitableCards[new Random().Next(suitableCards.Count)];
            cards.Remove(card);
            CardManager.GetCardManager().SetCurrentPlayCards(card);
        }
    }
    
}