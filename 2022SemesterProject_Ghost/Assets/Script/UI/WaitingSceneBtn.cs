using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitingSceneBtn : MonoBehaviour
{
    public void TouchDialogueLogBtn()
    {
        //로그 보여주셈
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
