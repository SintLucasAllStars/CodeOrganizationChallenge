using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{

	public static CreatureManager Instance;
	public GameObject prefab;
	public int initCreatures;

	List<Creature> creatures;
		
	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(this);
		}
	}

	private void Start()
	{
		creatures = new List<Creature>();
		for (int i = 0; i < initCreatures; i++)
		{
			creatures.Add(new Creature(prefab, Random.Range(-1,1),Random.Range(-1,1)));

		}
	}

	private void Update()
	{
		for (int i = 0; i < creatures.Count; i++)
		{
			creatures[i].Step();
			creatures[i].age++;
			if(creatures[i].age > 2000 || creatures.Count > 75)
			{
				print(" Death " + i);

				Destroy(creatures[i].go);
				creatures.RemoveAt(i);
			}
			for (int ii = 0; ii < creatures.Count; ii++)
			{
				if (i != ii && creatures[i].age > 500 && creatures[ii].age > 500)
				{
					if (Vector2.Distance(creatures[i].position, creatures[ii].position) < 0.075)
					{
						print("Birth");
						Vector2 placeOfBirth = new Vector2(creatures[i].position.x, creatures[i].position.y);

						creatures.Add(new Creature(prefab, placeOfBirth.x, placeOfBirth.y, creatures[i], creatures[ii]));
					}
				}
			}
		}
	}

	public void RegisterCreature(Transform transform)
	{
		creatures.Add(new Creature(prefab, transform.position.x, transform.position.y));
	}
}
