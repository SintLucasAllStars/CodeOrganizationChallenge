using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour {

	public static bool show = true;
	private BoxCollider col;
	private MeshRenderer mesh;

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
	}

	void Update () 

	{
		if (show == true) {
			col.enabled = true;
			mesh.enabled = true;
		} 
		if (show == false) {
			col.enabled = false;
			mesh.enabled = false;
		}
	}
}
