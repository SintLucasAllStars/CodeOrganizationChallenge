using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum GenderType
{
    Male,
    Female,
}

[System.Serializable]
public struct Genes
{
    
    public float Size;
    public float Strength;
    public float Aggresion;
    public GenderType Gender;
    public Color skinColor;
}

public class DNA 
{
    //Variables
    public Genes genes;
}
