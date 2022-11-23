using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public JsonManager jsonManager;

    public string pastSceneName;
    public string setDialogueName;

    public bool isTalkTIme;

    public SaveDataClass saveData;

    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;    
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        jsonManager = new JsonManager();

        saveData = jsonManager.LoadSaveData();
        //SetSaveDataClear();
    }

    public void SetSaveDataClear()
    {
        saveData = new SaveDataClass();
        jsonManager.SaveJson(saveData, "SaveData");
        Debug.Log("clear");
    }

    public void SetIsWatchStory(string dialogueWrapperName)
    {
        switch(dialogueWrapperName)
        {
            case "Day1Story":
                saveData.isWatchDayStory[0] = true;
                break;
            case "Day2Story":
                saveData.isWatchDayStory[1] = true;
                break;
            case "Day3Story":
                saveData.isWatchDayStory[2] = true;
                break;
        }
    }

}
