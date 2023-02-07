using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    GameObject tutorialCanvas;
    [SerializeField]
    Text tutorialText;
    [SerializeField]
    Image clickImage1;
    [SerializeField]
    Image clickImage2;
    [SerializeField]
    Transform soulTransform;
    [SerializeField]
    Transform light1Transform;
    [SerializeField]
    Transform light2Transform;
    [SerializeField]
    Transform dialogueLogTransform;

    bool isTutorialEnd;
    string[] nowTutorialTextArr;

    private void Start()
    {
        if(isTutorialEnd)
        {
            Destroy(tutorialText);
            Destroy(clickImage1);
            Destroy(clickImage2);
            Destroy(tutorialCanvas);
            Destroy(this);
            return;
        }
        if(GameManager.Instance.saveData.isFirstPlay)
        {
            GameManager.Instance.saveData.isFirstPlay = false;
            StartTutorial();
        }
    }

    void StartTutorial()
    {
        tutorialCanvas.SetActive(true);
        nowTutorialTextArr = new string[6];
        nowTutorialTextArr[0] = "��ȥ�� �ڽ��� ����� ����ϰ�\n �����־�� �մϴ�.";
        nowTutorialTextArr[1] = "��ȥ�� ��ġ�ϸ�,\n ��ȥ�� ��ȭ�� �� �ֽ��ϴ�.";
        nowTutorialTextArr[2] = "��ȥ �ֺ��� ������\n ��ȥ�� ����Դϴ�.";
        nowTutorialTextArr[3] = "����� ��ġ�Ͽ� ������ Ǯ��,\n ��ȥ�� ����� �ϳ���\n ��ã�� �� �ֽ��ϴ�.";
        nowTutorialTextArr[4] = "��ȥ�� �����\n �ٽ� Ȯ�� �� �� �ֽ��ϴ�.";
        nowTutorialTextArr[5] = "�׷� ��ſ� ���� �Ǽ���!";
        
        StartCoroutine(TypingTutorialTextCoroutine());

        isTutorialEnd = true;
        GameManager.Instance.SaveAllData();
    }

    IEnumerator TypingTutorialTextCoroutine()
    {
        string nowText;
        for (int idx = 0; idx < 6; idx ++)
        {
            tutorialText.text = "";
            nowText = nowTutorialTextArr[idx];
            SetClickImage(idx);
            for (int i = 0; i < nowText.Length; i++)
            {
                tutorialText.text += nowText[i];
                yield return new WaitForSeconds(0.05f);
            }

            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
        }

        tutorialCanvas.SetActive(false);
    }

    void SetClickImage(int nowIdx)
    {
        switch(nowIdx) 
        {
            case 0:
                clickImage1.gameObject.SetActive(false);
                clickImage2.gameObject.SetActive(false);
                break;
            case 1:
                clickImage1.gameObject.SetActive(true);
                clickImage1.transform.position = soulTransform.position - new Vector3(0, 276, 0);
                break;
            case 2:
                clickImage2.gameObject.SetActive(true);
                clickImage1.transform.position = light1Transform.position - new Vector3(0, 194, 0); 
                clickImage2.transform.position = light2Transform.position - new Vector3(0, 194, 0);
                break;
            case 3:
                break;
            case 4:
                clickImage2.gameObject.SetActive(false);
                clickImage1.transform.position = dialogueLogTransform.position - new Vector3(0, 160, 0);
                break;
            case 5:
                clickImage1.gameObject.SetActive(false);
                clickImage2.gameObject.SetActive(false);
                break;
        }
    }
}
