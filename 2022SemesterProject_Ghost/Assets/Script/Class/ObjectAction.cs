using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
//using static UnityEditor.PlayerSettings;

public class ObjectAction : MonoBehaviour
{
    Transform nowPos;
    public float actionRange;
    public float speed;

    void Start()
    {
        nowPos = this.transform;
    }

    private void Update()
    {
        Vector3 objPos = nowPos.position;

        objPos.y += actionRange * Mathf.Sin(Time.time * speed);

        transform.position = objPos;
    }
}
