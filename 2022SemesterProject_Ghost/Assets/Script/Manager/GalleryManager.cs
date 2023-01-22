using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour
{

    public enum NowCanvas
    {
        canvas00, canvas01
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
    CanvasGroup canvasGroup00;
    [SerializeField]
    CanvasGroup canvasGroup01;

    [SerializeField]
    Button[] puzzleBtnArr;
    [SerializeField]
    GameObject[] lockImages;

    void Start() {
        nowCanvas = NowCanvas.canvas00;
        date.text = "";
        SetCanvas();
        SetPuzzleBtnImage();
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
                break;
            case NowCanvas.canvas01:
                date.text = "2일차";
                canvasGroup00.alpha = 0;
                canvas00.enabled = false;

                canvasGroup01.alpha = 1;
                canvas01.enabled = true;
                break;
        }
    }
    //갤러리 들어가면 해당 소품 관련 퍼즐 표현 + 클릭하면 이동 + 해당 퍼즐이 클리어되었으면 오픈 등
    //메인 화면 이동

    public void TouchLeftBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.GalleryLeftArrow);
        switch(nowCanvas)
        {
            case NowCanvas.canvas01:
                nowCanvas = NowCanvas.canvas00;
                SetCanvas();
                leftBtn.gameObject.SetActive(false);
                rightBtn.gameObject.SetActive(true);
                break;
        }
    }

    public void TouchRightBtn()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.GalleryRightArrow);
        switch (nowCanvas)
        {
            case NowCanvas.canvas00:
                nowCanvas = NowCanvas.canvas01;
                SetCanvas();
                leftBtn.gameObject.SetActive(true);
                rightBtn.gameObject.SetActive(false);
                break;
        }
    }

    void SetPuzzleBtnImage()
    {
        List<bool> isClearPuzzle;
        isClearPuzzle = GameManager.Instance.saveData.isClearPuzzle;
        int changenum=0;
        for(int i =0; i<8; i++)
        {
            if (!isClearPuzzle[i])
            {
                //잠금
                //if (i == 1)//과거퍼즐 0,1을  0,4로 변경
                //    changenum = 4;
                //else if (i > 1 && i < 5)
                //    changenum = i - 1;
                //else
                //    changenum = i;
                changenum = i;
                puzzleBtnArr[changenum].interactable = false;
                puzzleBtnArr[changenum].image.color = new Color(0, 0, 0);
                lockImages[changenum].SetActive(true);
            }
        }
    }
}
