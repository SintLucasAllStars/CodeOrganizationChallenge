using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World{

    GameObject myWorld;
    Animals animal;
    Creatures creatures;
	FoodBushes foodBush;

    int mySize;

	public World(GameObject WorldPrefab, int size, GameObject prefabAnimal, GameObject prefabFoodBush)
    {
        myWorld = WorldPrefab;
        mySize = size;
        CreateWorld();
        CreateAnimals(prefabAnimal);
		CreateFoodBush (prefabFoodBush);
    }

    public void CreateWorld()
    {
        GameObject thisWorld = MonoBehaviour.Instantiate(myWorld);
        thisWorld.transform.localScale = new Vector3(mySize, mySize, mySize);
    }

    public void CreateAnimals(GameObject prefabAnimal)
    {
        for (int i = 0; i < Random.Range(40, 51); i++)
        {
			animal = new Animals(Random.Range(1, 20), Random.Range(1, 100), Random.Range(1, 100), Random.Range(6, 25), Random.Range(1, 100), prefabAnimal);
        }
    }
	public void CreateFoodBush (GameObject prefabFoodBush) 
	{
		for (int i = 0; i < Random.Range (10, 21); i++) 
		{
			foodBush = new FoodBushes (10, 1, prefabFoodBush);
		}
	}
}
