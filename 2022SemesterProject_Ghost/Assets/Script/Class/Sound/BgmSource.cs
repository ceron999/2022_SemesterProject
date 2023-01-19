using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSource : MonoBehaviour
{
    public BgmSource bgmSource;
    private void Awake()
    {
        if (bgmSource == null)
        {
            bgmSource = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
