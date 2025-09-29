using PluginConfig.API;
using PluginConfig.API.Fields;
using PluginConfig.API.Decorators;
using UnityEngine;
using System.IO;
using System.Reflection;

namespace styleFLASHES;

public static class SFConfig
{
    private static PluginConfigurator config;

    public static FloatField fadeTime;
    public static FloatField imageAlpha;

    public static FloatField audioVolume;


    private static string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public static void Init()
    {
        config = PluginConfigurator.Create(MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_GUID);
        config.SetIconWithURL("file://" + Path.Combine(directory, "icon.png"));

        ConfigHeader visualHeader = new ConfigHeader(config.rootPanel, "Flash : Visual");
        fadeTime = new FloatField(config.rootPanel, "Flash Fade Time", "fade_time", 0.25f);
        fadeTime.maximumValue = 1f;
        fadeTime.minimumValue = 0.1f;

        imageAlpha = new FloatField(config.rootPanel, "Flash Alpha", "image_alpha", 1f);
        imageAlpha.maximumValue = 1f;
        imageAlpha.minimumValue = 0f;

        ConfigHeader audioHeader = new ConfigHeader(config.rootPanel, "Flash : Audio");
        audioVolume = new FloatField(config.rootPanel, "Audio Volume", "audio_vol", 1f);
        audioVolume.maximumValue = 4f;
        audioVolume.minimumValue = 0f;
    }
}
