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
        if (cardType == combineCard.GetCardType())
        {
            combineType = cardType;
        }

        if (cardNumber == combineCard.GetCardNumber())
        {
            combineNumber = cardNumber;
        }
    }

}
