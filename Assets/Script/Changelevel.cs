using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Changelevel : MonoBehaviour {

    public string levelName;

    public string defaultText;
    public TextMesh _textTimer;
    public float _timer;

    /*
    *   summary
    *   This is the menuscript it deals everyting with changing levels
    */

    // Use this for initialization
    private void Awake()
    {
        _textTimer = GetComponentInChildren<TextMesh>();
        Debug.Log(_textTimer);
        defaultText = _textTimer.text;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        _timer = 3;
    }

    protected virtual void OnTriggerStay(Collider other)
    {

        Debug.Log("Player entered the trigger");
        _timer -= Time.deltaTime;

        _textTimer.text = Mathf.Round(_timer).ToString();

        if (_timer <= 0)
        {
            SceneManager.LoadSceneAsync(levelName);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        _timer = 3;
        _textTimer.text = defaultText;
    }
}
