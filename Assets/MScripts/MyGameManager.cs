using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour {

	World myWorld;
    public GameObject worldPrefab;

    private void Start()
    {
        myWorld = new World(worldPrefab, 100);
    }

}
