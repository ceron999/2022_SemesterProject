using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    GameObject soul;
    [SerializeField]
    Image viewPaperImage;
    [SerializeField]
    GameObject roomImage;
    [SerializeField]
    GameObject fadeScreenCanvas;
    UIFadeModule screenFadeModule;

    [SerializeField]
    GameObject customizingPrefab;

    [SerializeField]
    DialogueWrapper dialogueWrapper;
    public string dialogueWrapperName;

    public JsonManager jsonManager;

    [HideInInspector]
    bool isDialogueEnd = false;
    bool isDialoguePrinting = false;
    bool isSaveDataPrinting = false;
    bool isRouteActive = false;
    bool isViewPaperClick = false;
    int nowDialogueIndex;
    ActionKeyword nowAction;

    GameObject prefab_obj;
    public GameObject customizingManager;
    List<GameObject> soulFaceEyeList = new List<GameObject>();
    List<GameObject> soulFaceMouthList = new List<GameObject>();
    List<GameObject> soulFaceItemList = new List<GameObject>();
    
    public IEnumerator Start()
    {  
        if(GameManager.Instance.isCustomizingEnd == true){ //  Prefab 불러오기
            prefab_obj = Resources.Load("Prefabs/CustomizingPrefab") as GameObject; // 저장된 Prefab 불러오기
            customizingPrefab = MonoBehaviour.Instantiate(prefab_obj, GameObject.Find("Canvas").transform); // Canvas위에 인스턴스화
            customizingPrefab.name = "customizingPrefab"; // Prefab name 지정
            Vector2 pos = new Vector2(720, 2000); // Prefab 위치 지정
            customizingPrefab.transform.position = pos;

            //CustomizingManager.awake랑 유사
            string tempstr2="";
            GameObject tempObj2;
            for(int i=0; i<6; i++){
                tempstr2 = "";
                tempstr2 = "SoulFaceEye"+i.ToString();
                tempObj2 = GameObject.Find(tempstr2);
                soulFaceEyeList.Add(tempObj2);
                soulFaceEyeList[i].SetActive(false);           

                tempstr2 = "";
                tempstr2 = "SoulFaceMouth"+i.ToString();
                tempObj2 = GameObject.Find(tempstr2);
                soulFaceMouthList.Add(tempObj2);
                soulFaceMouthList[i].SetActive(false);
            }
            for(int i=0; i<7; i++){
                tempstr2 = "";
                tempstr2 = "SoulFaceItem"+i.ToString();
                tempObj2 = GameObject.Find(tempstr2);
                soulFaceItemList.Add(tempObj2);
                soulFaceItemList[i].SetActive(false);
            }

            //CustomizingScene에서 정한 눈, 입, 아이템만 보이게 설정
            soulFaceEyeList[CustomizingManager.eyeIndex].SetActive(true);
            soulFaceMouthList[CustomizingManager.mouthIndex].SetActive(true);
            soulFaceItemList[CustomizingManager.itemIndex].SetActive(true);
        }

        jsonManager = new JsonManager();
        DialoguePrefabToggle(false);
        SetScreenTouchCanvas(false);
        characterNameText.text = "";
        dialogueText.text = "";
        if (GameManager.Instance.isCustomizingEnd)
        {
            nowDialogueIndex = 4;
            GameManager.Instance.isCustomizingEnd = false;
        }
        else
            nowDialogueIndex = 0;
        dialogueWrapperName = GameManager.Instance.setDialogueName;

        screenFadeModule = fadeScreenCanvas.GetComponent<UIFadeModule>();

        if (dialogueWrapperName != "")
        {
            dialogueWrapper = jsonManager.ResourceDataLoad<DialogueWrapper>(dialogueWrapperName);
            dialogueWrapper.Parse();

            screenFadeModule.ScreenFade(1, 0, 1);
            yield return new WaitForSeconds(1);
            DialoguePrefabToggle(true);
            SetScreenTouchCanvas(true);
            StartDialogue();
        } 
    }

    public void LoadDialogue()
    {
        nowDialogueIndex = 0;
        if (isDialogueEnd) 
            isDialogueEnd = false;
        dialogueText.text = "";
        dialogueWrapperName = GameManager.Instance.setDialogueName;
        dialogueWrapper = jsonManager.ResourceDataLoad<DialogueWrapper>(dialogueWrapperName);
        dialogueWrapper.Parse();
        SetScreenTouchCanvas(true);
        DialoguePrefabToggle(true);
        Debug.Log(nowDialogueIndex + "/" + dialogueWrapper.dialogueArray.Length);
        StartDialogue();
    }

    public void StartDialogue()
    {
        //씬이 바뀌고 자연스럽게 페이드인 -> 천천히 대화창이 나오게 설정
        SoundManager.instance.SetBGMVolume(0.1f, 1);
        StartCoroutine(PrintDialogue());
    }

    public void ScreenTouch()
    {
        if (nowDialogueIndex < dialogueWrapper.dialogueArray.Length)
        {
            Dialogue nowDialogue = dialogueWrapper.dialogueArray[nowDialogueIndex];
            if (nowDialogue.dialogueTypes == Types.Dialog)
                switch (nowAction)
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
                        Debug.Log("GetSoulName");
                        ContinueDialogue();
                        StartCoroutine(GetTextString());
                        break;                   
                }
            else if (nowDialogue.dialogueTypes == Types.Customizing)
            {
                Debug.Log("커마하러");
                UnityEngine.SceneManagement.SceneManager.LoadScene("CustomizingScene");
            }
            else if (nowDialogue.dialogueTypes == Types.SoulGone)
            {
                Debug.Log("SoulGone");
                StartCoroutine(SoulGoneCoroutine());
                nowDialogueIndex++;
            }
            else if (nowDialogue.dialogueTypes == Types.ViewPaper)
            {
                Debug.Log("ViewPaper");
                nowDialogueIndex++;
                StartCoroutine(ViewPaperFadeCoroutine());
            }
            else if (nowDialogue.dialogueTypes == Types.RoomFade)
            {
                Debug.Log("RoomFade");
                nowDialogueIndex++;
                StartCoroutine(RoomFadeCoroutine());
            }
            else if (nowDialogue.dialogueTypes == Types.EndCredit)
            {
                Debug.Log("EndCredit");
                nowDialogueIndex++;
                StartCoroutine(EndCreditCoroutine());
            }
            else
            {
                Debug.Log("dialogueType error!");
                Debug.Log("now dialogueType : " + nowDialogue.dialogueTypes.ToString());
            }
        }
        else ContinueDialogue();
    }

    IEnumerator PrintDialogue()
    {
        Debug.Log("nowIdx: " + nowDialogueIndex);
        isDialoguePrinting = true;
        Dialogue nowDialogue = dialogueWrapper.dialogueArray[nowDialogueIndex];
        if (nowDialogue.actionKeywordString != null)
            nowAction = nowDialogue.actionKeyword;

        characterNameText.text = nowDialogue.characterName;


        if (nowDialogue.routeFirst != null)
        {
            isRouteActive = true;
        }

        for (int i = 0; i < nowDialogue.dialogue.Length; i++)
        {
            if(nowDialogue.dialogue[i] != '^' && nowDialogue.dialogue[i] != '@')
                dialogueText.text += nowDialogue.dialogue[i];
            else
            {
                StartCoroutine(PrintSaveData(nowDialogue.dialogue[i]));
                while (isSaveDataPrinting)
                    yield return null;
            }
            yield return new WaitForSeconds(0.07f);
        }

        isDialoguePrinting = false;
        nowDialogueIndex++;
        if (nowDialogue.dialogueJumpParameter != 0)
            nowDialogueIndex += nowDialogue.dialogueJumpParameter;
    }

    IEnumerator PrintSaveData(char getChar)
    {
        isSaveDataPrinting = true;
        string getSaveDataText;

        if (getChar == '^')
            getSaveDataText = GameManager.Instance.saveData.playerSpeechHabit;
        else
            getSaveDataText = GameManager.Instance.saveData.soulName;

        for (int i = 0; i < getSaveDataText.Length; i++)
        {
                dialogueText.text += getSaveDataText[i];
                yield return new WaitForSeconds(0.07f);
        }
        isSaveDataPrinting = false;
    }

    public void SpreadDialogue(Dialogue nowDialog)
    {
        //한번에 쭉 뿌림
        dialogueText.text = "";
        for(int i =0; i < nowDialog.dialogue.Length; i++)
        {
            if (nowDialog.dialogue[i] != '^' && nowDialog.dialogue[i] != '@')
                dialogueText.text += nowDialog.dialogue[i];
            else if(nowDialog.dialogue[i] == '^')
                dialogueText.text += GameManager.Instance.saveData.playerSpeechHabit;
            else if (nowDialog.dialogue[i] == '@')
                dialogueText.text += GameManager.Instance.saveData.soulName;
        }
    }

    public void ContinueDialogue()
    {
        if (nowDialogueIndex < dialogueWrapper.dialogueArray.Length)
        {
            SoundManager.instance.PlaySoundEffect(SoundEffect.SceneMove);
            Dialogue nowDialogue = dialogueWrapper.dialogueArray[nowDialogueIndex];
            if (nowDialogue.actionKeywordString != null)
                nowAction = nowDialogue.actionKeyword;

            if (!isDialogueEnd && !isDialoguePrinting)
            {
                dialogueText.text = "";
                StartCoroutine(PrintDialogue()); 
                if (isRouteActive)
                    StartCoroutine(SetRouteText(nowDialogue));
            }
            else if (isDialoguePrinting)
            {
                StopAllCoroutines();
                SpreadDialogue(nowDialogue);

                isDialoguePrinting = false;
                if (isRouteActive)
                    StartCoroutine(SetRouteText(nowDialogue));
                
                nowDialogueIndex++;
                if (nowDialogue.dialogueJumpParameter != 0)
                    nowDialogueIndex += nowDialogue.dialogueJumpParameter;
            }
        }

        if (isDialogueEnd)
        {
            SoundManager.instance.SetBGMVolume(0.6f, 1f);
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "StoryScene")
            {
                StartCoroutine(EndDialogueCoroutine());
            }
            else
            {
                GameManager.Instance.setDialogueName = "";
                SetScreenTouchCanvas(false);
                DialoguePrefabToggle(false);
            }
            
            GameManager.Instance.SetIsWatchStory(dialogueWrapperName);
            GameManager.Instance.setDialogueName = "";
            jsonManager.SaveJson(GameManager.Instance.saveData, "SaveData");
            Debug.Log(GameManager.Instance.saveData.isWatchDayStory[0]);
            Debug.Log("진행상황 세이브 완료");
        }

        if (nowDialogueIndex == dialogueWrapper.dialogueArray.Length)
        {
            isDialogueEnd = true;
        }
    }

    IEnumerator EndDialogueCoroutine()
    {
        screenFadeModule.ScreenFade(0, 1, 1);
        yield return new WaitForSeconds(1);
        UnityEngine.SceneManagement.SceneManager.LoadScene("RoomScene");
    }

    public void SetScreenTouchCanvas(bool active)
    {
        ScreenTouchCanvas.SetActive(active);
    }

    IEnumerator SetRouteText(Dialogue nowDialogue)
    {
        while(isDialoguePrinting)
            yield return null;

        SetScreenTouchCanvas(false);

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
    
    public void SaveRoute(Text getText)
    {
        switch(dialogueWrapperName)
        {
            case "Day1Story":
                if (GameManager.Instance.saveData.soulShape == "")
                    GameManager.Instance.saveData.soulShape = getText.text;
                else if (GameManager.Instance.saveData.perfumeScent == "")
                    GameManager.Instance.saveData.perfumeScent = getText.text;
                else
                    return;
                break;
            case "Day2Story":
                if(dialogueWrapper.dialogueArray[nowDialogueIndex - 1].isDialogueJump)
                {
                    Debug.Log("Dialogue Jump");
                    Debug.Log(getText.name);
                    SetDialogueIndex(getText.name);
                }
                break;
        }
    }

    void SetDialogueIndex(string textName)
    {
        switch(textName)
        {
            case "RouteFirstText":
                break;
            case "RouteSecondText":
                nowDialogueIndex++;
                break;
            case "RouteThirdText":
                nowDialogueIndex += 2;
                break;
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

        SetScreenTouchCanvas(true);
        isRouteActive = false;
        ScreenTouch();
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

    IEnumerator SoulGoneCoroutine()
    {
        SetScreenTouchCanvas(false);
        UIFadeModule soulModule = soul.GetComponent<UIFadeModule>();
        soulModule.ObjectFade(soul, 1, 0, 1);
        yield return new WaitForSeconds(1);
        SetScreenTouchCanvas(true);
        ScreenTouch();
    }

    IEnumerator ViewPaperFadeCoroutine()
    {
        SetScreenTouchCanvas(false);
        viewPaperImage.gameObject.SetActive(true);
        float fadeFloat = 0;

        while(fadeFloat <= 1)
        {
            fadeFloat += 0.05f;
            viewPaperImage.color = new Color(255, 255, 255, fadeFloat);
            yield return new WaitForSeconds(0.1f);
        }

        //임시로 만듬
        while (Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        while (fadeFloat >= 0)
        {
            fadeFloat -= 0.05f;
            viewPaperImage.color = new Color(255, 255, 255, fadeFloat);
            yield return new WaitForSeconds(0.1f);
        }

        SetScreenTouchCanvas(true);
        viewPaperImage.gameObject.SetActive(false);
        ScreenTouch();
    }

    IEnumerator RoomFadeCoroutine()
    {
        SetScreenTouchCanvas(false);
        UIFadeModule roomModule = roomImage.GetComponent<UIFadeModule>();
        roomModule.ObjectFade(roomImage, 0, 1, 1);
        yield return new WaitForSeconds(1);
        SetScreenTouchCanvas(true);
        ScreenTouch();
    }

    IEnumerator EndCreditCoroutine()
    {
        DialoguePrefabToggle(false);
        SetScreenTouchCanvas(false);
        screenFadeModule.ScreenFade(0, 1, 1);
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlayBgm(BGM.Ending);
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndCreditScene");
    }

    public void DialoguePrefabToggle(bool active)
    {
        dialoguePrefab.SetActive(active);
    }
}
