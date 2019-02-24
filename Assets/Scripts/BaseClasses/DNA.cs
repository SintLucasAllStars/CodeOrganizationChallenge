using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GenderType
{
    Male,
    Female,
}

public enum FoodType
{
    Carnivore,
    Herbivore,
    Omnivore,

}


public class DNA
{
    //Variables
    public float speed = 4;
    public float Size = 1;
    public float Strength = 2;
    public float Aggresion = 1;
    public GenderType Gender = GenderType.Male;
    public FoodType foodType = FoodType.Omnivore;
    public Color skinColor = Color.white;

}
