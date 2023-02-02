using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class SoulGlow : MonoBehaviour
{
    Image soulGlowImage;
    // Start is called before the first frame update
    void Start()
    {
        soulGlowImage = this.GetComponent<Image>();
        Glow();
    }

    void Glow()
    {
        StartCoroutine(GlowCoroutine());
    }

    IEnumerator GlowCoroutine()
    {
        float timer = -0.5f;
        int one = 1;

        while (true)
        {
            timer += Time.deltaTime * one;
            soulGlowImage.color = new Color(1, 1, 1, timer + 0.5f);
            if (Mathf.Abs(timer) >= 0.5f)
            {
                one *= -1;
            }
            yield return null;
        }
    }
}
