using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager2 : MonoBehaviour
{
    private static GameManager2 instance;
    public JsonManager jsonManager2;

    [HideInInspector]
    //시간 변수
    public Text counterText, wakeupDateText, wakeupTimeText, wakeupText;
    [HideInInspector] public TimeSpan spare;
    [HideInInspector] public DateTime midnightTime, standardTime, now;



    private void Start()
    {
        jsonManager2 = new JsonManager();
    }

    void Update()
    {
        Time();
    }

    void Time()
    {
        string standard = DateTime.Now.ToString("yyyy/MM/dd") + " 08:00"; // 오늘 오전 8시
        standardTime = Convert.ToDateTime(standard); //기준시간을 오늘날짜 오전 8시로 설정
        now = DateTime.Now; //현재시간

        int result = DateTime.Compare(DateTime.Now, standardTime);
        if (result >= 0)
        {  // 오전 8시 이후인 경우(영혼 기상 후)
            wakeupText.text = "취침 시간";
            wakeupTimeText.text = "00시"; //자정          
            wakeupDateText.text = now.AddDays(1).ToString("yyyy년 MM월 dd일"); // 기상날짜

            string midnight = now.AddDays(1).ToString("yyyy/MM/dd") + " 00:00"; // 자정
            midnightTime = Convert.ToDateTime(midnight);
            spare = midnightTime - now; //자정-현재시간
            counterText.text = "<color=#DC143C>" + spare.ToString(@"hh\:mm\:ss") + "</color>";
        }
        else
        { // 오전 8시 이전(영혼 취침 중)
            wakeupText.text = "기상 시간";
            wakeupTimeText.text = "08시";

            spare = standardTime - now;
            wakeupDateText.text = standardTime.ToString("yyyy년 MM월 dd일");
            counterText.text = "<color=#32CD32>" + spare.ToString(@"hh\:mm\:ss") + "</color>";
        }
    }

}