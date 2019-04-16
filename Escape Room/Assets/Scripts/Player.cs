using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(0.1f, 0, 0) * Time.deltaTime * 40);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(-0.1f, 0, 0) * Time.deltaTime * 40);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, 0, 0.1f) * Time.deltaTime * 40);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, 0, -0.1f) * Time.deltaTime * 40);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0.1f, 0, 0) * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(-0.1f, 0, 0) * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, 0.1f) * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, -0.1f) * Time.deltaTime * 10);
        }
    }
}
