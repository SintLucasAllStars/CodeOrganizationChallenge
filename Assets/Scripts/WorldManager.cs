using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {
    public List<Creature> creatures = new List<Creature>();
    public List<Food> foods = new List<Food>();

    public enum Climate { Winter, Summer, Spring, Autumn};
    public Climate worldClimate;

    public int obstacleAmount;
    public int foodAmount;

    public float worldSize;
    public float worldAge;

    public void Start()
    {
        GameObject.Find("Ground").transform.localScale = new Vector3(worldSize/10, 1, worldSize/10);                      //Make the world the size it is assigned to be

       /* for (int i = 0; i < length; i++)
        {

        }*/
    }
}
