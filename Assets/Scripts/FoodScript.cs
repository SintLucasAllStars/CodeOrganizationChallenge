using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

    public Food thisFood;

    public string foodType;

    public float restoreValue;

    private MeshRenderer thisMaterial;
    public Material treeMat;
    public Material melonMat;
    public Material bushMat;

	void Start () {
        thisMaterial = GetComponent<MeshRenderer>();

        thisFood = new Food();

        foodType = thisFood.thisFoodType;
        restoreValue = thisFood.restoreValue;

        if (foodType == "Tree")
        {
            thisMaterial.material = treeMat;
            transform.localScale = new Vector3(0.5f, 2, 0.5f);
        }

        if (foodType == "Melon")
        {
            thisMaterial.material = melonMat;
        }

        if (foodType == "Bush")
        {
            thisMaterial.material = bushMat;
            transform.localScale = new Vector3(2, 0.5f, 2);
        }
    }
}
