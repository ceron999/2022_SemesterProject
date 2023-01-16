using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BtnManager : MonoBehaviour
{
    [SerializeField]
    GameObject fadeCanvas;

    //MainSceneBtn
    public void TouchStartBtn()
    {
        SoundManager.Instance.PlaySound1();
        StartCoroutine(TouchStartBtnCoroutine());

    }

    IEnumerator TouchStartBtnCoroutine()
    {
        if (GameManager.Instance.saveData.isFirstPlay)
        {
            GameManager.Instance.saveData.isFirstPlay = false;
            //처음 시작한 날 저장
            GameManager.Instance.saveData.startYear = DateTime.Now.Year;
            GameManager.Instance.saveData.startMonth = DateTime.Now.Month;
            GameManager.Instance.saveData.startDay = DateTime.Now.Day;
            GameManager.Instance.setDialogueName = "Day1Encounter";

            UIFadeModule screenFadeModule = fadeCanvas.GetComponent<UIFadeModule>();
            screenFadeModule.ScreenFade(0, 1, 1);
            yield return new WaitForSeconds(1);

            SceneManager.LoadScene("StoryScene");
        }
        else
        {
            UIFadeModule screenFadeModule = fadeCanvas.GetComponent<UIFadeModule>();
            screenFadeModule.ScreenFade(0, 1, 1);
            yield return new WaitForSeconds(1);
            //if(대화가 가능한 시간이 되었다면)
            SceneManager.LoadScene("WaitingScene");
        }
    }

    //WaitingSceneBtn
    public void TouchWaitingSceneSoulBtn()
    {
        SoundManager.Instance.PlaySound1();
        if (GameManager.Instance.isTalkTIme == true)
        {
            //만약 그 날짜의 스토리를 보지 않았다면 스토리씬으로
            int nowDay = GameManager.Instance.saveData.nowDay;
            if (GameManager.Instance.saveData.isWatchDayStory[nowDay - 1] == false
                    && GameManager.Instance.isTalkTIme)
            {
                switch (nowDay)
                {
                    case 1:
                        GameManager.Instance.setDialogueName = "Day1Story";
                        SceneManager.LoadScene("StoryScene");
                        break;
                    case 2:
                        GameManager.Instance.setDialogueName = "Day2Story";
                        SceneManager.LoadScene("StoryScene");
                        break;
                    case 3:
                        GameManager.Instance.setDialogueName = "Day3Story";
                        SceneManager.LoadScene("StoryScene");
                        break;
                }
            }
            else
            {
                Debug.Log("Day" + nowDay + " 스토리 진행 끝남");
                SceneManager.LoadScene("RoomScene");
            }
        }
        else
        {
            //아니면
            SceneManager.LoadScene("RoomScene");
        }
    }

    public void TouchGalleryBtn()
    {
        SoundManager.Instance.PlaySound3();
        SceneManager.LoadScene("GalleryScene");
    }

    public void TouchExitBtn()
    {
        //영혼과 잠시 멀어지겠습니까? yes/no 선택 후 이동 어디로?@@@@@@@@
    }

    //RoomSceneBtn
    public void TouchInteriorObjectBtn()
    {
        SoundManager.Instance.PlaySound2();
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("PuzzleScene");
    }

    //GallerySceneBtn
    public void TouchHomeBtn()
    {
        SoundManager.Instance.PlaySound3();
        SceneManager.LoadScene("WaitingScene");
    }

    public void TouchPuzzleBtn()
    {
        SoundManager.Instance.PlaySound1();
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("PuzzleScene");
    }

    //PuzzleSceneBtn
    public void TouchPuzzleExitBtn()
    {
        switch(GameManager.Instance.pastSceneName)
        {
            case "RoomScene":
                SceneManager.LoadScene("RoomScene");
                break;
            case "GalleryScene":
                SceneManager.LoadScene("GalleryScene");
                break;
        }
    }

    //CustomizingSceneBtn
    public void TouchTempBtn()
    {
        GameManager.Instance.isCustomizingEnd = true;
        SceneManager.LoadScene("StoryScene");
    }
}
