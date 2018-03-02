using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World{

    GameObject myWorld;
    Animals animal;
    Creatures creatures;

    int mySize;

    public World(GameObject WorldPrefab, int size, GameObject prefabAnimal)
    {
        myWorld = WorldPrefab;
        mySize = size;
        CreateWorld();
        CreateAnimals(prefabAnimal);
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
            animal = new Animals(Creatures.EatingBehaviour.omnivore, Random.Range(1, 100), Random.Range(1, 100), Random.Range(1, 100), Random.Range(6, 25), Random.Range(1, 100), prefabAnimal);
        }
    }
}
