using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gender
{
    Male,
    Female,
}

public enum Behaviour
{
    Peaceful,
    Hostile,
}

[System.Serializable]
public struct Genes
{
    // PROPERTIES
    public Vector3 position;
    public Color color;
    public GameObject go;
    public int shapeNum;
    public float speed;
    public Gender m_gender;
    public Behaviour m_mood;
}

public class DNA
{
    public Genes myGenes;
}


