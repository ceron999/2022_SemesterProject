using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    JsonManager jsonManager;
    //해당 소품을 클릭하면 퍼즐로 이동하도록 설정
    [SerializeField]
    DialogueManager dialogueManager;

    [SerializeField]
    GameObject soul;
    [SerializeField]
    GameObject light1;
    [SerializeField]
    GameObject light2;
    [SerializeField]
    GameObject dialoguePrefab;
    [SerializeField]
    GameObject dialogueLogParent;
    [SerializeField]
    Text logText;

    string dialogueName;
    DialogueWrapper puzzleDialogueWrapper;

    void Start()
    {
        jsonManager = new JsonManager();
        GameClear();
        dialogueName = "RandomDialogue";
        SetPuzzleStory();
        FixLogText();
    }


    public void TalkWithSoul()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.WaterDrop1);
        SetRandomDialogue();
        dialogueManager.LoadDialogue();
    }

    void SetRandomDialogue()
    {
        int randomNum = Random.Range(1, 12);
        GameManager.Instance.setDialogueName = dialogueName + randomNum.ToString();
        Debug.Log(dialogueName + randomNum);
    }
    public void SetPuzzleStory()
    {
        if (GameManager.Instance.puzzleDialogue)
        {
            GameManager.Instance.setDialogueName = GameManager.Instance.beforeSetDialogueName;
            SetDialogueLog(GameManager.Instance.setDialogueName);
            dialogueManager.LoadDialogue();
            GameManager.Instance.puzzleDialogue = false;
        }
        
    }

    void SetDialogueLog(string dialogueName)
    {
        puzzleDialogueWrapper = jsonManager.ResourceDataLoad<DialogueWrapper>(dialogueName);
        puzzleDialogueWrapper.Parse();

        GameManager.Instance.saveData.logWapperName = dialogueName;

        logText.text = "\n";
        for(int i=0; i<puzzleDialogueWrapper.dialogueArray.Length; i++) 
        {
            logText.text += puzzleDialogueWrapper.dialogueArray[i].dialogue;
            logText.text += "\n\n";
        }
    }

    void FixLogText()
    {
        if(GameManager.Instance.saveData.logWapperName != "")
        {
            puzzleDialogueWrapper = jsonManager.ResourceDataLoad<DialogueWrapper>(GameManager.Instance.saveData.logWapperName);
            puzzleDialogueWrapper.Parse();

            logText.text = "\n";
            for (int i = 0; i < puzzleDialogueWrapper.dialogueArray.Length; i++)
            {
                logText.text += puzzleDialogueWrapper.dialogueArray[i].dialogue;
                logText.text += "\n\n";
            }
        }
    }

    void GameClear()
    {
        if (GameManager.Instance.saveData.isWatchDayStory[2])
        {
            Destroy(soul);
            Destroy(light1);
            Destroy(light2);
            Destroy(dialoguePrefab);
        }
    }
}
