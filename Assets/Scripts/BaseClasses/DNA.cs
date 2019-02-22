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
    public float speed;
    public float Size;
    public float Strength;
    public float Aggresion;
    public GenderType Gender;
    public FoodType foodType;
    public Color skinColor;



    public DNA()
    {
    
    }


}
