using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brains : MonoBehaviour
{
    public List<Cards> cardsList;

    public Text cards;
    int handLenght = 7;
    int totalPlayer = 2;
    int playerOneHealt;
    int playerTwoHealt;

    public GameObject minionCard;
    public GameObject spellCard;


    public void Start()
    {
        cardsList = new List<Cards>();
        playerOneHealt = 30;
        playerTwoHealt = 30;
        Banana();

    }

    public void Banana()
    {
        for (int i = 0; i < handLenght; i++)
        {
            int val = Random.Range(0, 2);
            GameObject cardPrefab = minionCard;
            Cards.CardType t = Cards.CardType.Minion;

            switch (val)
            {
                case 0:
                    cardPrefab = minionCard;
                    t = Cards.CardType.Minion;
                    break;
                case 1:
                    cardPrefab = spellCard;
                    t = Cards.CardType.Spell;
                    break;
            }
            Debug.Log(t);
            cardsList.Add(new Cards(t, Random.Range(1, 11), Random.Range(1, 16), cardPrefab));
            Instantiate(cardPrefab, new Vector3(1.5f *i, 0, 0), Quaternion.identity);
            cards.text +=" " + t.ToString();
        }
    }
}
