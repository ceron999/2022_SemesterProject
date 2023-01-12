using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeCheckManager : MonoBehaviour
{
    [SerializeField]
    Text counterText;
    [SerializeField] 
    Text wakeupDateText;
    [SerializeField] 
    Text wakeupTimeText;
    [SerializeField] 
    Text wakeupText;


    [HideInInspector]
    public TimeSpan spare;
    public DateTime midnightTime;
    public DateTime standardTime;
    public DateTime nowTime;

    private void Start()
    {
        GameManager.Instance.isTalkTIme = false;
        SetTImeText();
    }

    void Update()
    {
        SetSpareTime();
    }

    void SetTImeText()
    {
        string standard = DateTime.Now.ToString("yyyy/MM/dd") + " 08:00"; // 오늘 오전 8시
        standardTime = Convert.ToDateTime(standard); //기준시간을 오늘날짜 오전 8시로 설정
        nowTime = DateTime.Now; //현재시간

        int result = DateTime.Compare(nowTime, standardTime);
        if (result >= 0)
        {  // 오전 8시 이후인 경우(영혼 기상 후)
            GameManager.Instance.isTalkTIme = true;

            wakeupText.text = "취침 시간";
            wakeupTimeText.text = "00시"; //자정          
            wakeupDateText.text = nowTime.AddDays(1).ToString("yyyy년 MM월 dd일"); // 기상날짜

            string midnight = nowTime.AddDays(1).ToString("yyyy/MM/dd") + " 00:00"; // 자정 설정
            midnightTime = Convert.ToDateTime(midnight);
        }
        else
        { // 오전 8시 이전(영혼 취침 중)
            GameManager.Instance.isTalkTIme = false;

            wakeupText.text = "기상 시간";
            wakeupTimeText.text = "08시";
            wakeupDateText.text = standardTime.ToString("yyyy년 MM월 dd일");
        }
    }

    void SetSpareTime()
    {

        nowTime = DateTime.Now; //현재시간

        int result = DateTime.Compare(DateTime.Now, standardTime);
        if (result >= 0)
        {  // 오전 8시 이후인 경우(영혼 기상 후)

            spare = midnightTime - nowTime; //자정-현재시간
            counterText.text = "<color=#DC143C>" + spare.ToString(@"hh\:mm\:ss") + "</color>";
        }
        else
        { // 오전 8시 이전(영혼 취침 중)
            spare = standardTime - nowTime;
            counterText.text = "<color=#32CD32>" + spare.ToString(@"hh\:mm\:ss") + "</color>";
        }
    }
}
