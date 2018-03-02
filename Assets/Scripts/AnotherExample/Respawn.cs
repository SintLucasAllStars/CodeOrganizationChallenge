using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {
    public GameObject player;

    void OnCollisionEnter(Collision coll){
        if (coll.gameObject.tag == "Player")
            player.transform.position = new Vector3 (-13, 2, 0);

	}
}
