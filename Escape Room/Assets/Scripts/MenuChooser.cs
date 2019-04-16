using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuChooser : MonoBehaviour
{

    public Text n_Level, n_Events, n_Doors, t_CreateButtonText;
    public static int i_Level, i_Events, i_Doors;
    public static bool b_CanBeCreated;
    private bool b_LevelHigher, b_EventsHigher, b_DoorsHigher;
    public Button CreateButton;
    Color color_Red, color_Green;


    //
    //Writing the interger changers to the buttons.
    //
    #region LevelButton Up + Down
    public void LevelButtonClickUp()
    {
        i_Level++;
    }
    public void LevelButtonClickDown()
    {
        
        i_Level-= 1;
    }
    #endregion
    #region EventsButton Up + Down
    public void EventsButtonClickUp()
    {
        b_EventsHigher = true;
        i_Events++;
    }

    public void EventsButtonClickDown()
    {
        i_Events-= 1;
    }
    #endregion
    #region DoorsButton Up + Down
    public void DoorsButtonClickUp()
    {
        i_Doors++;
    }
         

    public void DoorsButtonClickDown()
    {
        i_Doors-= 1;
    }
    #endregion


    //
    //This is for the create button later in the script
    //
    public void Awake()
    {
        color_Red = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
        color_Green = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f);
        i_Doors = 0;
        i_Level = 0;
        i_Events = 0;
    }

    public void Update()
    {
        //
        //Connecting the ints to a visable text
        //
        n_Level.text = i_Level.ToString();
        n_Events.text = i_Events.ToString();
        n_Doors.text = i_Doors.ToString();

    }

    public void FixedUpdate()
    {
        //
        //Making a max and when its higher then the max it will go back to the lowest amount.
        //
        #region i_Level higher or lower.
        if (i_Level > 3)
        {
            i_Level = 0;
        }
        if (i_Level < 0)
        {
            i_Level = 3;
        }
        #endregion

        #region i_Events higher or lower.
        if (i_Events > 3)
        {
            i_Events = 0;
        }
        if (i_Events < 0)
        {
            i_Events = 3;
        }
        #endregion

        #region i_Doors higher or lower.
        if (i_Doors > 4)
        {
            i_Doors = 0;
        }
        if (i_Doors < 0)
        {
            i_Doors = 4;
        }
        #endregion

        //
        //Not available Rooms for the create button
        //
        if (i_Level == 0 && i_Events == 0 && i_Doors == 0)
        {
            t_CreateButtonText.text = "Can't Create";
            CreateButton.image.color = color_Red;
            b_CanBeCreated = false;
        }
        else if (i_Level == 3 && i_Events == 3 && i_Doors == 4)
        {
            t_CreateButtonText.text = "Can't Create";
            CreateButton.image.color = color_Red;
            b_CanBeCreated = false;
        }
        else
            CreateButton.image.color = color_Green;
            t_CreateButtonText.text = "Create";
            b_CanBeCreated = true;
    }
}
