using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {
    public List<Creature> creatures = new List<Creature>();
    public List<Food> foods = new List<Food>();

    public enum Climate { Winter, Summer, Spring, Autumn};
    public Climate worldClimate;

    public Vector3 worldSize;

    public int obstacleAmount;
    public int foodAmount;

    public float worldAge;
}