using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World{

    GameObject myWorld;
    int mySize;

    public World(GameObject WorldPrefab, int size)
    {
        myWorld = WorldPrefab;
        mySize = size;
        CreateWorld();
    }

    public void CreateWorld()
    {
        GameObject thisWorld = MonoBehaviour.Instantiate(myWorld);
        thisWorld.transform.localScale = new Vector3(mySize, mySize, mySize);
    }

}
