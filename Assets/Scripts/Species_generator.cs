using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Species_generator : MonoBehaviour
{
    public string species_name;
    public string actual_diet;
    public string actual_form;

    public bool aggresive;
    public bool female;

    Creature_AI CS;

    public string[] species;
    public string[] diet;
    public string[] forms;

    MeshFilter chosen_form;


    void Start()
    {
        CS = this.GetComponent<Creature_AI>();
        Generate_species_kind();
        chosen_form = this.GetComponent<MeshFilter>();
        if(actual_form == "Cube")

        {
            this.gameObject.AddComponent<BoxCollider>();
        }
        if (actual_form == "Sphere")

        {
            this.gameObject.AddComponent<SphereCollider>();
        }
        if (actual_form == "Capsule")

        {
            this.gameObject.AddComponent<CapsuleCollider>();
        }
        if (actual_form == "Cylinder")

        {
            this.gameObject.AddComponent<CapsuleCollider>();
        }
        if (this.gameObject.name == "Born_creature(Clone)")
        {

        }
    }
    void Update()
    {
      //chosen_form.mesh 
    }
    void Generate_species_kind()
    {
        int random_name = Random.Range(0, 7);
        species_name = species[random_name];

        int random_diet = Random.Range(0, 2);
        actual_diet = diet[random_diet];

        int random_form = Random.Range(0, 4);
        actual_form = forms[random_form];

        int t_o_n = Random.Range(0, 2);
        if(t_o_n == 0)
        {
            aggresive = false;
        }
        else
        {
            aggresive = true;
            CS.Attack_Power += Random.Range(1, 4);
            CS.Defence_Power += Random.Range(0, 3);
        }

        int gender = Random.Range(0, 2);
        if(gender == 0)
        {
            female = false;
        }
        else
        {
            female = true;
        }
    }
}