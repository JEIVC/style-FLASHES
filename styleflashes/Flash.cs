using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using System.Security.Cryptography.X509Certificates;

namespace styleFLASHES;
public class Flash : MonoBehaviour
{
    public YieldInstruction fadeInstruction = new();
    public IEnumerator FadeOut(Image image, float fadeTime)
    {
        float elapsedTime = 0.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }

    private void Awake()
    {
        GameObject canvas = GameObject.Find("/Canvas");

        GameObject flash = gameObject;
        // flash = new("StyleFlash", typeof(CanvasRenderer), typeof(Image));
        RectTransform trans = flash.GetComponent<RectTransform>();
        Image img = flash.GetComponent<Image>();

        // canvas.transform.SetParent(MonoSingleton<PlayerTracker>.Instance.GetTarget());
        //trans.SetParent(canvas.transform, false);
        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f);
        trans.sizeDelta =  canvas.GetComponent<RectTransform>().sizeDelta * 1f;
    }

    public void fade()
    {
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(FadeOut(gameObject.GetComponent<Image>(), 1f));
    }
}