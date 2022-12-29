using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeModule : MonoBehaviour
{
    [SerializeField]
    Image fadeImage;

    public void ScreenFade(float start,float end, float fadeTime)
    {
        fadeImage.gameObject.SetActive(true);

        StartCoroutine(ScreenFadeCoroutine(start, end, fadeTime));
    }

    IEnumerator ScreenFadeCoroutine(float startAlpha, float endAlpha, float fadeTime)
    {
        float time = 0;
        float newAlpha = startAlpha;

        while(time <= fadeTime)
        {
            newAlpha = Mathf.Lerp(startAlpha,endAlpha,time/fadeTime);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;
            time += Time.deltaTime;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, endAlpha);
        yield return null;

        fadeImage.gameObject.SetActive(false);
    }
}
