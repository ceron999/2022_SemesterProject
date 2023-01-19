using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectSource : MonoBehaviour
{
    public SoundEffectSource soundEffectSource;
    private void Awake()
    {
        if (soundEffectSource == null)
        {
            soundEffectSource = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
