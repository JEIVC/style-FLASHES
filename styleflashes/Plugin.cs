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
using UnityEngine.Networking;
using System.Drawing;

namespace styleFLASHES;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static class PatchMethods
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(StyleHUD), "AddPoints")]
        private static void LikeAfterAddPoints(int points, string pointID)
        {
            var bonus = pointID.Replace("<color=orange>", "_Orange", StringComparison.OrdinalIgnoreCase)
            .Replace("<color=#00ffffff>", "_Cyan", StringComparison.OrdinalIgnoreCase)
            .Replace("<color=#00FFFF>", "_Cyan", StringComparison.OrdinalIgnoreCase)
            .Replace("<color=red>", "_Red", StringComparison.OrdinalIgnoreCase)
            .Replace("<color=green>", "_Green", StringComparison.OrdinalIgnoreCase)
            .Replace("<color=grey>", "_Grey", StringComparison.OrdinalIgnoreCase)
            .Replace("</color>", "_e", StringComparison.OrdinalIgnoreCase);

            Logger.LogInfo("remvoe this: " + bonus);
            Sprite temp = imagePool.Where(obj => obj.name == bonus).SingleOrDefault();
            AudioClip clip = audioPool.Where(obj => obj.name == bonus).SingleOrDefault();
            if (temp == null && clip == null) return;

            // MonoSingleton<TimeController>.Instance.HitStop(0.1f);

            

            GameObject flashObj = new GameObject("StyleFlash", typeof(CanvasRenderer), typeof(Image), typeof(AudioSource));
            if (temp != null) Logger.LogInfo("Displaying image for style: " + temp.name);
            else flashObj.GetComponent<Image>().enabled = false;
            flashObj.GetComponent<Image>().sprite = temp;
            if (clip != null)
            {
                Logger.LogInfo("Playing audio for style: " + clip.name);
                flashObj.GetComponent<AudioSource>().clip = clip;
            }
            flashObj.transform.SetParent(MonoSingleton<SFGroup>.Instance.group.transform, false);
            Flash flash = flashObj.AddComponent<Flash>();

            flash.fade();
            // executor.StartCoroutine(executor.FadeOut(img, 0.5f));
        }

        
    }
    internal static new ManualLogSource Logger;
    public Harmony harm;

    public static List<string> imageTypes = new List<string> { ".jpeg", ".jpg", ".png", ".bmp" };
    public static List<string> audioTypes = new List<string> { ".mp3", ".ogg", ".wav", ".aif" };
    public static List<Sprite> imagePool = new List<Sprite>();
    public static List<AudioClip> audioPool = new List<AudioClip>();
    public static string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }

    public void Start()
    {
        UpdatePools();
        harm = new Harmony(MyPluginInfo.PLUGIN_GUID);
        harm.PatchAll(typeof(PatchMethods));
    }

    public static void UpdatePools()
    {
        imagePool = new List<Sprite>();
        audioPool = new List<AudioClip>();
        foreach (string item2 in Directory.EnumerateFiles(Path.Combine(Path.Combine(directory, "assets"))))
        {
            // Logger.LogInfo(item2);
            for (int i = 0; i < imageTypes.Count; i++)
            {
                if (string.Equals(imageTypes[i], Path.GetExtension(item2), StringComparison.OrdinalIgnoreCase))
                {
                    byte[] array = File.ReadAllBytes(item2);
                    Texture2D texture2D = new Texture2D(0, 0, TextureFormat.RGBA32, mipChain: false);
                    texture2D.filterMode = FilterMode.Point;
                    ImageConversion.LoadImage(texture2D, array);
                    Sprite item = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                    item.name = System.IO.Path.GetFileNameWithoutExtension(item2);
                    imagePool.Add(item);
                    Logger.LogInfo($"Loaded image {item.name}...");
                    break;
                }
            }

            for (int j = 0; j < audioTypes.Count; j++)
            {
                if (string.Equals(audioTypes[j], Path.GetExtension(item2), StringComparison.OrdinalIgnoreCase))
                {
                    // byte[] array = File.ReadAllBytes(item2);
                    // Texture2D texture2D = new Texture2D(0, 0, TextureFormat.RGBA32, mipChain: false);
                    // texture2D.filterMode = FilterMode.Point;
                    // ImageConversion.LoadImage(texture2D, array);
                    // Sprite item = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                    UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(item2, AudioType.UNKNOWN);;
                    req.SendWebRequest();
                    while (!req.isDone)
                    {
                    }
                    AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
                    var name = System.IO.Path.GetFileNameWithoutExtension(item2);
                    // name = name.Replace("_Orange", "<color=orange>", StringComparison.OrdinalIgnoreCase);
                    // name = name.Replace("_Cyan", "<color=#00ffffff>", StringComparison.OrdinalIgnoreCase);
                    // name = name.Replace("_Red", "<color=red>", StringComparison.OrdinalIgnoreCase);
                    // name = name.Replace("_Green", "<color=green>", StringComparison.OrdinalIgnoreCase);
                    // name = name.Replace("_Grey", "<color=grey>", StringComparison.OrdinalIgnoreCase);
                    // name = name.Replace("_e", "</color>", StringComparison.OrdinalIgnoreCase);
                    clip.name = name;
                    audioPool.Add(clip);
                    Logger.LogInfo($"Loaded audio clip {clip.name}...");
                    break;
                }
            }
        }
    }
}


