using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_spawner : MonoBehaviour
{

    public GameObject food;
    public int length;

    float timer;

    public bool continues_spawner;

    void Start()
    {
        for (int i = 0; i < length; i++)
        {
            Vector3 newPos = new Vector3(Random.value * 500, 27f, Random.value * 500);
            Instantiate(food, newPos, Quaternion.identity);
        }

    }
    void Update()
    {
        if(continues_spawner == true)
        {
            timer += Time.deltaTime;

            if (timer > 15)
            {
                Vector3 newPos = new Vector3(Random.value * 500, 27f, Random.value * 500);
                Instantiate(food, newPos, Quaternion.identity);
                timer = 0;
            }
        }
    }
}