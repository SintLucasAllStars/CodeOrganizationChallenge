using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food {

    public string[] foodType = new string[]{ "Tree", "Melon", "Bush"};
    public string thisFoodType;

    public float restoreValue;

    public Food()
    {
        thisFoodType = foodType[Random.Range(0, foodType.Length)].ToString();
        restoreValue = Random.Range(25, 75);
    }

    public Food(string currentFood)
    {
        thisFoodType = currentFood;

        if (currentFood == "Tree")
        {
            this.restoreValue = Random.Range(55, 75);
        }

        if (currentFood == "Melon")
        {
            this.restoreValue = Random.Range(40, 55);
        }

        if (currentFood == "Bush")
        {
            this.restoreValue = Random.Range(25, 40);
        }
    }
}