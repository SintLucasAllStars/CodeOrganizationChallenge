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

	void OnMouseDown (){
		Debug.Log ("Node clicked");

		Arrive ();

	
	}

	void Arrive(){
		if (GameManager.ins.currentNode != null) {
			GameManager.ins.currentNode.Leave ();
		}

		GameManager.ins.currentNode = this;

		Camera.main.transform.position = camPos.position;
		Camera.main.transform.rotation = camPos.rotation;

		if (col != null) {
			col.enabled = false;
		}

		foreach (Node node in reachNodes) {
			if (node.col != null) {
				node.col.enabled = true;
			}

		}

	}

	public void Leave(){
		foreach (Node node in reachNodes) {
			if (node.col != null) {
				node.col.enabled = false;
			}

		}
	}
}