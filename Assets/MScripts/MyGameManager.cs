using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour {

	World myWorld;
    public GameObject worldPrefab;
    public GameObject prefabAnimal;
	public GameObject prefabFoodBush;

    private void Start()
    {
		myWorld = new World(worldPrefab, 100, prefabAnimal, prefabFoodBush);
    }

}
