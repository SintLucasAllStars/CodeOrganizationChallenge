using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour {
	public float strength;
	public float speed;
	public float health;
	public float Cstrength;
	public float Cspeed;
	public float Chealth;
	public float Movementspeed;
	public GameObject Beasts;
	int chanchelook;
	int fightpoints;
	bool baby = false;


	// Use this for initialization
	void Start () {
		Vector3 euler = transform.eulerAngles;
		euler.y = Random.Range(-360f, 360f);
		transform.eulerAngles = euler;

		if (!baby) {
			strength = Random.Range (1, 10);
			health = Random.Range (1, 10);
		}
	}
	
	// Update is called once per frame
	void Update () {

	

		speed = 20 - (health + strength);

		chanchelook--;
		if (chanchelook == 0) {
			transform.RotateAround (transform.position, transform.up, Random.Range (-50, 50));
			chanchelook = Random.Range (50, 100);
		}

		Movementspeed = speed / 100;
		transform.localScale = new Vector3(speed, health, strength);
		transform.Translate (Movementspeed, 0, 0);
	}
	void OnCollisionEnter(Collision CEnter) {
		if (CEnter.gameObject.CompareTag ("wall")) {
			transform.RotateAround (transform.position, transform.up, 180f);
		}
		if (CEnter.gameObject.CompareTag ("Beast")) {
			Cstrength = CEnter.gameObject.GetComponent<Evolution> ().strength;
			Chealth = CEnter.gameObject.GetComponent<Evolution> ().health;
			Cspeed = CEnter.gameObject.GetComponent<Evolution> ().speed;
			if (Cstrength < strength) {
				fightpoints++;
			}
			if (Chealth < health) {
				fightpoints++;
			}
			if (Cspeed < speed) {
				fightpoints++;
			}
			if (fightpoints == 2) {
				Destroy(CEnter.gameObject);
				fightpoints = 0;
			}
			if (Cstrength == strength) {
				GameObject baby = Instantiate(Beasts, new Vector3(Random.Range(-90, 90), 10,Random.Range(-90, 90)), Quaternion.identity);
				Evolution babyStats = baby.GetComponent<Evolution> ();
				babyStats.health = (Chealth + health) / 2;
				babyStats.strength = (Cstrength + strength) / 2;
				babyStats.baby = true;

			}
			if (Chealth == health) {
				GameObject baby = Instantiate(Beasts, new Vector3(Random.Range(-90, 90), 10,Random.Range(-90, 90)), Quaternion.identity);
				Evolution babyStats = baby.GetComponent<Evolution> ();
				babyStats.health = (Chealth + health) / 2;
				babyStats.strength = (Cstrength + strength) / 2;
				babyStats.baby = true;
			}
			if (Cspeed == speed) {
				GameObject baby = Instantiate(Beasts, new Vector3(Random.Range(-90, 90), 10,Random.Range(-90, 90)), Quaternion.identity);
				Evolution babyStats = baby.GetComponent<Evolution> ();
				babyStats.health = (Chealth + health) / 2;
				babyStats.strength = (Cstrength + strength) / 2;
				babyStats.baby = true;
			}

		}
	}
}
