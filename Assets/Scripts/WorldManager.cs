﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {
    public List<Creature> creatures = new List<Creature>();
    public List<Food> foods = new List<Food>();

    public enum Climate { Winter, Summer, Spring, Autumn};
    public Climate worldClimate;

    public int obstacleAmount;

    public float worldSize;
    public float worldAge;
    [Range(2,12)]
    public float foodMultiplier;

    public GameObject randomFood;

    public void Start()
    {
        GameObject.Find("Ground").transform.localScale = new Vector3(worldSize/10, 1, worldSize/10);                                                            //Make the world the size it is assigned to be

        for (int i = 0; i < Mathf.RoundToInt(worldSize/foodMultiplier); i++)                                                                                    //repeat the spawn depending on the size of the map and the food multiplier
        {
            Instantiate(randomFood, new Vector3(Random.Range(-worldSize/2- -worldSize/10, worldSize/2 - worldSize / 10), 0, Random.Range(-worldSize/2 + worldSize / 10, worldSize/2 - worldSize / 10)), Quaternion.identity);     //Spawn a random food on a random location on the world
        }
    }
}