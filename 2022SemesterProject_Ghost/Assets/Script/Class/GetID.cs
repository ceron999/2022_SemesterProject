using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetID : MonoBehaviour
{
    public GameObject bgmsource;
    public GameObject souneffectsource;
    public GameObject soundManager;
    public GameObject GameManager;
    private void Start()
    {
        Debug.Log(bgmsource.GetInstanceID());
        Debug.Log(souneffectsource.GetInstanceID());
        Debug.Log(soundManager.GetInstanceID());
        Debug.Log(GameManager.GetInstanceID());
    }
}
