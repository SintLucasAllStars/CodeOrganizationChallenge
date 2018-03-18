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

    public Cards(CardType cardType, int health, int damage, GameObject Card)
    {
        this.health = health;
        this.damage = damage;
        this.type = cardType;
        this.gameObject = Card;
        active = true;
        Debug.Log("Healt = " +  health + " "  + "Damage = " + damage);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetDamage()
    {
        return damage;
    }

    public Cards Combine(Cards other)
    {
        int newHealth = this.GetHealth() + other.GetHealth();
        int newDamage = this.GetDamage() + other.GetDamage();
        GameObject go = GameObject.Instantiate(Brains.instance.minionCard, new Vector3(0, 0, 0), Quaternion.identity);

        return new Cards(this.type, newHealth, newDamage, go);
    }
}
