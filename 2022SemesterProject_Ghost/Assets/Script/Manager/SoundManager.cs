using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGM
{
    Main,Gallery,Ending
}
public enum SoundEffect
{
    FlippingBooks, GalleryLeftArrow, GalleryRightArrow, 
    OpenDoorSound, PaperSound, PuzzleMove,
    SceneMove, SlotLeftBtn, SlotRightBtn,
    WaterDrop1, WaterDrop2
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgmSource;
    public AudioSource soundEffectSource;
    public AudioClip[] bgmArray;
    public AudioClip[] soundEffectArray;

    bool isFlipping = false;    //flippingBook소리가 넘 커서 조절하려고

    private void Awake()
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

    public void PlayBgm(BGM getBgm)
    {
        switch(getBgm)
        {
            case BGM.Main:
                SetBGMSource(BGM.Main);
                break;
            case BGM.Gallery:
                SetBGMSource(BGM.Gallery);
                break;
            case BGM.Ending:
                SetBGMSource(BGM.Ending);
                break;
        }
    }

    public void PlaySoundEffect(SoundEffect getSoundEffect) 
    { 
        switch(getSoundEffect)
        {
            case SoundEffect.FlippingBooks:
                soundEffectSource.volume = 0.1f;
                if (soundEffectSource.isPlaying)
                    return;
                SetSoundEffectSource(SoundEffect.FlippingBooks);
                StartCoroutine(SetVolumeNormal());
                break;
            case SoundEffect.GalleryLeftArrow:
                SetSoundEffectSource(SoundEffect.GalleryLeftArrow);
                break;
            case SoundEffect.GalleryRightArrow:
                SetSoundEffectSource(SoundEffect.GalleryRightArrow);
                break;
            case SoundEffect.OpenDoorSound:
                SetSoundEffectSource(SoundEffect.OpenDoorSound);
                break;
            case SoundEffect.PaperSound:
                SetSoundEffectSource(SoundEffect.PaperSound);
                break;
            case SoundEffect.PuzzleMove:
                SetSoundEffectSource(SoundEffect.PuzzleMove);
                break;
            case SoundEffect.SceneMove:
                SetSoundEffectSource(SoundEffect.SceneMove);
                break;
            case SoundEffect.SlotLeftBtn:
                SetSoundEffectSource(SoundEffect.SlotLeftBtn);
                break;
            case SoundEffect.SlotRightBtn:
                SetSoundEffectSource(SoundEffect.SlotRightBtn);
                break;
            case SoundEffect.WaterDrop1:
                SetSoundEffectSource(SoundEffect.WaterDrop1);
                break;
            case SoundEffect.WaterDrop2:
                SetSoundEffectSource(SoundEffect.WaterDrop2);
                break;
        }
    }

    public void SetBGMSource(BGM getBgm)
    {
        if (bgmSource == null)
        {
            GameObject audioObject = GameObject.Find("BGMSource");
            bgmSource = audioObject.GetComponent<AudioSource>();
            bgmSource.loop = true;
            bgmSource.clip = bgmArray[(int)getBgm];
            bgmSource.Play();
        }
        else
        {
            bgmSource.clip = bgmArray[(int)getBgm];
            bgmSource.Play();
        }
    }
    public void SetSoundEffectSource(SoundEffect getSoundEffect)
    {
        if (soundEffectSource == null)
        {
            GameObject audioObject = GameObject.Find("SoundEffectSource");
            soundEffectSource = audioObject.GetComponent<AudioSource>();
            soundEffectSource.clip = soundEffectArray[(int)getSoundEffect];
            soundEffectSource.Play();
        }
        else
        {
            soundEffectSource.clip = soundEffectArray[(int)getSoundEffect];
            soundEffectSource.Play();
        }
    }

    public void SetBGMVolume(float getVolume, float getEndTime)
    {
        StartCoroutine(SetVolumeCoroutine(getVolume, getEndTime));
    }

    //public void SetSoundEffectVolume(float getVolume, float getEndTime)
    //{
    //    StartCoroutine(SetEffectVolumeCoroutine(getVolume, getEndTime));
    //}

    IEnumerator SetVolumeCoroutine(float getEndVolume, float endTime)
    {
        float time = 0;
        float nowVolume = bgmSource.volume;

        while (time <= 1)
        {
            nowVolume = Mathf.Lerp(bgmSource.volume, getEndVolume, time / endTime);
            bgmSource.volume = nowVolume;
            yield return null;
            time += Time.deltaTime;
        }
    }
    //IEnumerator SetEffectVolumeCoroutine(float getEndVolume, float endTime)
    //{
    //    float time = 0;
    //    float nowVolume = soundEffectSource.volume;

    //    while (time <= 1)
    //    {
    //        nowVolume = Mathf.Lerp(soundEffectSource.volume, getEndVolume, time / endTime);
    //        soundEffectSource.volume = nowVolume;
    //        yield return null;
    //        time += Time.deltaTime;
    //    }
    //}

    //flipping이 혼자 너무 커서 함수 만듬
    IEnumerator SetVolumeNormal()
    {
        yield return new WaitForSeconds(0.7f);
        soundEffectSource.volume = 0.5f;
    }
}
