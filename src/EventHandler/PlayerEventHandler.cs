using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.EventHandler;

public static class PlayerEventHandler {
    public static Logger logger;

    public static void Initialize(Logger logger) {
        PlayerEventHandler.logger = logger;

        PlayerEvent.onHeal += OnHeal;
        PlayerEvent.onDeath += OnDeath;
        PlayerEvent.onItemHit += OnItemHit;
        PlayerInputEvent.onTopFaceButtonPress += OnTopFaceButtonPress;
    }

    public static void OnHeal(Player player, int healthToHeal, bool healExtraHealth) {
        logger.Log($"{player.GetName()} heals himself {healthToHeal} HP.");
    }

    public static void OnDeath(Player player) {
        logger.Log($"{player.GetName()} has been killed.");
    }

    public static void OnItemHit(Player player, int damages, Player authorPlayer, Item hitByItem) {
        logger.Log($"{player.GetName()} lost {damages} HP ({authorPlayer.GetName()} with {hitByItem}).");
    }

    public static void OnTopFaceButtonPress(Player player) {
        
    }
}