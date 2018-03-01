using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour {

    void Start()
    {
       
    }
    void Update()
    {
     //   if (Input.GetKeyDown(KeyCode.A))
     //   {
            Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.lockState = CursorLockMode.None;  
      //  }
    }
}