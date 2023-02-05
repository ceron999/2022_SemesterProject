using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveDataClass
{
    ///세이브 데이터 필요한 경우
    ///     1. 처음 시작할 때 플레이하고 있는 날
    ///     2. 해당 날짜에 필수 스토리를 보았는가?
    ///     3. 각 퍼즐마다 클리어를 했는가?
    ///     4. 플레이어 말버릇, 영혼 이름
    ///     
    public bool isFirstPlay;
    public int startYear;
    public int startMonth;
    public int startDay;
    public int nowDay;
    public int startHour;
    public int startMinute;
    public int startSecond;
    public List<bool> isWatchDayStory;

    public List<bool> isPuzzleOpen;
    public List<bool> isClearPuzzle;

    //대화
    public string playerSpeechHabit;
    public string soulName;
    public string logWapperName;

    //선택지
    public string soulShape;
    public string perfumeScent;

    public SaveDataClass()
    {
        isFirstPlay = true;
        startYear = DateTime.Now.Year;
        startMonth = DateTime.Now.Month;
        startDay = DateTime.Now.Day;
        startHour= DateTime.Now.Hour;
        startMinute= DateTime.Now.Minute;
        startSecond= DateTime.Now.Second;
        nowDay = 1;
        isWatchDayStory = new List<bool>();
        for (int i = 0; i < 3; i++)
            isWatchDayStory.Add(false);

        isPuzzleOpen = new List<bool>();
        for (int i = 0; i < 8; i++)
            isPuzzleOpen.Add(false);

        isClearPuzzle = new List<bool>();
        for (int i = 0; i < 8; i++)
            isClearPuzzle.Add(false);

        playerSpeechHabit = "";
        soulName = "";
        logWapperName = "";

        soulShape = "";
        perfumeScent = "";
    }
}
