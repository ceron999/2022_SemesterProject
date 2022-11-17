using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    //MainSceneBtn
    public void TouchStartBtn()
    {
        SceneManager.LoadScene("StoryScene");
    }

    //public void TouchLoadBtn()
    //{
    //    /// if(대화를 할 수 있는 시간이 되었음)
    //    ///     SceneManager.LoadScene("StoryScene");
    //    /// else
    //    ///     SceneManager.LoadScene("WaitingScene");
    //}

    //public void TouchQuitBtn()
    //{
    //    Application.Quit();
    //}

    //WaitingSceneBtn
    public void TouchWaitingSceneSoulBtn()
    {
        if (GameManager.Instance.isTalkTIme == true)
        {
            //만약 그 날짜의 스토리를 보지 않았다면 스토리씬으로
            
        }
        else
        {
            //아니면
            SceneManager.LoadScene("RoomScene");
        }
    }

    public void TouchGalleryBtn()
    {
        SceneManager.LoadScene("GalleryScene");
    }

    public void TouchExitBtn()
    {
        //영혼과 잠시 멀어지겠습니까? yes/no 선택 후 이동 어디로?@@@@@@@@
    }

    //RoomSceneBtn
    public void TouchInteriorObjectBtn()
    {
        GameManager.Instance.pastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("PuzzleScene");
    }

    //GallerySceneBtn
    public void TouchHomeBtn()
    {
        SceneManager.LoadScene("WaitingScene");
    }

    public void TouchPuzzleBtn()
    {
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
}
