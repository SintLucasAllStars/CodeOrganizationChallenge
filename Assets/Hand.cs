using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Transform ExplenationCard;
    public GameObject[] HandPosObj;
    public List<Vector3> HandPos;
    public string Owner;
	// Use this for initialization
	void Start ()
	{
	    for (int i = 0; i < HandPosObj.Length; i++)
	    {
	        HandPos.Add(HandPosObj[i].transform.position);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
