using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Types
{
    Null, Dialog, 
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
    public Types dialogueTypes;

    public Dialogue()
    {
        type = null;
        characterName = null;
        dialogue = null;
        routeFirst = null;
        routeSecond = null;
        routeThird = null;

        dialogueTypes = Types.Null;
    }

    public void Parse()
    {
        if(type != null)
        {
            dialogueTypes = (Types)Enum.Parse(typeof(Types), type);
        }
    }
}
