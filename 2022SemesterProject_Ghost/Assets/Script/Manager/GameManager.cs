using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public JsonManager jsonManager;

    public string pastSceneName;
    public string setDialogueName;

    public bool isTalkTIme;
    public bool isCustomizingEnd = false;

    public SaveDataClass saveData;

    public string puzzleImage;
    public int countCheck = 1;
    public string beforeSetDialogueName;
    public int puzzleArrayNum;
    public bool puzzleDialogue = false;
    [SerializeField]
    Text text;
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
        if (saveData == null)
        {
            text.text = "NULL";
            SetSaveDataClear();
        }
        else
        {
            text.text = saveData.isFirstPlay.ToString();
            text.text += "\n" + saveData.startMonth +"/"+ saveData.startDay +"\n"+ saveData.startHour+":"
                + saveData.startMinute;
            if(saveData.startMonth ==1 && saveData.startDay <30 && saveData.startYear==2023)
                SetSaveDataClear();
        }
        SetNowDay();
        SoundManager.instance.PlayBgm(BGM.Main);
    }

    //관리자용 함수
    public void SetSaveDataClear()
    {
        saveData = new SaveDataClass();
        jsonManager.SaveJson(saveData, "SaveData");
        Debug.Log("clear");
    }

    public void SetDay2()
    {
        saveData = new SaveDataClass();
        saveData = jsonManager.LoadSaveData();
        saveData.isFirstPlay = false;
        saveData.startYear = DateTime.Now.Year;
        saveData.startMonth = DateTime.Now.Month;
        saveData.startDay = DateTime.Now.Day;
        saveData.startHour = DateTime.Now.Hour;
        saveData.startMinute = DateTime.Now.Minute;
        saveData.startSecond = DateTime.Now.Second;
        saveData.isWatchDayStory[0] = true;

        saveData.playerSpeechHabit = "habit";
        saveData.soulName = "";

        saveData.soulShape = "곡선이 많다.";
        saveData.perfumeScent = "물향";

        saveData.isClearPuzzle[0] = true;
        saveData.isClearPuzzle[1] = true;
        saveData.isClearPuzzle[2] = true;

        jsonManager.SaveJson(saveData, "SaveData");
        Debug.Log("Set Day2 Clear");
    }

    public void SetDay3()
    {
        saveData = new SaveDataClass();

        saveData.isFirstPlay = false;
        saveData.startYear = DateTime.Now.Year;
        saveData.startMonth = DateTime.Now.Month;
        saveData.startDay = DateTime.Now.Day - 2;
        saveData.nowDay = 3;
        saveData.isWatchDayStory[0] = true;
        saveData.isWatchDayStory[1] = true;

        saveData.playerSpeechHabit = "habit";
        saveData.soulName = "";

        saveData.soulShape = "곡선이 많다.";
        saveData.perfumeScent = "물향";


        jsonManager.SaveJson(saveData, "SaveData");
        Debug.Log("Set Day3 Clear");
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

    void SetNowDay()
    {
        DateTime nowTime = DateTime.Now;
        DateTime startTime;

        startTime = new DateTime(saveData.startYear, saveData.startMonth, saveData.startDay);
        
        Debug.Log((nowTime - startTime).Days);

        switch (saveData.nowDay)
        {
            case 1:
                if (!saveData.isWatchDayStory[0])
                    return;
                if ((nowTime - startTime).Days >= 1)
                    saveData.nowDay = 2;
                break;
            case 2:
                if (!saveData.isWatchDayStory[1])
                    return;
                if ((nowTime - startTime).Days >= 2)
                    saveData.nowDay = 3;
                break;
            case 3:
                break;
        }
        jsonManager.SaveJson(saveData, "SaveData");
    }
    public void SetPuzzleStory()
    {
        //SceneManager.LoadScene("StoryScene");
    }

    public void SaveAllData()
    {
        jsonManager.SaveJson(saveData, "SaveData");
    }
}
