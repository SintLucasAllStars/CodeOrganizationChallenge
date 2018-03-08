using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBush : MonoBehaviour {
	public float currentFood;
	public float foodRecharge;
	public float maxFood;

	MeshRenderer colorFoodCheck;

	// Use this for initialization
	void Start () 
	{
		transform.localScale = new Vector3 (maxFood, maxFood, maxFood);
		StartCoroutine (GrowFood());
		colorFoodCheck = GetComponent<MeshRenderer> ();

	}

	void SetBush (float mf, float fr)
	{
		foodRecharge = fr;
		maxFood = mf;
		currentFood = mf;
	}

	void OnCollisionEnter (Collision coll)
	{
		if (coll.gameObject.tag == "Animal") 
		{
			currentFood--;
			colorFoodCheck.material.SetColor ("_Color", new Color (currentFood / maxFood, 0, 0));
		}
	}

	private IEnumerator GrowFood () 
	{
		yield return new WaitForSeconds(foodRecharge);
		if (currentFood > maxFood) 
		{
			currentFood++;
			Debug.Log ("Food Added");
			colorFoodCheck.material.SetColor ("_Color", new Color (currentFood / maxFood, 0, 0));
		}
		StartCoroutine (GrowFood());
	}
}