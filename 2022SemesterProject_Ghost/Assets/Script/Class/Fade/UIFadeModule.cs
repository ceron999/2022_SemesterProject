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

    public void ObjectFade(GameObject getObject, float start, float end, float fadeTime)
    {
        getObject.SetActive(true);

        StartCoroutine(ObjectFadeCoroutine(getObject ,start, end, fadeTime));
    }

    public void TextFade(GameObject getObject, float start, float end, float fadeTime)
    {
        StartCoroutine(TextFadeCoroutine(getObject, start, end, fadeTime));
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

       if(endAlpha == 0) 
            fadeImage.gameObject.SetActive(false);
    }

    IEnumerator ObjectFadeCoroutine(GameObject getObject, float startAlpha, float endAlpha, float fadeTime)
    {
        getObject.SetActive(true);
        Image objImage = getObject.GetComponent<Image>();
        float time = 0;
        float newAlpha = startAlpha;

        while (time <= fadeTime)
        {
            newAlpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeTime);
            objImage.color = new Color(objImage.color.r, objImage.color.g, objImage.color.b, newAlpha);
            yield return null;
            time += Time.deltaTime;
        }
        objImage.color = new Color(objImage.color.r, objImage.color.g, objImage.color.b, endAlpha);
        yield return null;

        if (endAlpha == 0)
            objImage.gameObject.SetActive(false);
    }

    IEnumerator TextFadeCoroutine(GameObject getObject, float startAlpha, float endAlpha, float fadeTime)
    {
        Text objText = getObject.GetComponent<Text>();
        float time = 0;
        float newAlpha = startAlpha;

        while (time <= fadeTime)
        {
            newAlpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeTime);
            objText.color = new Color(objText.color.r, objText.color.g, objText.color.b, newAlpha);
            yield return null;
            time += Time.deltaTime;
        }
        objText.color = new Color(objText.color.r, objText.color.g, objText.color.b, endAlpha);
        yield return null;
    }
}
