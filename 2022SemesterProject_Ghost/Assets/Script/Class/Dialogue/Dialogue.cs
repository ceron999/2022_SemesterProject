using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Types
{
    Null, Dialog, Customizing, ViewPaper
}

public enum ActionKeyword
{
    Null, GetSpeechHabit, PrintSpeechHabit, GetSoulName
}

[Serializable]
public class Dialogue
{
    public string type;
    public string characterName;
    public string actionKeywordString;
    public string dialogue;

    public string routeFirst;
    public string routeSecond;
    public string routeThird;
    public string routeFourth;
    public string routeFifth;
    public string routeSixth;
    public string routeSeventh;

    public Types dialogueTypes;
    public ActionKeyword actionKeyword;

    public Dialogue()
    {
        type = null;
        characterName = null;
        actionKeywordString = null;
        dialogue = null;
        routeFirst = null;
        routeSecond = null;
        routeThird = null;
        routeFourth = null;
        routeFifth = null;
        routeSixth = null;
        routeSeventh = null;

        dialogueTypes = Types.Null;
        actionKeyword = ActionKeyword.Null;
    }

    public void Parse()
    {
        if(type != null)
        {
            dialogueTypes = (Types)Enum.Parse(typeof(Types), type);
        }

        if(actionKeywordString != null)
        {
            actionKeyword = (ActionKeyword)Enum.Parse(typeof(ActionKeyword), actionKeywordString);
        }
    }
}
