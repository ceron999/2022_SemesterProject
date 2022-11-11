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

    public void TouchLoadBtn()
    {
        /// if(대화를 할 수 있는 시간이 되었음)
        ///     SceneManager.LoadScene("StoryScene");
        /// else
        ///     SceneManager.LoadScene("WaitingScene");
    }

    public void TouchQuitBtn()
    {
        Application.Quit();
    }

    //WaitingSceneBtn
    public void TouchDialogueLogBtn()
    {
        //로그 보여주셈
        Debug.Log("대화 로그로");
    }

    public void TouchGalleryBtn()
    {
        SceneManager.LoadScene("GalleryScene");
    }

    public void TouchExitBtn()
    {
        //영혼과 잠시 멀어지겠습니까? yes/no 선택 후 이동
    }
}
