using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Bunny konijn;

    public GameObject bunnyprefab;

    void Start()
    {
        SpawnBunny();
       // StartCoroutine(Bunny.movement());
        

    }

   
    void Update()
    {

        konijn.Move();
       // konijn.Meet();


    }


    //als je nieuwe klas aanroep word het een combi van het DNA van de vader en de moeder.
    // doormiddel van de values van het DNA. 
    //instantiate de nieuwe creature met daarin het dna van de moeder en het dna van de vader.
    // haal in de klas van de creature alleen reacties aan. EN
    // roep de values vanuit het DNA.


    void SpawnBunny()
    {
        for(int i = 0; i < 4; ++i)
        {
            konijn = new Bunny(bunnyprefab);
        }
    }
}
