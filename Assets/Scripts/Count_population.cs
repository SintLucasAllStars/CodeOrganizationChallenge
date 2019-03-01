using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_population : MonoBehaviour
{
    public Text counter;
    public int total_pop;

    public GameObject[] find;

    void Update()
    {
        find = GameObject.FindGameObjectsWithTag("Creature");
        total_pop = find.Length;

        counter.text = total_pop.ToString();
    }
}
