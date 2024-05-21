using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using TkaConfig = TheKartersAssistant.Config;

namespace TheKartersAssistant;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class TheKartersAssistant : BasePlugin {
    public static TheKartersAssistant Instance;

    public TkaConfig config;
    public TkaConfig defaultConfig;

    public TheKartersAssistant() {
        this.config = new TkaConfig();
        this.defaultConfig = new TkaConfig();
    }

    public override void Load() {
        Logger.Initialize(this.Log);
        Logger.Info($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} has been loaded.", true);

        TheKartersAssistant.Instance = this;

        this.BindFromConfig();

        if (this.config.IsDebugModeEnabled()) {
            Logger.Enable();
        }

        Logger.Info($"The debug mode of {MyPluginInfo.PLUGIN_NAME} has been enabled.");

        Patcher.Patch(this);
    }

    public override bool Unload() {
        Logger.Info($"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION} has been unloaded.", true);
        Patcher.Unpatch(this);

        return true;
    }

    public void BindFromConfig() {
        this.BindGeneralConfig();
    }

    protected void BindGeneralConfig() {
       ConfigEntry<bool> isDebugModeEnabled = Config.Bind(
            ConfigCategory.General,
            "isDebugModeEnabled",
            false,
            "Whether the debug mode is enabled."
        );

        this.config.IsDebugModeEnabled(isDebugModeEnabled.Value);
        this.defaultConfig.IsDebugModeEnabled((bool)isDebugModeEnabled.DefaultValue);
    }
}
