using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices.ComTypes;

public class TimeCheckManager : MonoBehaviour
{
    [SerializeField]
    GameObject soul;
    [SerializeField] 
    Text typingText;
    [SerializeField] 
    Text blinkTextObject;
    [SerializeField] 
    Text counterText;


    [HideInInspector]
    public TimeSpan spare;
    public DateTime startTime;
    public DateTime nowTime;
    bool isSoulGone = false;

    private void Start()
    {
        if (GameManager.Instance.saveData.isWatchDayStory[2])
            GameClear();
        TypingText();
        BlinkText();
        SetCounterTime();
    }

    void Update()
    {
        SetCounterTimeText();
    }

    void SetCounterTime()
    {
        int year = GameManager.Instance.saveData.startYear;
        int month = GameManager.Instance.saveData.startMonth;
        int day = GameManager.Instance.saveData.startDay;
        int hour = GameManager.Instance.saveData.startHour;
        int minute = GameManager.Instance.saveData.startMinute;
        int second = GameManager.Instance.saveData.startSecond;
        startTime = new DateTime(year, month, day, hour, minute, second);
    }

    void SetCounterTimeText()
    {
        spare = DateTime.Now - startTime;
        counterText.text = spare.ToString(@"hh\:mm\:ss");
    }

    void TypingText()
    {
        typingText.text = "";
        string text = "안녕, 기다렸어!\n보러와줘서 고마워!";
        StartCoroutine(TypingTextCoroutine(text));
    }

    IEnumerator TypingTextCoroutine(string getString)
    {
        for (int i = 0; i < getString.Length; i++)
        {
            typingText.text += getString[i];
            yield return new WaitForSeconds(0.05f);
        }
    }

    void BlinkText()
    {
        StartCoroutine(BlinkTextCoroutine());
    }
    IEnumerator BlinkTextCoroutine()
    {
        while (true)
        {
            blinkTextObject.color = new Color(255 / 255f, 217 / 255f, 102 / 255f, 1);
            yield return new WaitForSeconds(1f);
            blinkTextObject.color = new Color(255 / 255f, 217 / 255f, 102 / 255f, 0);
            yield return new WaitForSeconds(0.2f);
        }
    }

    void GameClear()
    {
        if (GameManager.Instance.saveData.isWatchDayStory[2])
        {
            //isSoulGone = true;
            //Destroy(soul);
            //Destroy(wakeupDateText);
            //Destroy(wakeupTimeText);

            typingText.text = "영혼이 떠났다...";
            //Destroy(counterText);
        }
    }
}
