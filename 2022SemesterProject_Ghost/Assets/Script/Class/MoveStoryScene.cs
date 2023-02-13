using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStoryScene : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.setDialogueName = "Day1Story";
        UnityEngine.SceneManagement.SceneManager.LoadScene("StoryScene");
    }
}
