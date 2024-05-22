using HarmonyLib;
using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.Core;

/*[HarmonyPatch(typeof(Ant_BoostManager), nameof(Ant_BoostManager.FixedUpdate))]
public class Ant_BoostManager__FixedUpdate {
    public static void Prefix(Ant_BoostManager __instance) {
        PlayerEvent.onFixedUpdate?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }

    public static void Postfix(Ant_BoostManager __instance) {
        PlayerEvent.onFixedUpdateAfter?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }
}*/

[HarmonyPatch(typeof(Ant_BoostManager), nameof(Ant_BoostManager.FireSliderBoost))]
public class Ant_BoostManager__FireSliderBoost {
    public static void Prefix(Ant_BoostManager __instance) {
        PlayerEvent.onBoost?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }

    public static void Postfix(Ant_BoostManager __instance) {
        Player player = Player.FindByAntPlayer(__instance.kartController.parentPlayer);

        PlayerEvent.onBoostAfter?.Invoke(player);

        player.IncreaseCurrentBoostNumber();
    }
}

[HarmonyPatch(typeof(Ant_BoostManager), nameof(Ant_BoostManager.WallCollisionOccuredInTimeFromLastOne))]
public class Ant_BoostManager__WallCollisionOccuredInTimeFromLastOne {
    public static void Prefix(Ant_BoostManager __instance) {
        PlayerEvent.onWallHit?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }

    public static void Postfix(Ant_BoostManager __instance) {
        PlayerEvent.onWallHitAfter?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }
}

[HarmonyPatch(typeof(Ant_BoostManager), nameof(Ant_BoostManager.BoostPadTriggerEnter))]
public class Ant_BoostManager__BoostPadTriggerEnter {
    public static void Prefix(Ant_BoostManager __instance, ref float fBoostStrength, ref float fBoostpadLength) {
        PlayerEvent.onPadEnter?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer), fBoostStrength, fBoostpadLength);
    }

    public static void Postfix(Ant_BoostManager __instance, float fBoostStrength, float fBoostpadLength) {
        PlayerEvent.onPadEnterAfter?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer), fBoostStrength, fBoostpadLength);
    }
}

[HarmonyPatch(typeof(Ant_BoostManager), nameof(Ant_BoostManager.OnKartLandedAfterPlayerTriggeredJump))]
public class Ant_BoostManager__OnKartLandedAfterPlayerTriggeredJump {
    public static void Prefix(Ant_BoostManager __instance, ref bool bIsPlayerMadeTrickBeforeLanding) {
        PlayerEvent.onLand?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer), bIsPlayerMadeTrickBeforeLanding);
    }

    public static void Postfix(Ant_BoostManager __instance, bool bIsPlayerMadeTrickBeforeLanding) {
        PlayerEvent.onLandAfter?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer), bIsPlayerMadeTrickBeforeLanding);
    }
}