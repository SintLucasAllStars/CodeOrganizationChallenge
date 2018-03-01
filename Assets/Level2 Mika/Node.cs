using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{

	public Transform camPos;
	public List<Node> reachNodes = new List<Node> ();

	[HideInInspector]
	public Collider col;

	void Start ()
	{
		col = GetComponent<Collider> ();
		
	}
}