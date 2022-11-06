using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Types
{
    Null, Dialogue
}

[Serializable]
public class Dialogue
{
    public string type;
    public string characterName;
    public string dialogue;
    public string routeFirst;
    public string routeSecond;
    public string routeThird;

    public Dialogue()
    {
        type = null;
        characterName = null;
        dialogue = null;
        routeFirst = null;
        routeSecond = null;
        routeThird = null;
    }

    //public void Parse()
    //{

    //}
}
