using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    //해당 소품을 클릭하면 퍼즐로 이동하도록 설정
    [SerializeField]
    DialogueManager dialogueManager;

    [SerializeField]
    GameObject soul;
    [SerializeField]
    GameObject dialoguePrefab;
    

    public void TalkWithSoul()
    {
        if (GameManager.Instance.isTalkTIme == true)
        {
            ////if(그날 스토리를 보지 않았다면)
            ////날짜에 따른 대화 파일 가져오기
            //dialogueManager.dialogueWrapperName = "Day1Story";
            //UnityEngine.SceneManagement.SceneManager.LoadScene("StoryScene");

            //else 그날 스토리를 보았다면
            //그냥 아무대화 나올듯?
            if (dialoguePrefab.activeSelf == false)
            {
                dialogueManager.SetScreenTouchCanvas(true);
                dialoguePrefab.SetActive(true);
                dialogueManager.dialogueWrapperName = "Day1PastLifePuzzle1";
                dialogueManager.Start();
            }
        }
        Debug.Log(1);
    }

    void SetDialogueWrapperName()
    {

    }
}
