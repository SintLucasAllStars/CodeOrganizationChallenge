using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {
	public static Brain myBrain;

	void Awake(){
		if (Brain.myBrain == null) {
			Brain.myBrain = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
