using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBushes : MonoBehaviour {

	public float foodRecharge;
	public float maxFood;
	public FoodBush foodBushScript;

	public GameObject prefabFoodBush;

	public FoodBushes (float fr, float mf, GameObject prefabBush) 
	{
		foodRecharge = fr;
		maxFood = mf;
		prefabFoodBush = prefabBush;

		GameObject foodBush = Instantiate (prefabFoodBush, new Vector3 (Random.Range (499, -499), 2, Random.Range (499, -499)), Quaternion.identity);

		foodBush.transform.localScale = new Vector3 (maxFood, maxFood, maxFood);

		MeshRenderer m = foodBush.GetComponent<MeshRenderer> ();
		m.material.SetColor ("_Color", new Color (1, 0, 0));

		foodBushScript = foodBush.GetComponent<FoodBush> ();
		foodBushScript.maxFood = Random.Range (1, 4);
		foodBushScript.foodRecharge = Random.Range (5, 15);
	}
}