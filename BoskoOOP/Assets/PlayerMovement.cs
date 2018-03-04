using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public ClassPuzzle thisPuzzle;
	public int speed;
	private GameObject gameManager;
	public Transform backToMainDoor;

	void Start () 
	{
		gameManager = GameObject.Find("=========GAMEMANAGER=======");
	}

	void Update () {
		float horizontal = Input.GetAxis("Horizontal");

		transform.Translate(horizontal * speed * Time.deltaTime, 0f, 0f);

		float vertical = Input.GetAxis("Vertical");

		transform.Translate(0f, vertical * speed * Time.deltaTime, 0f);

		if (GameManager.spawnDoor == true)
		{
			Instantiate(backToMainDoor, new Vector2 (0,0), Quaternion.identity);
			GameManager.spawnDoor = false;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Portal")
		{
			Portals.show = false;
			gameManager.GetComponent<GameManager>().LoadNewPuzzle();
		}

		if (col.gameObject.tag == "Main")
		{
			GameManager.closeIn = false;
			Portals.show = true;
			SceneManager.LoadScene ("PuzzleGame2D");
		}

		if (col.gameObject.tag == "Key")
		{
			Instantiate(backToMainDoor, new Vector2 (Random.Range (-7, 8), Random.Range (-3, 4)), Quaternion.identity);
			Destroy (col.gameObject);
		}
	}
}
