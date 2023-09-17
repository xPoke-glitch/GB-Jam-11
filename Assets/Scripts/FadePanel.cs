using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class FadePanel : Singleton<FadePanel>
{
    [SerializeField]
    private float _fadeTime = 2.0f;
    [SerializeField]
    private Image _fadeImage;

    public void FadeIn(Action callback = null)
    {
        LeanTween.color(_fadeImage.rectTransform, new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 1), _fadeTime).setOnComplete(() =>
        {
            if (callback != null)
                callback?.Invoke();
        });
    }

    public void FadeOut(Action callback = null)
    {
        LeanTween.color(_fadeImage.rectTransform, new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, 0), _fadeTime).setOnComplete(() =>
        {
            if (callback != null)
                callback?.Invoke();
        });
    }
}
