using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneBtn : MonoBehaviour
{
    public void TouchStartBtn()
    {
        SceneManager.LoadScene("WaitingScene");
    }

    public void TouchLoadBtn()
    {
        //대충 로드해서 가져오셈
    }

    public void TouchQuitBtn()
    {
        Application.Quit();
    }
}
