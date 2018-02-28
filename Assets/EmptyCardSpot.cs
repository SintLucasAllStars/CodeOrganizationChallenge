using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCardSpot : MonoBehaviour
{
   [SerializeField] private Vector3 pos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        pos = this.transform.position;
    }
    
}
