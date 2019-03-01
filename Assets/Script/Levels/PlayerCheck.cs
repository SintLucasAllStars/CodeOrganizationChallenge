using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : TimerOnTrigger {


    private void Awake()
    {
        RecieveComponents();
    }



    private void OnTriggerExit(Collider other)
    {
        doneTime = false;
    }
}
