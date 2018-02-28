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
        CardManager.GetCardManager().MarkCardAvailable(this);
        CardManager.GetCardManager().MarkCardAvailable(combineCard);
        if (cardType == combineCard.GetCardType())
        {
            return CardManager.GetCardManager().FindCard(cardType);
        }

        if (cardNumber == combineCard.GetCardNumber())
        {
            return CardManager.GetCardManager().FindCard(cardNumber);
        }
        return CardManager.GetCardManager().GetRandomAvailableCard();
    }

}