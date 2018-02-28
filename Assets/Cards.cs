using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cards{
    public enum CardType {Minion, Spell};

    bool active;
    CardType type;
    int health;
    int damage;
    Sprite cardSprite;
    GameObject gameObject;

    public Cards(CardType cardType, int health, int damage)
    {
        active = true;
    }

    public void GetCard()
    {
        if (active)
        {

        }
    }
}
