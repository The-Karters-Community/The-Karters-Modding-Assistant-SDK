using BepInEx.Logging;

namespace TheKartersAssistant;

public abstract class AbstractLogger {
    protected static ManualLogSource UnityLogger;
    protected static bool isEnabled = false;

    public static void Initialize(ManualLogSource unityLogger) {
        Logger.UnityLogger = unityLogger;
    }

    /// <summary>
    /// Enable the logger.
    /// </summary>
    /// 
    /// <returns>Logger</returns>
    public static void Enable() {
        Logger.isEnabled = true;
    }

    /// <summary>
    /// Disable the logger.
    /// </summary>
    /// 
    /// <returns>Logger</returns>
    public static void Disable() {
        Logger.isEnabled = false;
    }

    public static void Log(object Content, bool force = false) {
        if (Logger.isEnabled || force) {
            Logger.UnityLogger.LogMessage(Content);
        }
    }

    public static void Info(object Content, bool force = false) {
        if (Logger.isEnabled || force) {
            Logger.UnityLogger.LogInfo(Content);
        }
    }

    public static void Warn(object Content) {
        Logger.UnityLogger.LogWarning(Content);
    }

    public static void Error(object Content) {
        Logger.UnityLogger.LogError(Content);
    }
}