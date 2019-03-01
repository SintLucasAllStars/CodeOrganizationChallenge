using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

    public static GameManager instance;

    public Puzzel[] levelList;
    public int puzzelIndex;
    Animation fadeAnim;
    PlayerCheck[] playerCheck = new PlayerCheck[2];
    public Transform panel;


    private void Awake()
    {
        //singleton
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () 
	{
        fadeAnim = GameObject.Find("Fade").GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        SceneManager.sceneLoaded += OnSceneLoaded;

        //looks for the script in the level
        if(FindObjectOfType<PlayerCheck>() != null)
        {
            //gets components
            for (int i = 0; i < 2; i++)
            {
                playerCheck = FindObjectsOfType<PlayerCheck>();
            }

            //Remeber that the level is completed and load next level
            if(playerCheck[0].doneTime && playerCheck[1].doneTime)
            {
                FadeIn();
                //if it is the last level you go back to choosing levels
                if(levelList.Length == puzzelIndex)
                {
                    SceneManager.LoadSceneAsync("LevelChoose");
                }
                else
                {
                    levelList[puzzelIndex].SetClear(true);
                    SceneManager.LoadSceneAsync(levelList[puzzelIndex++].GetName());
                    
                }

            }
        }
        else
        {
            //Remember every level that is completed
            foreach (Puzzel p in levelList)
            {
                if (p.GetClear())
                {
                    PlayerPrefs.SetInt(p.GetName(), 1);
                }
            }

        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Finding out which index this level is");
        for (int i = 0; i < levelList.Length; i++)
        {
            if(levelList[i].GetName() == scene.name)
            {
                puzzelIndex = i;
            }
        }

        
        panel = GameObject.Find("Panel").GetComponent<Transform>();
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }
    }

    public void FadeIn()
    {
        fadeAnim.Play("FadeIn");
    }
}