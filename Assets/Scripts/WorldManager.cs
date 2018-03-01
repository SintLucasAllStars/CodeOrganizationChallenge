using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    #region Variables
    public List<Creature> creatures = new List<Creature>();
    public List<Food> foods = new List<Food>();

    public enum Climate { Winter, Summer, Spring, Autumn };
    public Climate worldClimate;

    public int obstacleAmount;

    public float timeScale;
    public float worldSize;
    public float worldAge;
    [Range(2, 12)]
    public float foodMultiplier;

    public GameObject randomFood;
    #endregion

    public void Start()
    {
        Time.timeScale = timeScale;

        StartCoroutine(FoodSpawner());

        // Make the world the size it is assigned to be
        GameObject.Find("Ground").transform.localScale = new Vector3(worldSize / 10, 1, worldSize / 10);

        // Repeat the spawn depending on the size of the map and the food multiplier
        for (int i = 0; i < Mathf.RoundToInt(worldSize / foodMultiplier); i++)
        {
            //Spawn a random food on a random location on the world
            Instantiate(randomFood, new Vector3(Random.Range(-worldSize / 2 - -worldSize / 10, worldSize / 2 - worldSize / 10), 0, Random.Range(-worldSize / 2 + worldSize / 10, worldSize / 2 - worldSize / 10)), Quaternion.identity);
        }
    }

    public IEnumerator FoodSpawner()
    {
        yield return new WaitForSeconds(foodMultiplier * 1.5f / (worldSize / 50));
        Instantiate(randomFood, new Vector3(Random.Range(-worldSize / 2 - -worldSize / 10, worldSize / 2 - worldSize / 10), 0, Random.Range(-worldSize / 2 + worldSize / 10, worldSize / 2 - worldSize / 10)), Quaternion.identity);
        StartCoroutine(FoodSpawner());
    }
}