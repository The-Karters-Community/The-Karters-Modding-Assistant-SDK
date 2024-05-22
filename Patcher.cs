namespace TheKartersModdingAssistant;

public class Patcher {
    /// <summary>
    /// Patch the game with Harmony.
    /// </summary>
    /// 
    /// <param name="plugin">AbstractPlugin</param>
    public static void Patch(AbstractPlugin plugin) {
        if (plugin == null) {
            plugin.logger.Error($"Plugin not found while patching, can't be loaded properly.");

            return;
        }

        plugin.logger.Info($"Patching {plugin.pluginName}...", true);

        plugin.ProcessPatching();
    }

    /// <summary>
    /// Unpatch the game.
    /// </summary>
    /// 
    /// <param name="plugin">AbstractPlugin</param>
    public static void Unpatch(AbstractPlugin plugin) {
        if (plugin == null) {
            plugin.logger.Error($"Plugin not found while unpatching, can't be unloaded properly.");

            return;
        }

        plugin.harmony.UnpatchSelf();
    }
}