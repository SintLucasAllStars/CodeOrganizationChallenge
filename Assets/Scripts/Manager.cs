using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{


    public static Manager Instance;


    List<Creature> creatures;
    public GameObject prefab;
    public int initCreatures;


    private void Awake()
    {
        if (Instance == null)
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
            creatures.Add(new Creature(prefab, Random.Range(-20, 20), 0, Random.Range(-20, 20)));
        }
    }



    private void Update()
    {
        foreach (Creature c in creatures)
        {
            Vector3 ganaar = new Vector3(Random.Range(-1000, 1000), 0, Random.Range(-1000, 1000));
            c.Move(ganaar);
        }
    }


    public void RegisterCreature(Transform transform)
    {
        creatures.Add(new Creature(prefab, transform.position.x, transform.position.y, transform.position.z));
    }

   


}

