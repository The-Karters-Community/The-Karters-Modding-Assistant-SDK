using BepInEx.Logging;

namespace TheKartersAssistant;

public class Logger {
    protected ManualLogSource UnityLogger;
    protected bool isEnabled = false;

    /// <summary>
    /// AbstractLogger constructor.
    /// </summary>
    /// 
    /// <param name="unityLogger">ManualLogSource</param>
    public Logger(ManualLogSource unityLogger) {
        this.UnityLogger = unityLogger;
    }

    /// <summary>
    /// Tell whether the logger is enabled.
    /// </summary>
    /// <returns></returns>
    public bool IsEnabled() {
        return this.isEnabled;
    }

    /// <summary>
    /// Set whether the logger is enabled.
    /// </summary>
    /// 
    /// <param name="isEnabled">bool</param>
    /// <returns>Logger</returns>
    public Logger IsEnabled(bool isEnabled) {
        this.isEnabled = isEnabled;

        return this;
    }

    /// <summary>
    /// Enable the logger.
    /// </summary>
    /// 
    /// <returns>Logger</returns>
    public Logger Enable() {
        return this.IsEnabled(true);
    }

    /// <summary>
    /// Disable the logger.
    /// </summary>
    /// 
    /// <returns>Logger</returns>
    public Logger Disable() {
        return this.IsEnabled(false);
    }

    /// <summary>
    /// Log a debug message to the console when the logger is enabled, unless "force" is true.
    /// </summary>
    /// 
    /// <param name="Content">object</param>
    /// <param name="force">bool</param>
    /// <returns>Logger</returns>
    public Logger Log(object Content, bool force = false) {
        if (this.IsEnabled() || force) {
            this.UnityLogger.LogMessage(Content);
        }

        return this;
    }

    /// <summary>
    /// Log an information message to the console when the logger is enabled, unless "force" is true.
    /// </summary>
    /// 
    /// <param name="Content">object</param>
    /// <param name="force">bool</param>
    /// <returns>Logger</returns>
    public Logger Info(object Content, bool force = false) {
        if (this.IsEnabled() || force) {
            this.UnityLogger.LogInfo(Content);
        }

        return this;
    }

    /// <summary>
    /// Log a warning message to the console.
    /// </summary>
    /// 
    /// <param name="Content">object</param>
    /// <returns>Logger</returns>
    public Logger Warn(object Content) {
        this.UnityLogger.LogWarning(Content);

        return this;
    }

    /// <summary>
    /// Log an error message to the console.
    /// </summary>
    /// 
    /// <param name="Content">object</param>
    /// <returns>Logger</returns>
    public Logger Error(object Content) {
        this.UnityLogger.LogError(Content);

        return this;
    }
}