using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {

	public Transform backToMainDoor;

	void OnTriggerEnter (Collider col) 
	{
		if (col.gameObject.tag == "Cube")
		{
			Instantiate(backToMainDoor, new Vector2 (Random.Range (-7, 8), Random.Range (-3, 4)), Quaternion.identity);
		}
	}
}
