using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public ClassPuzzle thisPuzzle;
	public ClassPuzzle centralRoom;
	public ClassMaze thisMaze;
	public ClassEscapeRoom thisEscapeRoom;

	public bool puzzleComplete;
	public GameObject door;
	public GameObject key;
	public GameObject player;
	public GameObject[] mazes = new GameObject[5];
	public static bool spawnDoor = false;


	#region SingleTon

	private static GameManager instance = null;

	public static GameManager Instance {

		get { return instance; }
	}

	void Awake()
	{


		if (instance != null && instance != this)

		{

			Destroy(this.gameObject);

			return;
		}
		else

		{
			instance = this;

		}
		DontDestroyOnLoad(this.gameObject);


	}
	#endregion

	void Start () 
	{
		thisPuzzle = new ClassPuzzle ("MainScene");
		for (int i = 0; i <  thisPuzzle.totalPuzzleRooms; i++) 
		{
			float x = 6;
			float y = 7;
			int random;
			random = Random.Range (1, 3);
			if (random == 1) {
				Instantiate (door, new Vector2 (Random.Range(-x, y) , 4), Quaternion.identity);
			} 
			if (random == 2) {
				Instantiate (door, new Vector2 (Random.Range(x, -y) , -4), Quaternion.identity);
			}
		}
		centralRoom = thisPuzzle;
	}

	void Update () 
	{ 
		
	}

	public void LoadNewPuzzle()
	{
		thisPuzzle = new ClassPuzzle();
		Debug.Log (thisPuzzle.currentPuzzle);
		if (thisPuzzle.currentPuzzle == "EscapeRoom")
		{
			EscapeRoom ();
		}
		if (thisPuzzle.currentPuzzle == "Maze")
		{
			Maze ();
		}
	}

	#region EscapeRoom
	public void EscapeRoom()
	{
		SceneManager.LoadScene ("RandomPuzzle");
		thisEscapeRoom = new ClassEscapeRoom ();
		StartCoroutine (SpawnKey ());
	}

	IEnumerator SpawnKey()
	{
		yield return new WaitForSeconds (0.1f);
		Instantiate (player, new Vector2 (-7.5f, -3.5f), Quaternion.identity);
		Instantiate (key, new Vector2 (thisEscapeRoom.keyPosX, thisEscapeRoom.keyPosY), Quaternion.identity);
	}
	#endregion

	#region Maze
	public void Maze()
	{
		SceneManager.LoadScene ("RandomPuzzle");
		thisMaze = new ClassMaze ();
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (0.1f);
		spawnDoor = true;
		int mazeNumber;
		mazeNumber = Random.Range (0, 5);
		Instantiate (mazes [mazeNumber], transform.position, transform.rotation);
		Instantiate (player, new Vector2 (thisMaze.playerLocX, thisMaze.playerLocY), Quaternion.identity); ;
	}
	#endregion

}
