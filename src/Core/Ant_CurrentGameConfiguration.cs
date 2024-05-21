using HarmonyLib;
using TheKartersAssistant.Event;

namespace TheKartersAssistant.Core;

[HarmonyPatch(typeof(Ant_CurrentGameConfiguration), nameof(Ant_CurrentGameConfiguration.Start))]
public class Ant_CurrentGameConfiguration__Start {
    public static void Postfix(Ant_CurrentGameConfiguration __instance) {
        GameEvent.onGameStart?.Invoke();
    }
}