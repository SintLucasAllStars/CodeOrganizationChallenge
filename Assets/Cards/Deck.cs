using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Card> cards;

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
            Card card = suitableCards[Random.Range(0, suitableCards.Count)];
            cards.Remove(card);
            CardManager.GetCardManager().SetCurrentPlayCards(card);
        }
    }

    public List<Card> GetCards()
    {
        return cards;
    }

    public void RemoveFromDeck(Card card)
    {
        cards.Remove(card);
    }

    public Card GetCard(CardType cardType, int cardNumber)
    {
        foreach (Card card in cards)
        {
            if (card.GetCardType() == cardType && card.GetCardNumber() == cardNumber)
            {
                return card;
            }
        }

        return null;
    }

    public void Combine(Card card1, Card card2)
    {
        cards.Add(card1.Combine(card2));
        RemoveFromDeck(card1);
        RemoveFromDeck(card2);
        cards.Add(CardManager.GetCardManager().GetRandomAvailableCard());
    }

    public void PickNewCard()
    {
        cards.Add(CardManager.GetCardManager().GetRandomAvailableCard());
    }
    
}