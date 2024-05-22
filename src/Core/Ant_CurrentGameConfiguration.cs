using HarmonyLib;
using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(Ant_CurrentGameConfiguration), nameof(Ant_CurrentGameConfiguration.Start))]
public class Ant_CurrentGameConfiguration__Start {
    public static void Postfix(Ant_CurrentGameConfiguration __instance) {
        GameEvent.onGameStart?.Invoke();
    }
}