using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{
    
    public enum NowCanvas
    {
        canvas00, canvas01, canvas02
    }

    NowCanvas nowCanvas;
    [SerializeField]
    Text date;
    [SerializeField]
    Button homeBtn;
    [SerializeField]
    Button leftBtn;
    [SerializeField]
    Button rightBtn;

    //캔버스 목록
    [SerializeField]
    Canvas canvas00;
    [SerializeField]
    Canvas canvas01;
    [SerializeField]
    Canvas canvas02;

    //락 이미지 목록
    [SerializeField]
    GameObject lockimage01;
    [SerializeField]
    GameObject lockimage02;
    [SerializeField]
    GameObject lockimage03;
    [SerializeField]
    GameObject lockimage04;

    [SerializeField]
    CanvasGroup canvasGroup00;
    [SerializeField]
    CanvasGroup canvasGroup01;
    [SerializeField]
    CanvasGroup canvasGroup02;



    void Start() {
        nowCanvas = NowCanvas.canvas00;
        date.text = "";
        SetCanvas();
        Lock();
    }

    void SetCanvas()
    {
        switch (nowCanvas)
        {
            case NowCanvas.canvas00:
                date.text = "1일차";
                canvasGroup00.alpha = 1;
                canvas00.enabled = true;

                canvasGroup01.alpha = 0;
                canvas01.enabled = false;

                canvasGroup02.alpha = 0;
                canvas02.enabled = false;
                break;
            case NowCanvas.canvas01:
                date.text = "2일차";
                canvasGroup00.alpha = 0;
                canvas00.enabled = false;

                canvasGroup01.alpha = 1;
                canvas01.enabled = true;

                canvasGroup02.alpha = 0;
                canvas02.enabled = false;
                break;
            case NowCanvas.canvas02:
                date.text = "3일차";
                canvasGroup00.alpha = 0;
                canvas00.enabled = false;

                canvasGroup01.alpha = 0;
                canvas01.enabled = false;

                canvasGroup02.alpha = 1;
                canvas02.enabled = true;
                break;
        }
    }
    //갤러리 들어가면 해당 소품 관련 퍼즐 표현 + 클릭하면 이동 + 해당 퍼즐이 클리어되었으면 오픈 등
    //메인 화면 이동

    public void TouchLeftBtn()
    {
        SoundManager.Instance.PlaySound1();
        switch(nowCanvas)
        {
            case NowCanvas.canvas01:
                nowCanvas = NowCanvas.canvas00;
                SetCanvas();
                leftBtn.gameObject.SetActive(false);
                break;
            case NowCanvas.canvas02:
                nowCanvas = NowCanvas.canvas01;
                SetCanvas();
                rightBtn.gameObject.SetActive(true);
                break;
        }
    }

    public void TouchRightBtn()
    {
        SoundManager.Instance.PlaySound2();
        switch (nowCanvas)
        {
            case NowCanvas.canvas00:
                nowCanvas = NowCanvas.canvas01;
                SetCanvas();
                leftBtn.gameObject.SetActive(true);
                break;
            case NowCanvas.canvas01:
                nowCanvas = NowCanvas.canvas02;
                SetCanvas();
                rightBtn.gameObject.SetActive(false);
                break;
        }
    }

    void Lock(){
        lockimage01.SetActive(true);
        lockimage02.SetActive(true);
        lockimage03.SetActive(true);
        lockimage04.SetActive(true);
    }
}
