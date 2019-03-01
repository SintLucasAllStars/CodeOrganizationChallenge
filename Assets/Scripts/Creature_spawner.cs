using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature_spawner : MonoBehaviour
{
    public GameObject creature;
    public int length;

    void Start()

    {
        for (int i = 0; i < length; i++)
        {
            Vector3 newPos = new Vector3(Random.value * 500, 24.5f, Random.value * 500);
            Instantiate(creature, newPos, Quaternion.identity);
        }
        
    }
}