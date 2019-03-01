using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerOnTrigger : MonoBehaviour {

    public float timer;
    public bool doneTime;

    [HideInInspector]
    string defaultText;
    TextMesh _textTimer;
    GameManager GM;


    /*
     * summary:
     * base class of changing levels
    */

    public void RecieveComponents()
    {
        _textTimer = GetComponentInChildren<TextMesh>();
        defaultText = _textTimer.text;
    }

    protected virtual void OnTriggerEnter(Collider col)
    {
        timer = 3;
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        timer -= Time.deltaTime;


        if (timer <= 0)
            doneTime = true;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            _textTimer.text = Mathf.Round(timer).ToString();
        }
        else
        {
            _textTimer.text = defaultText;
        }
    }

}
