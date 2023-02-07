using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BtnManager : MonoBehaviour
{
    [SerializeField]
    GameObject dialogueLogParent;
    [SerializeField]
    GameObject fadeCanvas;
    [SerializeField]
    GameObject customizingPrefab;

    //MainSceneBtn
    public void TouchStartBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.OpenDoorSound);
        StartCoroutine(TouchStartBtnCoroutine());
    }

    IEnumerator TouchStartBtnCoroutine()
    {
        if (GameManager.Instance.saveData.isFirstPlay)
        {
            //처음 시작한 날 저장
            GameManager.Instance.SetSaveDataClear();
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
        SoundManager.instance.PlaySoundEffect(SoundEffect.WaterDrop1);

        //수정판
        if (!GameManager.Instance.saveData.isWatchDayStory[0])
        {
            GameManager.Instance.setDialogueName = "Day1Story";
            SceneManager.LoadScene("StoryScene");
        }
        else if(!GameManager.Instance.saveData.isWatchDayStory[1])
        {
            for(int i =0; i<4; i++)
            {
                if (!GameManager.Instance.saveData.isClearPuzzle[i])
                {
                    SceneManager.LoadScene("RoomScene");
                    return;
                }
            }

            GameManager.Instance.saveData.nowDay = 2;
            GameManager.Instance.setDialogueName = "Day2Story";
            GameManager.Instance.SaveAllData();
            SceneManager.LoadScene("StoryScene");
        }
        else if(!GameManager.Instance.saveData.isWatchDayStory[2])
        {
            for (int i = 4; i < 8; i++)
            {
                if (!GameManager.Instance.saveData.isClearPuzzle[i])
                {
                    SceneManager.LoadScene("RoomScene");
                    return;
                }
            }

            GameManager.Instance.saveData.nowDay = 3;
            GameManager.Instance.setDialogueName = "Day3Story";
            GameManager.Instance.SaveAllData();
            SceneManager.LoadScene("StoryScene");
        }
    }

    public void TouchGalleryBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        SoundManager.instance.SetBGMVolume(0.6f, 1);
        SoundManager.instance.PlayBgm(BGM.Gallery);
        SceneManager.LoadScene("GalleryScene");
    }

    public void TouchExitBtn()
    {
        //영혼과 잠시 멀어지겠습니까? yes/no 선택 후 이동 어디로?@@@@@@@@
        Application.Quit();
    }

    //RoomSceneBtn
    public void TouchRoomHomeBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        SceneManager.LoadScene("WaitingScene");
    }

    public void TouchDialogueLogBtn()
    {
        dialogueLogParent.SetActive(true);

        //텍스트 나오게 하기
    }

    public void TouchDialogueLogExitBtn()
    {
        dialogueLogParent.SetActive(false);
    }

    public void TouchInteriorObjectBtnlight1()
    {
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        int nowDay = GameManager.Instance.saveData.nowDay;
        if (!GameManager.Instance.saveData.isClearPuzzle[0])
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Rectangular";
            GameManager.Instance.beforeSetDialogueName = "Day1PastLifePuzzle2";
            GameManager.Instance.puzzleArrayNum = 0;
        }
        else if (!GameManager.Instance.saveData.isClearPuzzle[4] && nowDay == 2) 
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Sherlock";
            GameManager.Instance.beforeSetDialogueName = "Day2PastLifePuzzle";
            GameManager.Instance.puzzleArrayNum = 4;
        }
        SoundManager.instance.PlaySoundEffect(SoundEffect.WaterDrop2);
        SceneManager.LoadScene("PuzzleScene");
    }
    public void TouchInteriorObjectBtnlight2()
    {
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        int nowDay = GameManager.Instance.saveData.nowDay;
        if (!(GameManager.Instance.countCheck < (3 * nowDay + 2) && GameManager.Instance.countCheck >1))
            GameManager.Instance.countCheck = 2;
        for (int i = GameManager.Instance.countCheck; i < 3 * nowDay + 2; i++) 
        {
            if (GameManager.Instance.saveData.isClearPuzzle[i] == false)
            {
                GameManager.Instance.countCheck = i;
                break;
            }
        }
        if (GameManager.Instance.countCheck == 2)
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Clover";
            GameManager.Instance.beforeSetDialogueName = "Day1StoryCloverPuzzle";
            GameManager.Instance.puzzleArrayNum = 1;
        }
        else if (GameManager.Instance.countCheck == 3)
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Leash";
            GameManager.Instance.beforeSetDialogueName = "Day1StoryCollarPuzzle";
            GameManager.Instance.puzzleArrayNum = 2;
        }
        else if (GameManager.Instance.countCheck == 4)
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Soccer_ball";
            GameManager.Instance.beforeSetDialogueName = "Day1StoryFootballPuzzle";
            GameManager.Instance.puzzleArrayNum = 3;
        }
        else if (GameManager.Instance.countCheck == 5 && nowDay == 2)
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Band";
            GameManager.Instance.beforeSetDialogueName = "Day2StoryBandPuzzle";
            GameManager.Instance.puzzleArrayNum = 5;
        }
        else if (GameManager.Instance.countCheck == 6 && nowDay == 2)
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Cup";
            GameManager.Instance.beforeSetDialogueName = "Day2StoryCoffeePuzzle";
            GameManager.Instance.puzzleArrayNum = 6;
        }
        else if (GameManager.Instance.countCheck == 7 && nowDay == 2)
        {
            GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Wheel";
            GameManager.Instance.beforeSetDialogueName = "Day2StoryTirePuzzle";
            GameManager.Instance.puzzleArrayNum = 7;
        }
        GameManager.Instance.countCheck++;
        SoundManager.instance.PlaySoundEffect(SoundEffect.WaterDrop2);
        SceneManager.LoadScene("PuzzleScene");
    }

    public void TouchBookClickBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.FlippingBooks);
    }


    //GallerySceneBtn
    public void TouchGalleryHomeBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        SoundManager.instance.PlayBgm(BGM.Main);
        SceneManager.LoadScene("RoomScene");
    }

    public void TouchBookPuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name; 
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Rectangular";
        GameManager.Instance.beforeSetDialogueName = "Day1PastLifePuzzle2";
        GameManager.Instance.puzzleArrayNum = 0;
        SceneManager.LoadScene("PuzzleScene");
    }

    public void TouchCloverPuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Clover";
        GameManager.Instance.beforeSetDialogueName = "Day1StoryCloverPuzzle";
        GameManager.Instance.puzzleArrayNum = 2;
        SceneManager.LoadScene("PuzzleScene");
    }
    public void TouchLeashPuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Leash";
        GameManager.Instance.beforeSetDialogueName = "Day1StoryCollarPuzzle";
        GameManager.Instance.puzzleArrayNum = 3;
        SceneManager.LoadScene("PuzzleScene");
    }
    public void TouchSoccerBallPuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Soccer_ball";
        GameManager.Instance.beforeSetDialogueName = "Day1StoryFootballPuzzle";
        GameManager.Instance.puzzleArrayNum = 4;
        SceneManager.LoadScene("PuzzleScene");
    }
    public void TouchSherlockPuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Sherlock";
        GameManager.Instance.beforeSetDialogueName = "Day2PastLifePuzzle";
        GameManager.Instance.puzzleArrayNum = 1;
        SceneManager.LoadScene("PuzzleScene");
    }
    public void TouchBandPuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Band";
        GameManager.Instance.beforeSetDialogueName = "Day2StoryBandPuzzle";
        GameManager.Instance.puzzleArrayNum = 5;
        SceneManager.LoadScene("PuzzleScene");
    }
    public void TouchCoffeePuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Cup";
        GameManager.Instance.beforeSetDialogueName = "Day2StoryCoffeePuzzle";
        GameManager.Instance.puzzleArrayNum = 6;
        SceneManager.LoadScene("PuzzleScene");
    }
    public void TouchTirePuzzleBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        GameManager.Instance.puzzleImage = "PuzzleImage/Puzzle_Wheel";
        GameManager.Instance.beforeSetDialogueName = "Day2StoryTirePuzzle";
        GameManager.Instance.puzzleArrayNum = 7;
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
        StartCoroutine(LoadStoryScene());
    }

    IEnumerator LoadStoryScene()
    {   
        Scene currentScene = SceneManager.GetActiveScene(); // currentScene = CustomizingScene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StoryScene");
        while (!asyncLoad.isDone) //Scene load가 준비되지 않으면 return null
        {
            yield return null;
        }
        SceneManager.UnloadSceneAsync(currentScene); //현재 Scene을 unload
    }
}
