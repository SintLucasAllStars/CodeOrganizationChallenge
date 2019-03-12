using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny
{
    GameObject go;

    public Vector3 speed;

    public int strength;

    public int mood;

    public bool hungry;

    public bool meeting = false;

  



    public Bunny(GameObject g)
    {

        

        go = GameObject.Instantiate(g);

        go.transform.position = new Vector3(Random.Range(-20,20), 3, Random.Range(-20,20));

        strength = Random.Range(1, 10);


        go.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);


    }


    public void Move()
    {   //  rb.AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * 100);

       // go.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), go.transform.position.y , Random.Range(-20.0f, 20.0f));
    }


    public IEnumerator movement()
    {

        while (true)
        {
            yield return new WaitForSeconds(1);
            if (meeting == true)
            {
                speed = new Vector3(0, 0, 0);
            }
            else
            {
                speed = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            }
        }

    }



    public void Meet()
    {
        mood = Random.Range(1, 10);

        if (mood % 2 == 0)
        {
            Debug.Log("FIGHT");
        }
        else
        {
            Debug.Log("BABY");
        }



    }


    public void Food()
    {


        if (hungry == true)
        {
            //eat
        }
        else
        {
            //dont eat
        }



    }




    
}
