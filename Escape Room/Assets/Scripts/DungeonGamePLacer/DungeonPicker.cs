using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPicker : MonoBehaviour
{
    public GameObject cameraAndArrowAngle;
    public GameObject[] plus = new GameObject[4];
    public GameObject DungeonPuzzlePfb, DungeonSkillLvlPfb, DungeonLootPfb;
    Color green = Color.green;
    Color red = Color.red;
    Color yellow = Color.yellow;
    public MeshRenderer p1, p2, p3, p4;
    public int choosen;
    public int dungeonChoosen;
    bool placed;
    // Start is called before the first frame update
    void Start()
    {
        Startup();
    }

    // Update is called once per frame
    void Update()
    {
        Chooser();
        Building();
        //DungeonChooser1ButtonClick();
        //DungeonChooser2ButtonClick();
        //DungeonChooser3ButtonClick();
        //DungeonChooser4ButtonClick();
    }




    void Startup()
    {
        dungeonChoosen = 1;
        choosen = 0;
        p1.material.color = yellow;
        p2.material.color = yellow;
        p3.material.color = yellow;
        p4.material.color = yellow;
    }


    void Isplaced()
    {
        if(placed == true)
        {
            cameraAndArrowAngle.transform.position = plus[choosen].transform.position;
            placed = false;
        }
    }

    #region Dungeon Chooser UI Button Click
    void DungeonChooser1ButtonClick()
    {
        dungeonChoosen = 1;
    }

    void DungeonChooser2ButtonClick()
    {
        dungeonChoosen = 2;
    }

    void DungeonChooser3ButtonClick()
    {
        dungeonChoosen = 3;
    }

    void DungeonChooser4ButtonClick()
    {
        dungeonChoosen = 4;
    }

    #endregion

    void Building()
    {
        
        if(Input.GetKeyDown(KeyCode.P) && choosen == 1 && dungeonChoosen == 1)
        {
            Instantiate(DungeonPuzzlePfb, plus[0].transform.position, plus[0].transform.rotation);
            placed = true;
            Isplaced();
        }

        if (Input.GetKeyDown(KeyCode.P) && choosen == 2 && dungeonChoosen == 1)
        {
            Instantiate(DungeonPuzzlePfb, plus[1].transform.position, plus[1].transform.rotation);
            placed = true;
            Isplaced();
        }

        if (Input.GetKeyDown(KeyCode.P) && choosen == 3 && dungeonChoosen == 1)
        {
            Instantiate(DungeonPuzzlePfb, plus[2].transform.position, plus[2].transform.rotation);
            placed = true;
            Isplaced();
        }

        if (Input.GetKeyDown(KeyCode.P) && choosen == 4 && dungeonChoosen == 1)
        {
            Instantiate(DungeonPuzzlePfb, plus[3].transform.position, plus[3].transform.rotation);
            placed = true;
            Isplaced();
        }
    }

    void Chooser()
    {
        if (Input.GetKey(KeyCode.W))
        {
            choosen = 1;
        }
        if (choosen == 1)
        {
            p1.material.color = green;
            p2.material.color = yellow;
            p3.material.color = yellow;
            p4.material.color = yellow;
        }

        if (Input.GetKey(KeyCode.A))
        {
            choosen = 2;
        }
        if (choosen == 2)
        {
            p1.material.color = yellow;
            p2.material.color = green;
            p3.material.color = yellow;
            p4.material.color = yellow;
        }


        if (Input.GetKey(KeyCode.S))
        {
            choosen = 3;
        }
        if (choosen == 3)
        {
            p1.material.color = yellow;
            p2.material.color = yellow;
            p3.material.color = green;
            p4.material.color = yellow;
        }

        if (Input.GetKey(KeyCode.D))
        {
            choosen = 4;
        }
        if (choosen == 4)
        {
            p1.material.color = yellow;
            p2.material.color = yellow;
            p3.material.color = yellow;
            p4.material.color = green;
        }
    }
}