using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
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
    string dialogueName;

    void Start()
    {
        GameClear();
        dialogueName = "RandomDialogue";
        SetPuzzleStory();
    }


    public void TalkWithSoul()
    {
        SoundManager.instance.PlaySoundEffect(SoundEffect.WaterDrop1);
        if (GameManager.Instance.isTalkTIme == true)
        {
            SetRandomDialogue();
            dialogueManager.LoadDialogue();
        }
        else
        {
            Debug.Log("zzz");
        }
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
            dialogueManager.LoadDialogue();
            GameManager.Instance.puzzleDialogue = false;
        }
        
    }

    void GameClear()
    {
        if (GameManager.Instance.saveData.isWatchDayStory[2])
        {
            Destroy(soul);
            Destroy(light1);
            Destroy(light2);
        }
    }
}
