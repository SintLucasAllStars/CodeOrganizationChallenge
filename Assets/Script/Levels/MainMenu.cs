using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : TimerOnTrigger {

    public string[] levelsName;

    Puzzel[] puzzelList;

    GameObject panel;
    public GameObject buttonPrefab;
    public Button[] buttonList;


    GameManager GM;

    /*
    *   summary
    *   This is the menuscript it deals everyting with changing levels
    */


    private void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        panel = GameObject.Find("Panel");
        RecieveComponents();

        //setting up puzzels
        puzzelList = new Puzzel[levelsName.Length];
        for (int i = 0; i < levelsName.Length; i++)
        {
            puzzelList[i] = new Puzzel(levelsName[i]);
        }

        buttonList = new Button[levelsName.Length];
        Debug.Log(puzzelList[0].GetName());
    }

    // Update is called once per frame
    void Update ()
    {

        if (doneTime)
        {
            GM.levelList = new Puzzel[levelsName.Length];
            panel.SetActive(true);

            //gives GameManager the puzzels
            if (GM.levelList[0] == null)
            {
                for (int i = 0; i < levelsName.Length; i++)
                {
                    GM.levelList[i] = puzzelList[i];
                }
            }

            //Create buttons for levelselector
            if(buttonList[0] == null)
            {
                for (int i = 0; i < levelsName.Length; i++)
                {
                    CreatingButton(i);
                    buttonList[0].interactable = true;
                }
            }

        }
		
	}


    void CreatingButton(int index)
    {
        buttonList[index] = Instantiate(buttonPrefab).GetComponent<Button>();
        buttonList[index].transform.SetParent(panel.transform);
        
        buttonList[index].GetComponentInChildren<Text>().text = puzzelList[index].GetName();
        buttonList[index].onClick.AddListener(delegate {ChangeScene(puzzelList[index].GetName()); });

        if(PlayerPrefs.GetInt(puzzelList[index].GetName()) == 0)
        {
            buttonList[index].interactable = false;
        }
    }

    public void ChangeScene(string sceneName)
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.FadeIn();
        Debug.Log("Changing scene!");
        SceneManager.LoadSceneAsync(sceneName);

    }
}
