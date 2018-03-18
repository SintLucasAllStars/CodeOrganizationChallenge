using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brains : MonoBehaviour
{

    public static Brains instance;
    public List<Cards> cardsList;
    public Cards combineCards;

    public GameObject combineCard1;
    public GameObject combineCard2;

    public Text cards;
    int handLenght = 7;
    int totalPlayer = 2;
    int playerOneHealt;
    int playerTwoHealt;

    public GameObject minionCard;
    public GameObject spellCard;
    public Transform canvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        cardsList = new List<Cards>();
        playerOneHealt = 30;
        playerTwoHealt = 30;
        CardGiver();

    }

    public void CardGiver()
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
            GameObject go = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            go.transform.parent = canvas;
            cards.text +=" " + t.ToString();
        }
    }

    public void Combiner()
    {
        combineCard1 = GameObject.FindGameObjectWithTag("CombineCard1");
        combineCard2 = GameObject.FindGameObjectWithTag("CombineCard2");

        Cards n = combineCard1.Combine(combineCard2);

        //

        cardsList.Add(n);

    }
}
