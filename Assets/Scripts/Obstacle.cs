using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	void Start () {
        StartCoroutine(MakeInDestructible());
	}

    public IEnumerator MakeInDestructible()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.tag = "InDestructible";
    }
}
