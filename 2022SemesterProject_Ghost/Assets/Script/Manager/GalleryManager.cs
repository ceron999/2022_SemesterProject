using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryManager : MonoBehaviour
{
    //캔버스 목록
    public Canvas canvas00;
    public Canvas canvas01;
    public Canvas canvas02;

    public CanvasGroup canvasGroup00;
    public CanvasGroup canvasGroup01;
    public CanvasGroup canvasGroup02;

    void Start() {
        Debug.Log("갤러리 화면");

        canvasGroup00.alpha =1;
        canvas00.enabled = true;

        canvasGroup01.alpha =0;
        canvas01.enabled = false;

        canvasGroup02.alpha =0;
        canvas02.enabled = false;
    }
    //갤러리 들어가면 해당 소품 관련 퍼즐 표현 + 클릭하면 이동 + 해당 퍼즐이 클리어되었으면 오픈 등
    //메인 화면 이동
    public void ChangeMainScence (){
        Debug.Log("메인 화면 이동");
        SceneManager.LoadScene(0);
    }

    //퍼즐 화면 이동
    public void ChangePuzzleScence (){
        Debug.Log("퍼즐 화면 이동");
        SceneManager.LoadScene(5);
    }

    //갤러리 화면 전환
    public void ChangeGalleryScence (){
        if (canvas00.enabled == true){
        canvasGroup00.alpha =0;
        canvas00.enabled = false;

        canvasGroup01.alpha =1;
        canvas01.enabled = true;

        canvasGroup02.alpha =0;
        canvas02.enabled = false;
        Debug.Log("전생 오른쪽");

        
        }

        else if (canvas01.enabled == true){
            if (gameObject.name == "Rightarrow"){
                canvasGroup00.alpha =0;
                canvas00.enabled = false;

                canvasGroup01.alpha =0;
                canvas01.enabled = false;

                canvasGroup02.alpha =1;
                canvas02.enabled = true;
                Debug.Log("1일차 오른쪽");
            }
            else{
                canvasGroup00.alpha =1;
                canvas00.enabled = true;

                canvasGroup01.alpha =0;
                canvas01.enabled = false;

                canvasGroup02.alpha =0;
                canvas02.enabled = false;
                Debug.Log("1일차 왼쪽");
            }
        }

        else if (canvas02.enabled == true){
        canvasGroup00.alpha =0;
        canvas00.enabled = false;

        canvasGroup01.alpha =1;
        canvas01.enabled = true;

        canvasGroup02.alpha =0;
        canvas02.enabled = false;
        Debug.Log("2일차 왼쪽");
        }
    }

}
