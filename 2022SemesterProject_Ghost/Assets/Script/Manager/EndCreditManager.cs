using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCreditManager : MonoBehaviour
{
    JsonManager jsonManager;
    [SerializeField]
    Image[] endingImageArray;
    [SerializeField]
    GameObject fadeScreenCanvas;
    [SerializeField]
    GameObject endingImage;
    [SerializeField]
    GameObject creditTextObj;
    [SerializeField]
    Text creditText;
    UIFadeModule screenFadeModule;
    [SerializeField]
    GameObject imageCanvas;
    UIFadeModule textFadeModule;

    private void Start()
    {
        jsonManager = new JsonManager();
        for(int i =0; i<4; i++)
        {
            endingImageArray[i].gameObject.SetActive(false);
        }
        creditText.gameObject.SetActive(false);
        screenFadeModule = fadeScreenCanvas.GetComponent<UIFadeModule>();
        textFadeModule = imageCanvas.GetComponent<UIFadeModule>();
        GameManager.Instance.saveData.isWatchDayStory[2] = true;
        GameManager.Instance.SaveAllData();
        StartCoroutine(EndingCredit());
    }

    private void Update()
    {

    }

    IEnumerator EndingCredit()
    {
        endingImageArray[0].gameObject.SetActive(true);
        screenFadeModule.ScreenFade(1, 0, 1);
        creditTextObj.SetActive(true);
        creditText.text = "기획\n 강보경 박늘솔";

        for(int i=1;i<4; i++)
        {
            yield return new WaitForSeconds(10);
            screenFadeModule.ScreenFade(0, 1, 0.8f);
            textFadeModule.TextFade(creditTextObj, 1, 0, 0.8f);
            yield return new WaitForSeconds(0.8f);
            endingImageArray[i].gameObject.SetActive(true);
            SetCreditText(i);
            screenFadeModule.ScreenFade(1, 0, 0.8f);
            textFadeModule.TextFade(creditText.gameObject, 0, 1, 0.8f);
            yield return new WaitForSeconds(0.8f);
        }

        yield return new WaitForSeconds(10);

        screenFadeModule.ScreenFade(0, 1, 1);
        yield return new WaitForSeconds(1);

        for(int i =0; i<4; i++)
        {
            endingImageArray[i].gameObject.SetActive(false);
        }
        fadeScreenCanvas.SetActive(false);
        textFadeModule.TextFade(creditText.gameObject, 0, 1, 0.8f);
        creditText.text = "플레이해주셔서 감사합니다.";
        yield return new WaitForSeconds(10); 
        textFadeModule.TextFade(creditText.gameObject, 1, 0, 0.8f);
        yield return new WaitForSeconds(1.2f);

        SoundManager.instance.PlayBgm(BGM.Main);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    void SetCreditText(int idx)
    {
        switch(idx)
        {
            case 1:
                creditText.text = "플밍\n 정윤석 김자령 정선아 강희진";
                break;
            case 2:
                creditText.text = "그래픽\n 이하영 김민정";
                break;
            case 3:
                creditText.text = "사운드\n 이용하";
                break;
        }
    }

    public void SkipCredit()
    {
        StartCoroutine(SkipCreditCoroutine());
    }

    IEnumerator SkipCreditCoroutine()
    {
        StopAllCoroutines();
        screenFadeModule.ScreenFade(0, 1, 1);
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
