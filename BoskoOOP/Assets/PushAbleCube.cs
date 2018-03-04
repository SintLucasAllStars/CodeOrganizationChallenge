using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAbleCube : MonoBehaviour {


	private MeshRenderer mesh;

	void Start ()
	{
		mesh = GetComponent<MeshRenderer>();
			int randomcolour;
			randomcolour = Random.Range (1, 4);
			if (randomcolour == 1) {
					mesh.material.SetColor("_Color", Color.cyan );
			}
			if (randomcolour == 2) {
					mesh.material.SetColor("_Color", Color.white );
			}
			if (randomcolour == 3) {
					mesh.material.SetColor("_Color", Color.yellow );
		}
	}
}
