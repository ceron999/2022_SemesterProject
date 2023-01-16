using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
     public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    public static SoundManager Instance;

    void Awake()
    {
        if(SoundManager.Instance == null)
        {
            SoundManager.Instance = this;
        }
    }   

    //Btn Sound 함수
    public void PlaySound1()
    {
        audioSource.PlayOneShot(audioClip1);
    }

    public void PlaySound2()
    {
        audioSource.PlayOneShot(audioClip2);
    }

    public void PlaySound3()
    {
        audioSource.PlayOneShot(audioClip3);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
