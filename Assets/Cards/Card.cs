public class Card
{
    private CardType cardType;
    private int cardNumber;

    public Card(CardType cardType, int cardNumber)
    {
        this.cardType = cardType;
        this.cardNumber = cardNumber;
    }

    public CardType GetCardType()
    {
        return cardType;
    }

    public int GetCardNumber()
    {
        return cardNumber;
    }

    public Card Combine(Card combineCard)
    {
        Card returnCard;
        if (cardType == combineCard.GetCardType())
        {
            returnCard = CardManager.GetCardManager().FindCard(cardType);
        }
        else if (cardNumber == combineCard.GetCardNumber())
        {
            returnCard = CardManager.GetCardManager().FindCard(cardNumber);
        }
        else
        {
            returnCard = CardManager.GetCardManager().GetRandomAvailableCard();
        }

        CardManager.GetCardManager().MarkCardAvailable(this);
        CardManager.GetCardManager().MarkCardAvailable(combineCard);
        return returnCard;
    }
    
}