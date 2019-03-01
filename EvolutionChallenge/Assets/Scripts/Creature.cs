using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Evolution
{
    public class Creature : MonoBehaviour
    {
        GameObject go;

        Color col;

        int state;

        SpawnManager sMan;

        Creature target;

        //General variables
        public float cSpeed;
        public string cType;
        public bool cGender;

        //Vertebrate variables
        float vStamina = 100;
        float vWaitTime;
        bool vTimer = false;
        Vector3 vDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

        public Creature(GameObject shape, string type, string behaviour, bool gender, Vector3 spawnPos)
        {
            go = GameObject.Instantiate(shape);
            go.transform.position = spawnPos;
            sMan = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

            cType = type;
            cGender = gender;

            SetSpeed(type, gender);
            SetColor(gender, type);
        }

        public void Update()
        {
            ChooseState();
            Debug.Log("y dont you work");
        }

        public void SetSpeed(string type, bool gender)
        {
            if (gender == false)
            {
                if (type == "vertebrate")
                {
                    cSpeed = 4;
                }
                else if (type == "insect")
                {
                    cSpeed = 3;
                }
                else if (type == "reptile")
                {
                    cSpeed = 1.5f;
                }
            }

            if (gender == true)
            {
                if (type == "vertebrate")
                {
                    cSpeed = 5;
                }
                else if (type == "insect")
                {
                    cSpeed = 4;
                }
                else if (type == "reptile")
                {
                    cSpeed = 2.5f;
                }
            }
        }

        private void SetColor(bool gender, string type)
        {
            if (gender == false)
            {
                if (type == "vertebrate")
                {
                    col = new Color(Random.Range(155f, 255f) / 255, Random.Range(0f, 200f) / 255, Random.Range(0f, 200f) / 255);
                }
                else if (type == "insect")
                {
                    col = new Color(Random.Range(0f, 200f) / 255, Random.Range(155f, 255f) / 255, Random.Range(0f, 200f) / 255);
                }
                else if (type == "reptile")
                {
                    col = new Color(Random.Range(0f, 200f) / 255, Random.Range(0f, 200f) / 255, Random.Range(155f, 255f) / 255);
                }
            }

            if (gender == true)
            {
                if (type == "vertebrate")
                {
                    col = new Color(Random.Range(0f, 155f) / 255, Random.Range(0f, 200f) / 255, Random.Range(0f, 200f) / 255);
                }
                else if (type == "insect")
                {
                    col = new Color(Random.Range(0f, 200f) / 255, Random.Range(0f, 155f) / 255, Random.Range(0f, 200f) / 255);
                }
                else if (type == "reptile")
                {
                    col = new Color(Random.Range(0f, 200f) / 255f, Random.Range(0f, 200f) / 255, Random.Range(0f, 155f) / 255);
                }
            }

            go.gameObject.GetComponent<Renderer>().material.color = col;
        }

        public void ChooseState()
        {
            switch (state)
            {
                case 2: //Following
                    Chase(cType, cSpeed, target);
                    break;
                case 1: //Moving
                    Move(cType, cSpeed);
                    break;
                default: //Idle
                    state = 1;
                    break;
            }
        }

        public void Move(string type, float speed)
        {
            if (type == "vertebrate")
            {
                if (vStamina > 0)
                {
                    go.transform.position += vDirection * speed * Time.deltaTime;
                    vStamina = vStamina - 10 * Time.deltaTime;
                }
                else if (vStamina < 0)
                {
                    if (vTimer == false)
                    {
                        vWaitTime = Time.time + Random.Range(2, 7);
                        vTimer = true;
                    }
                    else if (Time.time > vWaitTime)
                    {
                        vDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                        vStamina = 100;
                        vTimer = false;
                    }
                }
            }
            else if (type == "insect")
            {

            }
            else if (type == "reptile")
            {

            }

            foreach (Creature c in sMan.creatures)
            {
                if (GameManager.waveSpawned == true)
                {
                    float dist = Vector3.Distance(c.go.transform.position, go.transform.position);
                    Debug.Log(dist);
                    if (dist < 5)
                    {
                        target = c;
                        state = 2;
                    }

                    else
                    {
                        state = 1;
                    }
                }
            }
        }

        public void Chase(string type, float speed, Creature chaseTarget)
        {
            if (cGender == true)
            {
                if (type == chaseTarget.cType)
                {
                    if (chaseTarget.cGender == false)
                    {
                        go.transform.position = Vector3.MoveTowards(go.transform.position, chaseTarget.go.transform.position, speed);
                    }

                    else
                    {
                        if (type == "insect")
                        {

                        }
                    }
                }
            }
        }
    }
}

