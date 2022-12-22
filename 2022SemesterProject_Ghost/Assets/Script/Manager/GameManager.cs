using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public JsonManager jsonManager;

    [HideInInspector]
    //시간 변수

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
<<<<<<< Updated upstream
=======

        saveData = jsonManager.LoadSaveData();
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

        saveData.isFirstPlay = false;
        saveData.startYear = DateTime.Now.Year;
        saveData.startMonth = DateTime.Now.Month;
        saveData.startDay = DateTime.Now.Day - 1;
        saveData.nowDay = 2;
        saveData.isWatchDayStory[0] = true;

        saveData.playerSpeechHabit = "habit";
        saveData.soulName = "";

        saveData.soulShape = "곡선이 많다.";
        saveData.perfumeScent = "물향";


        jsonManager.SaveJson(saveData, "SaveData");
        Debug.Log("Set Day2 Clear");
>>>>>>> Stashed changes
    }
}
