using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour {

	public static bool show = true;
	private bool complete = false;
	public GameObject locked;

	private BoxCollider col;
	private MeshRenderer mesh;

	public static int countChambers = 1;
	private int chamberNumber = 0;

	public static bool doOnce = false;

	#region SingleTon

	private  Portals instance = null;

	public  Portals Instance {

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
		col = GetComponent<BoxCollider>();
		mesh = GetComponent<MeshRenderer>();
		col.enabled = true;
		chamberNumber = countChambers;
		countChambers++;
	}

	void Update () 

	{

		if (chamberNumber == 1 || chamberNumber < 1)
		{
			locked.SetActive (false);
		}

		if (doOnce == true)
		{
			chamberNumber = chamberNumber - 1;
			doOnce = false;
		}

		if (show == true)
		{
			mesh.enabled = true;
			if (complete == false)
			{
				col.enabled = true;
				if (chamberNumber > 1)
				{
					locked.SetActive (true);
				}
			}
		} 
		if (show == false) 
		{
			locked.SetActive (false);
			col.enabled = false;
			mesh.enabled = false;
		}

		if (complete == true)
		{
			locked.SetActive (false);
			col.enabled = false;
			doOnce = true;
		}

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			complete = true;
			mesh.material.SetColor("_Color", Color.magenta );
		}
	}
}
