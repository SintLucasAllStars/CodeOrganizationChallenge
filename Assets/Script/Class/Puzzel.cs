using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzel{

    private string puzzelName;
    private bool puzzelCleared;

	public Puzzel(string pName)
    {
        puzzelName = pName;
    }

    //Get name for scene
    public string GetName()
    {
        return puzzelName;
    }

    //Set if the level is completed or not
    public void SetClear(bool cleared)
    {
        if (cleared)
        {
            PlayerPrefs.SetInt(puzzelName, 1);
        }
        else
        {
            PlayerPrefs.SetInt(puzzelName, 0);
        }
    }

    //readonly: check if this level is cleared
    public bool GetClear()
    {
        if(PlayerPrefs.GetInt(puzzelName) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
