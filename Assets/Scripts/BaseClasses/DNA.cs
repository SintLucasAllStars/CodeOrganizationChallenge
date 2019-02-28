using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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

[System.Serializable]
public struct Genes
{

    public float speed;
    public float Size;
    public float Strength;
    public float Aggresion;
    public float HormoneLevel;
    public GenderType Gender;
    public FoodType foodType;
    public Color skinColor;
    


}

public class DNA 
{
    //Variables

    public Genes genes;
     
   
}
