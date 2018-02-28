using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    public GameObject[] Test;
    public List<Vector3> FieldSpots;
	// Use this for initialization
	void Start () {
	    for (int i = 0; i < Test.Length; i++)
	    {
	        FieldSpots.Add(Test[i].transform.position);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}



}
