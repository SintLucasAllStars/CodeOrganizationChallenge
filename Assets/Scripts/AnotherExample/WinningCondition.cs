using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour {

    void OnCollisionEnter(Collision coll){
        if (coll.gameObject.tag == "Player")
        GameObject.Find("MainController").GetComponent<MainScript>().FinishPuzzle("AnotherExample");
	}
}
