using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusPoint : MonoBehaviour {

    public Transform GO1, GO2;
    public Vector3 _middlePoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.Lerp(GO1.position, GO2.position, 0.5f);
    }
}
