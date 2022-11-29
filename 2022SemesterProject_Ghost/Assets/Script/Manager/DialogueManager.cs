using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject ScreenTouchCanvas;
    [SerializeField]
    GameObject dialoguePrefab;
    [SerializeField]
    Text characterNameText;
    [SerializeField]
    Text dialogueText;
    [SerializeField]
    InputField inputField;
    [SerializeField]
    Text getStringText;
    [SerializeField]
    GameObject enterStringBtn;
    [SerializeField]
    GameObject routeFirstParent;
    [SerializeField]
    Text routeFirstText;
    [SerializeField]
    GameObject routeSecondParent;
    [SerializeField]
    Text routeSecondText;
    [SerializeField]
    GameObject routeThirdParent;
    [SerializeField]
    Text routeThirdText;
    [SerializeField]
    GameObject routeFourthParent;
    [SerializeField]
    Text routeFourthText;
    [SerializeField]
    GameObject routeFifthParent;
    [SerializeField]
    Text routeFifthText;
    [SerializeField]
    GameObject routeSixthParent;
    [SerializeField]
    Text routeSixthText;
    [SerializeField]
    GameObject routeSeventhParent;
    [SerializeField]
    Text routeSeventhText;

    [SerializeField]
    DialogueWrapper dialogueWrapper;
    public string dialogueWrapperName;

    public JsonManager jsonManager;

    [HideInInspector]
    bool isDialogueEnd = false;
    bool isDialoguePrinting = false;
    int nowDialogueIndex;
    ActionKeyword nowAction;

    public void Start()
    {
        jsonManager = new JsonManager();

        characterNameText.text = "";
        dialogueText.text = "";
        nowDialogueIndex = 0;
        dialogueWrapperName = GameManager.Instance.setDialogueName;

        if (dialogueWrapperName != "")
        {
            dialogueWrapper = jsonManager.ResourceDataLoad<DialogueWrapper>(dialogueWrapperName);
            dialogueWrapper.Parse();
            StartDialogue();
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //    SkipDialogue();
    }

    public void StartDialogue()
    {
        //씬이 바뀌고 자연스럽게 페이드인 -> 천천히 대화창이 나오게 설정
        StartCoroutine(PrintDialogue());
    }

    public void ScreenTouch()
    {
        Debug.Log(nowAction.ToString());
        switch(nowAction)
        {
            case ActionKeyword.Null:
                ContinueDialogue();
                break;
            case ActionKeyword.GetSpeechHabit:
                ContinueDialogue();
                StartCoroutine(GetTextString());
                break;
            case ActionKeyword.PrintSpeechHabit:
                ContinueDialogue();
                break;
            case ActionKeyword.GetSoulName:
                ContinueDialogue();
                StartCoroutine(GetTextString());
                break;
        }
    }

    IEnumerator PrintDialogue()
    {
        isDialoguePrinting = true;
        Dialogue nowDialogue = dialogueWrapper.dialogueArray[nowDialogueIndex];
        if (nowDialogue.actionKeywordString != null)
            nowAction = nowDialogue.actionKeyword;

        characterNameText.text = nowDialogue.characterName;
        for (int i = 0; i < nowDialogue.dialogue.Length; i++)
        {
            dialogueText.text += nowDialogue.dialogue[i];
            yield return new WaitForSeconds(0.07f);
        }

        if (nowDialogue.routeFirst == null)
        {
            isDialoguePrinting = false;
            nowDialogueIndex++;
        }
        else
            SetRouteText();
    }

    public void SkipDialogue()
    {
        Debug.Log("누르면 쭉 스킵하게 만들거임");
    }

    public void SpreadDialogue(Dialogue nowDialog)
    {
        //한번에 쭉 뿌림
        dialogueText.text = "";
        dialogueText.text = nowDialog.dialogue;
    }

    public void ContinueDialogue()
    {
        if (nowDialogueIndex < dialogueWrapper.dialogueArray.Length)
        {
            Dialogue nowDialogue = dialogueWrapper.dialogueArray[nowDialogueIndex];
            if (nowDialogue.actionKeywordString != null)
                nowAction = nowDialogue.actionKeyword;

            if (isDialoguePrinting)
            {
                SpreadDialogue(nowDialogue);
                StopAllCoroutines();
                isDialoguePrinting = false;
                nowDialogueIndex++;
            }

            else if (!isDialogueEnd && !isDialoguePrinting)
            {
                dialogueText.text = "";
                StartCoroutine(PrintDialogue());
            }
        }

        if (isDialogueEnd)
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "StoryScene")
                UnityEngine.SceneManagement.SceneManager.LoadScene("RoomScene");
            else
            {
                SetScreenTouchCanvas(false);
                dialoguePrefab.SetActive(false);
            }

            GameManager.Instance.SetIsWatchStory(dialogueWrapperName);
            jsonManager.SaveJson(GameManager.Instance.saveData, "SaveData");
            Debug.Log(GameManager.Instance.saveData.isWatchDayStory[0]);
            Debug.Log("진행상황 세이브 완료");
        }

        if (nowDialogueIndex == dialogueWrapper.dialogueArray.Length)
        {
            isDialogueEnd = true;
        }
    }

    public void SetScreenTouchCanvas(bool active)
    {
        ScreenTouchCanvas.SetActive(active);
    }

    void SetRouteText()
    {
        SetScreenTouchCanvas(false);
        Dialogue nowDialogue = dialogueWrapper.dialogueArray[nowDialogueIndex];

        if(nowDialogue.routeFirst != null)
        {
            routeFirstText.text = nowDialogue.routeFirst.ToString();
            routeFirstParent.SetActive(true);
        }
        if (nowDialogue.routeSecond != null)
        {
            routeSecondText.text = nowDialogue.routeSecond.ToString();
            routeSecondParent.SetActive(true);
        }
        if (nowDialogue.routeThird != null)
        {
            routeThirdText.text = nowDialogue.routeThird.ToString();
            routeThirdParent.SetActive(true);
        }
        if (nowDialogue.routeFourth != null)
        {
            routeFourthText.text = nowDialogue.routeFourth.ToString();
            routeFourthParent.SetActive(true);
        }
        if (nowDialogue.routeFifth != null)
        {
            routeFifthText.text = nowDialogue.routeFifth.ToString();
            routeFifthParent.SetActive(true);
        }
        if (nowDialogue.routeSixth != null)
        {
            routeSixthText.text = nowDialogue.routeSixth.ToString();
            routeSixthParent.SetActive(true);
        }
        if (nowDialogue.routeSeventh != null)
        {
            routeSeventhText.text = nowDialogue.routeSeventh.ToString();
            routeSeventhParent.SetActive(true);
        }

    }

    public void TurnOffRoutes()
    {
        routeFirstParent.SetActive(false);
        routeSecondParent.SetActive(false);
        routeThirdParent.SetActive(false);
        routeFourthParent.SetActive(false);
        routeFifthParent.SetActive(false);
        routeSixthParent.SetActive(false);
        routeSeventhParent.SetActive(false);

        isDialoguePrinting = false;
        nowDialogueIndex++;

        SetScreenTouchCanvas(true);
    }

    IEnumerator GetTextString()
    {
        while (isDialoguePrinting)
        {
            yield return null;
        }

        SetScreenTouchCanvas(false);
        inputField.gameObject.SetActive(true);
        enterStringBtn.SetActive(true);
    }

    public void EnterStringBtn()
    {
        if (nowAction == ActionKeyword.GetSpeechHabit)
            GameManager.Instance.saveData.playerSpeechHabit = getStringText.text;
        else if (nowAction == ActionKeyword.GetSoulName)
            GameManager.Instance.saveData.soulName = getStringText.text;
        jsonManager.SaveJson(GameManager.Instance.saveData, "SaveData");
        Debug.Log("입력 받고 저장 완료");

        SetScreenTouchCanvas(true);
        inputField.gameObject.SetActive(false);
        enterStringBtn.SetActive(false);
        nowAction = ActionKeyword.Null;
        ContinueDialogue();
    }
}
