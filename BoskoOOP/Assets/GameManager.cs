using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public ClassPuzzle thisPuzzle;
	public ClassPuzzle centralRoom;
	public ClassEscapeRoom thisEscapeRoom;

	public bool puzzleComplete;
	public GameObject door;
	public GameObject key;


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
			Instantiate (door, new Vector2 (Random.Range (-8, 8), Random.Range (-4, 4)), Quaternion.identity);
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
		yield return new WaitForSeconds (0.5f);
		Instantiate (key, new Vector2 (thisEscapeRoom.keyPosX, thisEscapeRoom.keyPosY), Quaternion.identity);
	}
	#endregion

}
