using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public int speed;
	public GameObject gamemanager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis("Horizontal");

		transform.Translate(horizontal * speed * Time.deltaTime, 0f, 0f);

		float vertical = Input.GetAxis("Vertical");

		transform.Translate(0f, vertical * speed * Time.deltaTime, 0f);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Portal")
		{
			gamemanager.GetComponent<GameManager>().LoadNewPuzzle();
		}
	}
}
