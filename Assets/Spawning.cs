using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {
	public GameObject Beasts;
	// Use this for initialization
	void Start () {

		for (int i = 0; i < 8; i++) {
			Instantiate(Beasts, new Vector3(Random.Range(-90, 90), 10,Random.Range(-90, 90)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
