using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace TheKartersModdingAssistant;

abstract public class AbstractPlugin : BasePlugin {
    public string pluginGuid;
    public string pluginName;
    public string pluginVersion;

    protected bool isDebugModeEnabled;

    public Harmony harmony;
    public Logger logger;

    /// <summary>
    /// Patch all the methods with Harmony.
    /// </summary>
    abstract public void ProcessPatching();

    /// <summary>
    /// Load the plugin.
    /// </summary>
    public override void Load() {
        this.logger.Info($"{this.pluginName} v{this.pluginVersion} has been loaded.", true);

        this.BindDefaultConfig();

        this.logger.IsEnabled(this.IsDebugModeEnabled());
        this.logger.Info($"The debug mode of {this.pluginName} has been enabled.");

        Patcher.Patch(this);
    }

    /// <summary>
    /// Unload the plugin.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public override bool Unload() {
        this.logger.Info($"{this.pluginName} v{this.pluginVersion} has been unloaded.", true);

        Patcher.Unpatch(this);

        return true;
    }

    /// <summary>
    /// Bind default configurations from the config file.
    /// </summary>
    protected void BindDefaultConfig() {
        ConfigEntry<bool> isDebugModeEnabled = Config.Bind(
            ConfigCategory.General,
            "isDebugModeEnabled",
            false,
            "Whether the debug mode is enabled."
        );

        this.IsDebugModeEnabled(isDebugModeEnabled.Value);
    }

    /// <summary>
    /// Tell whether the debug mode is enabled.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsDebugModeEnabled() {
        return this.isDebugModeEnabled;
    }

    /// <summary>
    /// Set whether the debug mode is enabled.
    /// </summary>
    /// 
    /// <param name="isDebugModeEnabled">bool</param>
    /// <returns>AbstractPlugin</returns>
    public AbstractPlugin IsDebugModeEnabled(bool isDebugModeEnabled) {
        this.isDebugModeEnabled = isDebugModeEnabled;

        return this;
    }
}
