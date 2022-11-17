using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public JsonManager jsonManager;

    public string pastSceneName;

    public bool isTalkTIme;

    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;    
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        jsonManager = new JsonManager();
    }

}
