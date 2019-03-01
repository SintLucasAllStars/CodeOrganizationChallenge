using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Evolution;
using Managers;

public class SpawnManager : MonoBehaviour
{
    public GameObject sphere;
    public GameObject cube;
    public GameObject capsule;

    public Creature[] creatures;

    bool gender;

    GameObject shape;

    string type;
    string behaviour;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        creatures = new Creature[10];

        for (int i = 0; i < 10; i++)
        {
            SetShape();
            SetType();
            SetBehaviour();
            SetGender();
            SetPosition();

            creatures[i] = new Creature(shape, type, behaviour, gender, pos);
        }

        StartCoroutine("SpawnFinished");
    }

    // Update is called once per frame
    void Update()
    {

        CreaturesState();
        
    }

    public void CreaturesState()
    {
        for (int i = 0; i < creatures.Length; i++)
        {
            creatures[i].ChooseState();
        }
    }

    private IEnumerator SpawnFinished()
    {
        yield return new WaitForSeconds(2);
        Managers.GameManager.waveSpawned = true;
    }

    private void SetShape()
    {
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            shape = sphere;
        }
        else if (i == 1)
        {
            shape = cube;
        }
        if (i == 2)
        {
            shape = capsule;
        }
    }

    private void SetType()
    {
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            type = "vertebrate";
        }
        else if (i == 1)
        {
            type = "insect";
        }
        if (i == 2)
        {
            type = "reptile";
        }
    }

    private void SetBehaviour()
    {
        int i = Random.Range(0, 4);
        if (i == 0)
        {
            behaviour = "aggrasive";
        }
        else if (i == 1)
        {
            behaviour = "passive";
        }
        if (i == 2)
        {
            behaviour = "slow";
        }
        if (i == 3)
        {
            behaviour = "fast";
        }
    }

    private void SetGender()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            gender = false;
        }
        else if (i == 1)
        {
            gender = true;
        }
    }

    private void SetPosition()
    {
        pos = new Vector3(Random.Range(50, 250), 0.5f, Random.Range(50, 250));
    }
}
