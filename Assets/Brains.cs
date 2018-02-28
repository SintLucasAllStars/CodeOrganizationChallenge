using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brains : MonoBehaviour {
    public List<Cards> cardsList;

    int handLenght = 7;
    int totalPlayer = 2;
    int playerOneHealt;
    int playerTwoHealt;


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
            Cards.CardType t = Cards.CardType.Minion;

            switch(val)
            {
                case 0: t = Cards.CardType.Minion;
                    break;
                case 1: t = Cards.CardType.Spell;
                    break;
            }
            Debug.Log(t);
            cardsList.Add(new Cards(t, Random.Range(1, 11), Random.Range(1, 16)));
        }
    }
}
