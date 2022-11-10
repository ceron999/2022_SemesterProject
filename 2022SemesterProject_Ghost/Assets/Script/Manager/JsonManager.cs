using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JsonManager    
{
    public T ResourceDataLoad<T> (string name)
    {
        T gameData;

        string directory = "JsonData/";
        string appender1 = name;

        StringBuilder builder = new StringBuilder(directory);
        builder.Append(appender1);

        TextAsset jsonString = Resources.Load<TextAsset>(builder.ToString());

        gameData = JsonUtility.FromJson<T>(jsonString.ToString());
        
        return gameData;
    }
}
