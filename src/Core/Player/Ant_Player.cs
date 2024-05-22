using HarmonyLib;
using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(Ant_Player), nameof(Ant_Player.Update))]
public class Ant_Player__Update {
    public static void Prefix(Ant_Player __instance) {
        PlayerEvent.onUpdate?.Invoke(Player.FindByAntPlayer(__instance));
    }

    public static void Postfix(Ant_Player __instance) {
        PlayerEvent.onUpdateAfter?.Invoke(Player.FindByAntPlayer(__instance));
    }
}